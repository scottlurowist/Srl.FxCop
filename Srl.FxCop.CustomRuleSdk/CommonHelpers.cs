//
// CommonHelpers.cs
//
// Product:
//
// Component: Srl.FxCop.CustomRuleSdk
//
// Description: Represents common, custom functionality.
//
// Author: Scott Lurowist
//




#region Using Directives

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.FxCop.Sdk;

#endregion




namespace Srl.FxCop.CustomRuleSdk
{
    /// <summary>
    /// Represents common, custom functionality.
    /// </summary>
    public static class CommonHelpers
    {
        /// <summary>
        /// Gets the CustomInstruction instance that loads the target of an extension method that
        /// invokes a lamda expression. 
        /// </summary>
        /// <param name="extMethodInstruction">
        /// The CustomInstruction instance that loads the target of the extension method. The target is
        /// an instance of the type upon which the extension method operates.
        /// </param>
        /// <param name="instructionList">
        /// A list of CustomInstruction in which an extension method that invokes a lamda expression exists.
        /// </param>
        /// <returns>
        /// The target; otherwise, null.
        /// </returns>
        public static CustomInstruction GetInstructionThatLoadsTheTargetOfAnExtensionMethod(CustomInstruction extMethodInstruction,
            IList<CustomInstruction> instructionList)
        {
            CustomInstruction targetInstruction = null;

            // TODO: A bunch of validation here:
            if (extMethodInstruction == null)
                throw new ArgumentNullException("extMethodInstruction", "extMethodInstruction cannot be null");

            // The stack that emulates the VES evaluationstack.
            Stack<CustomInstruction> evaluationStack = new Stack<CustomInstruction>();

            Stack<bool> pathToInstruction = FindBranchPathToInstruction(extMethodInstruction, instructionList);

            for (int count = 0; count < instructionList.Count; count++ )
            {
                var customInstruction = instructionList[count];

                // Check if we have found our extension method in question. The offset uniquely identifies 
                // an instruction.
                if (customInstruction.Offset == extMethodInstruction.Offset)
                {
                    // According to ECMA-335, the only operands at this point should be the arguments
                    // for the extension method of interest. Arguments are pushed onto the stack from
                    // left to right. So the target of our extension method will be the instruction
                    // on the bottom of the VES stack.
                    int numberOfArguments = (extMethodInstruction.Value as CustomMethod).NumberOfParameters;

                    for (int i = 0; i < numberOfArguments; i++)
                    {
                        targetInstruction = evaluationStack.Pop();
                    }

                    break;
                }

                if (CommonHelpers.IsACallInstruction(customInstruction))
                {
                    CustomMethod meth = customInstruction.Value as CustomMethod;

                    // Each argument gets popped from the stack on a method call, and the return
                    // value is pushed onto the stack if the method return type is non-void.
                    int numberOfArguments = (customInstruction.Value as CustomMethod).NumberOfParameters + 1;

                    for (int i = 0; i < numberOfArguments; i++)
                    {
                        evaluationStack.Pop();
                    }

                    if (!(customInstruction.Value as CustomMethod).IsReturnTypeVoid)
                        evaluationStack.Push(customInstruction);                    
                }
                else if (CommonHelpers.IsALoadInstruction(customInstruction))
                {
                    evaluationStack.Push(customInstruction);                    
                }
                else if (CommonHelpers.IsAStoreInstruction(customInstruction))
                {
                    evaluationStack.Pop();
                }
                else
                {
                    int targetOffset = 0;

                    switch (customInstruction.OpCode)
                    {
                        case OpCode.Box:
                            evaluationStack.Pop();
                            evaluationStack.Push(new CustomInstruction());
                            break;
                        case OpCode.Ceq:
                            evaluationStack.Pop();
                            evaluationStack.Pop();
                            // It would actually push a 1 or 0, but we don't care for purposes of finding targets.
                            evaluationStack.Push(new CustomInstruction());
                            break;
                        case OpCode.Conv_I8:
                            evaluationStack.Pop();
                            evaluationStack.Push(new CustomInstruction());
                            break;
                        case OpCode.Newarr:
                        case OpCode.Newobj:
                            // TODO: Scott - How many parameters does this take?
                            if (customInstruction.Value is CustomMethod)
                            {
                                int parameters = (customInstruction.Value as CustomMethod).NumberOfParameters;

                                for (int i = 0; i < parameters; i++)
                                {
                                    evaluationStack.Pop();
                                }
                            }
                            //evaluationStack.Clear();
                            evaluationStack.Push(customInstruction);
                            break;

                        case OpCode.Pop:
                            evaluationStack.Pop();
                            break;
                        case OpCode.Br_S:
                            //evaluationStack.Pop();
                            targetOffset = Convert.ToInt32(customInstruction.Value);

                            for (int innerCount = count + 1; innerCount < instructionList.Count; innerCount++)
                            {
                                if (instructionList[innerCount].Offset == targetOffset)
                                {
                                    // Subtract the extra one because the increment in the for loop will increment.
                                    count = innerCount - 1;
                                    break;
                                }
                            }                                

                            break;
                        case OpCode.Brtrue_S:
                            evaluationStack.Pop();
                            targetOffset = Convert.ToInt32(customInstruction.Value);

                            if (pathToInstruction.Pop())
                            {
                                for (int innerCount = count + 1; innerCount < instructionList.Count; innerCount++)
                                {
                                    if (instructionList[innerCount].Offset == targetOffset)
                                    {
                                        count = innerCount - 1;
                                        break;
                                    }
                                }                                
                            }

                            break;
                        case OpCode.Leave_S:
                            evaluationStack.Clear();

                            targetOffset = Convert.ToInt32(customInstruction.Value);

                            for (int innerCount = count + 1; innerCount < instructionList.Count; innerCount++)
                            {
                                if (instructionList[innerCount].Offset == targetOffset)
                                {
                                    count = innerCount - 1;
                                    break;
                                }
                            } 
                            break;
                        default:
                            // Any instruction that makes it here do not affect the evaluation stack.
                            int x = 4;
                            break;
                    }                    
                }
            }

            return targetInstruction;
        }


        /// <summary>
        /// Gets the variable name for an instance of CustomInstruction in which the Value property
        /// represents a variable name. Only certain instructions such as loads and stores have a
        /// variable name as their value.
        /// </summary>
        /// <param name="instruction"></param>
        /// <returns></returns>
        public static string GetVariableNameFromInstructionValue(CustomInstruction instruction)
        {
            string variableName = null;

            if (instruction == null)
                throw new ArgumentNullException("instruction", "instruction cannot be null");

            if (instruction.Value == null)
                throw new ArgumentNullException("instruction", "instruction.Value cannot be null");


            switch (instruction.OpCode)
            {
                case OpCode.Ldfld:
                case OpCode.Ldflda:
                case OpCode.Ldsfld:
                case OpCode.Ldsflda:
                case OpCode.Stfld:
                case OpCode.Stsfld:
                    // The instrospection API returns the full namespace and varaible name and it encloses values in curly braces,
                    // such as: 
                    // {Srl.FxCop.CustomDeveloperTestRules.TestTargets.DoNotConfuseRhinoMocksStubsWithMocksTarget._barMock}
                    variableName = instruction.Value.ToString().Split('.').Last().TrimEnd('}');
                    break;
            }

            return variableName;
        }


        /// <summary>
        /// Determines whether a given instruction is a variant of a Call instruction.
        /// </summary>
        /// <param name="instruction">
        /// The instuction to be evaluated.
        /// </param>
        /// <returns>
        /// true if the instruction is a variant of a Call instruction; otherwise, false.
        /// </returns>
        public static bool IsACallInstruction(CustomInstruction instruction)
        {
            bool result = false;

            switch (instruction.OpCode)
            {
                case OpCode.Call:
                case OpCode.Calli:
                case OpCode.Callvirt:

                    result = true;
                    break;
            }

            return result;
        }


        /// <summary>
        /// Determines whether a given instruction is a variant of a Load instruction.
        /// </summary>
        /// <param name="instruction">
        /// The instuction to be evaluated.
        /// </param>
        /// <returns>
        /// true if the instruction is a variant of a Call instruction; otherwise, false.
        /// </returns>
        public static bool IsALoadInstruction(CustomInstruction instruction)
        {
            bool result = false;

            switch (instruction.OpCode)
            {
                case OpCode.Ldarg:
                case OpCode.Ldarg_0:
                case OpCode.Ldarg_1:
                case OpCode.Ldarg_2:
                case OpCode.Ldarg_3:
                case OpCode.Ldarg_S:
                case OpCode.Ldarga:
                case OpCode.Ldarga_S:
                case OpCode.Ldc_I4:
                case OpCode.Ldc_I4_0:
                case OpCode.Ldc_I4_1:
                case OpCode.Ldc_I4_2:
                case OpCode.Ldc_I4_3:
                case OpCode.Ldc_I4_4:
                case OpCode.Ldc_I4_5:
                case OpCode.Ldc_I4_6:
                case OpCode.Ldc_I4_7:
                case OpCode.Ldc_I4_8:
                case OpCode.Ldc_I4_M1:
                case OpCode.Ldc_I4_S:
                case OpCode.Ldc_I8:
                case OpCode.Ldc_R4:
                case OpCode.Ldc_R8:
                case OpCode.Ldelem:
                case OpCode.Ldelem_I:
                case OpCode.Ldelem_I1:
                case OpCode.Ldelem_I2:
                case OpCode.Ldelem_I4:
                case OpCode.Ldelem_I8:
                case OpCode.Ldelem_R4:
                case OpCode.Ldelem_R8:
                case OpCode.Ldelem_Ref:
                case OpCode.Ldelem_U1:
                case OpCode.Ldelem_U2:
                case OpCode.Ldelem_U4:
                case OpCode.Ldelema:
                case OpCode.Ldfld:
                case OpCode.Ldflda:
                case OpCode.Ldftn:
                case OpCode.Ldind_I:
                case OpCode.Ldind_I1:
                case OpCode.Ldind_I2:
                case OpCode.Ldind_I4:
                case OpCode.Ldind_I8:
                case OpCode.Ldind_R4:
                case OpCode.Ldind_R8:
                case OpCode.Ldind_Ref:
                case OpCode.Ldind_U1:
                case OpCode.Ldind_U2:
                case OpCode.Ldind_U4:
                case OpCode.Ldlen:
                case OpCode.Ldloc:
                case OpCode.Ldloc_0:
                case OpCode.Ldloc_1:
                case OpCode.Ldloc_2:
                case OpCode.Ldloc_3:
                case OpCode.Ldloc_S:
                case OpCode.Ldloca:
                case OpCode.Ldloca_S:
                case OpCode.Ldnull:
                case OpCode.Ldobj:
                case OpCode.Ldsfld:
                case OpCode.Ldsflda:
                case OpCode.Ldstr:
                case OpCode.Ldtoken:
                case OpCode.Ldvirtftn:

                    result = true;
                    break;
            }

            return result;
        }


        /// <summary>
        /// Determines whether a given instruction is a variant of a Store instruction.
        /// </summary>
        /// <param name="instruction">
        /// The instuction to be evaluated.
        /// </param>
        /// <returns>
        /// true if the instruction is a variant of a Store instruction; otherwise, false.
        /// </returns>
        public static bool IsAStoreInstruction(CustomInstruction instruction)
        {
            bool result = false;

            switch (instruction.OpCode)
            {
                case OpCode.Starg:
                case OpCode.Starg_S:
                //case OpCode.Stelem:
                //case OpCode.Stelem_I:
                //case OpCode.Stelem_I1:
                //case OpCode.Stelem_I2:
                //case OpCode.Stelem_I4:
                //case OpCode.Stelem_I8:
                //case OpCode.Stelem_R4:
                //case OpCode.Stelem_R8:
                //case OpCode.Stelem_Ref:
                //case OpCode.Stfld:
                //case OpCode.Stind_I:
                //case OpCode.Stind_I1:
                //case OpCode.Stind_I2:
                //case OpCode.Stind_I4:
                //case OpCode.Stind_I8:
                //case OpCode.Stind_R4:
                //case OpCode.Stind_R8:
                //case OpCode.Stind_Ref:
                case OpCode.Stloc:
                case OpCode.Stloc_0:
                case OpCode.Stloc_1:
                case OpCode.Stloc_2:
                case OpCode.Stloc_3:
                case OpCode.Stloc_S:
                case OpCode.Stobj:
                case OpCode.Stsfld:

                    result = true;
                    break;
            }

            return result;
        }


        public static Stack<bool> FindBranchPathToInstruction(CustomInstruction instruction, IList<CustomInstruction> instructionList)
        {
            Stack<bool> pathStack = new Stack<bool>();

            IList<int> offsets = new List<int>();

            int targetOffset = instruction.Offset;
            int start = instructionList.IndexOf(instruction) - 1;

            offsets.Add(targetOffset);

            for (int i = start; i >= 0; i--)
            {
                CustomInstruction currentInstruction = instructionList[i];
                offsets.Add(currentInstruction.Offset);

                switch (currentInstruction.OpCode)
                {
                        case OpCode.Br_S:
                        if (currentInstruction.Offset > targetOffset)
                                continue;
                            break;    
                        case OpCode.Brtrue_S:
                            if (currentInstruction.Offset > targetOffset)
                                continue;
                            else
                            {
                                if (offsets.Contains((int)currentInstruction.Value))
                                {
                                    pathStack.Push(true);
                                }
                                else
                                {
                                    pathStack.Push(false);
                                }

                                continue;
                            }

                            
                            break;
                        case OpCode.Brtrue:
                            if (currentInstruction.Offset > targetOffset)
                                continue;
                        break;
                }   
            }



            return pathStack;
        }

        #region Candidate Alpha
        public static void FindPathToInstructionStart(CustomInstruction instruction, IList<CustomInstruction> instructionList)
        {
            IList<bool> path = new List<bool>();

            for (int currentInstructionIndex = 0; currentInstructionIndex < instructionList.Count; currentInstructionIndex++ )
            {
                switch (instructionList[currentInstructionIndex].OpCode)
                {
                    case OpCode.Brtrue_S:
                    case OpCode.Brtrue:
                    case OpCode.Brfalse_S:
                    case OpCode.Brfalse:
                        FindPathToInstructionRecursive(currentInstructionIndex,
                            instructionList[currentInstructionIndex], instructionList, path);
                        break;
                }
            }
        }


        public static void FindPathToInstructionRecursive(int currentInstructionIndex, CustomInstruction instructionToReach,
            IList<CustomInstruction> instructionList, IList<bool> path )
        {
            // We need to branch to this offset and continue our search.
            int targetField = (int)instructionList[currentInstructionIndex].Value;

            currentInstructionIndex++;

            for (;currentInstructionIndex < instructionList.Count; currentInstructionIndex++)
            {
                if (instructionList[currentInstructionIndex].Offset == targetField)
                {
                    // We have found the target of our branch. Now continue to find the instructionToReach.
                    // We MUST find our branch target because otherwise the compiler would be producing garbage.
                    break;
                }
            }

            // Now we continue our search for the instructionToReach.
            for (; currentInstructionIndex < instructionList.Count; currentInstructionIndex++)
            {
                // Check if the current instruction is the instructionToReach.
                if (instructionList[currentInstructionIndex].Offset == instructionToReach.Offset)
                {
                    // We found the instruction to reach. Remember that Offset is a
                    // unique value for a given instruction.

                }
                else
                {
                    //switch (instructionList[currentInstructionIndex].OpCode)
                    //{
                    //    case OpCode.Brtrue_S:
                    //    case OpCode.Brtrue:
                    //    case OpCode.Brfalse_S:
                    //    case OpCode.Brfalse:
                    //        var results = FindPathToInstructionRecursive(currentInstructionIndex, instructionList);
                    //        break;
                    //}                    
                }
            }
        }

        #endregion
    }  
}
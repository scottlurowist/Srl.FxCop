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
        public static CustomInstruction GetInstructionThatLoadsTheTargetOfAnExtensionMethodWithLamda(CustomInstruction extMethodInstruction,
            IList<CustomInstruction> instructionList)
        {
            // TODO: A bunch of validation here:
            if (extMethodInstruction == null)
                throw new ArgumentNullException("extMethodInstruction", "extMethodInstruction cannot be null");

            int extMethodInstructionIndex = instructionList.IndexOf(extMethodInstruction);

            // The previous instruction should load our lamda expresion for the extension method onto the VES.
            int lamdaExpressionOffset = instructionList[extMethodInstructionIndex - 1].Offset;

            // Find the branch instruction that branched to lamdaExpressionOffset. That branch
            // instruction checks that the delegate that represents the lamda expression does
            // indeed exist. Value on the instruction object will be the offset.
            int currentInstructionIndex = 0;

            var instructonListCopy = instructionList.ToArray();

            CustomInstruction targetInstruction = null;

            foreach (var customInstruction in instructonListCopy)
            {
                if (customInstruction.OpCode == OpCode.Brtrue_S &&
                    customInstruction.Value.ToString() == Convert.ToString(lamdaExpressionOffset))
                {
                    // The previous instruction should load the lamda expression for the extension method
                    // onto the VES. The instruction for that is the one that loads the target of the 
                    // extension method.
                    targetInstruction = instructonListCopy[currentInstructionIndex - 2];
                    break;
                }

                currentInstructionIndex++;
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
    }  
}
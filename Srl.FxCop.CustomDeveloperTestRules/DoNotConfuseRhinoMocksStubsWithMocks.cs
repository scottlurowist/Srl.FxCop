//
// DoNotConfuseRhinoMocksStubsWithMocks.cs
//
// Product:
//
// Component: Srl.FxCop.CustomDeveloperTestRules
//
// Description: Represents an FxCop rule that checks whether RhinoMocks stubs and mocks
//              are being confused with each other. Such confusion can lead to unreliable tests.
//
// Author: Scott Lurowist
//




#region Using Directives

using System.Collections.Generic;
using Microsoft.FxCop.Sdk;
using Srl.FxCop.CustomRuleSdk;

#endregion




namespace Srl.FxCop.CustomDeveloperTestRules
{
    /// <summary>
    /// Represents an FxCop rule that checks whether RhinoMocks stubs and mocks
    /// are being confused with each other. Such confusion can lead to unreliable tests.
    /// </summary>
    internal sealed class DoNotConfuseRhinoMocksStubsWithMocks : BaseDeveloperTestFxCopRule
    {
        /// <summary>
        /// Initializes a new instance of DoNotVerifyMocksInTeardownMethod.
        /// </summary>
        public DoNotConfuseRhinoMocksStubsWithMocks()
            : base("DoNotConfuseRhinoMocksStubsWithMocks", typeof(DoNotConfuseRhinoMocksStubsWithMocks).Assembly)
        {
        }


        /// <summary>
        /// Gets the visibility of targets for this rule.
        /// </summary>
        public override TargetVisibilities TargetVisibility
        {
            get { return TargetVisibilities.All; }
        }


        public override void BeforeAnalysis()
        {
            int x = 4;
            base.BeforeAnalysis();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="member">
        /// 
        /// </param>
        /// <returns>
        /// 
        /// </returns>
        public override ProblemCollection Check(Member member)
        {
            var methodCandidate = member as Method;

            // Only check methods that have a test attribute.
            if ((methodCandidate != null) && 
                DoesMethodHaveAnAttribute(methodCandidate, DeveloperTestConstants.TestAttributeName))
            {
                // Get the setup instructions only once for this Check invocation, and use it 
                // for all resolutions.
                IList<CustomInstruction> setupMethodInstructions = 
                    GetListOfCustomInstructionForMethodByUniqueAttributeNameAndClassType(member.DeclaringType, 
                        DeveloperTestConstants.SetupMethodAttributeName);

                var helper = new Helpers.DoNotConfuseRhinoMocksStubsWithMocks();

                ProcessFoundProblems(helper.CheckIfRhinoMocksVerifyAllExpectationsIsInvokedOnAFieldThatIsAStub(
                        methodCandidate.Name.Name, 
                        setupMethodInstructions,
                        GetCustomInstructionListFromInstructionCollection(methodCandidate.Instructions)));

                ProcessFoundProblems(helper.CheckIfRhinoMocksVerifyAllExpectationsIsInvokedOnALocalThatIsAStub(
                        methodCandidate.Name.Name,
                        setupMethodInstructions,
                        GetCustomInstructionListFromInstructionCollection(methodCandidate.Instructions)));
            }

            return Problems;
        }


        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="node">
        ///// 
        ///// </param>
        ///// <returns>
        ///// 
        ///// </returns>
        //public override ProblemCollection Check(TypeNode node)
        //{
        //    // We are only interested in classes.
        //    if (node.NodeType != NodeType.Class)
        //        return Problems;

        //    // Find instance fields.
        //    foreach (var member in node.Members)
        //    {
        //        if (member is Field)
        //        {
        //            _classInstanceFields.Add(member.FullName);
        //        }
        //    }

        //    return Problems;
        //}



        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="node"></param>
        ///// <returns></returns>
        //public override ProblemCollection Check(TypeNode node)
        //{
        //    // We are only interested in classes.
        //    if (node.NodeType != NodeType.Class)
        //        return Problems;

        //    // Find instance fields.
        //    foreach (var member in node.Members)
        //    {
        //        if (member is Field)
        //        {
        //            _classInstanceFields.Add(member.FullName);
        //        }
        //    }

        //    // Find setup methods and then look to see if those setup methods
        //    // create mocks and stubs and assign them to instance fields.
        //    foreach (var member in node.Members)
        //    {
        //        if (member is Method)
        //        {
        //            foreach (var attribute in member.Attributes)
        //            {
        //                if (attribute.Type.ConstructorName.Name == "SetUpAttribute")
        //                {
        //                    InstructionCollection coll = ((Method)member).Instructions;

        //                    int instructionNumber = 0;

        //                    foreach (var instruction in coll)
        //                    {
        //                        if ((instruction.OpCode == OpCode.Call) &&
        //                            (instruction.Value.ToString().StartsWith(RhinoMocksGenerateMock)))
        //                        {
        //                            // Since we are in a setup method, the next instruction MUST BE a STFLD
        //                            // instruction to store the result of the call to GenerateMock in a
        //                            // field.
        //                            Instruction nextInstruction = coll[instructionNumber + 1];

        //                            string fieldName = ((Field)nextInstruction.Value).FullName;

        //                            // If the current field name exists in the list of class instance
        //                            // fields, then the current field is storing an instance of a mock
        //                            // and it will be used in test methods.
        //                            if (_classInstanceFields.Contains(fieldName))
        //                            {
        //                                _fieldsThatContainMocks.Add(fieldName);
        //                            }
        //                        }
        //                        else if ((instruction.OpCode == OpCode.Call) &&
        //                                 (instruction.Value.ToString().StartsWith(RhinoMocksGenerateStub)))
        //                        {
        //                            // Since we are in a setup method, the next instruction MUST BE a STFLD
        //                            // instruction to store the result of the call to GenerateStub in a
        //                            // field.
        //                            Instruction nextInstruction = coll[instructionNumber + 1];

        //                            string fieldName = ((Field)nextInstruction.Value).FullName;

        //                            // If the current field name exists in the list of class instance
        //                            // fields, then the current field is storing an instance of a stub
        //                            // and it will be used in test methods.
        //                            if (_classInstanceFields.Contains(fieldName))
        //                            {
        //                                _fieldsThatContainStubs.Add(fieldName);
        //                            }                                    
        //                        }

        //                        instructionNumber++;
        //                    }
        //                }
        //            }
        //        }
        //    }


        //    // Now we can examine test methods now that we have checked fields and setup methods.
        //    foreach (var member in node.Members)
        //    {
        //        if (member is Method)
        //        {
        //            Method currentMethod = (Method)member;

        //            foreach (var attribute in member.Attributes)
        //            {
        //                if (attribute.Type.ConstructorName.Name == "TestAttribute")
        //                {
        //                    // It is easier to process a stack than a collection because
        //                    // we can eliminate (pop) instructions that don't interest
        //                    // us. When know we are done when the stack is empty.
        //                    Stack<Instruction> instructionStack =
        //                        GetInstructionStackFromInstructionCollection(currentMethod.Instructions);

        //                    IList<SrlInstruction> instructions = GetInstructionList(currentMethod.Instructions);

        //                    while (instructionStack.Count != 0)
        //                    {
        //                        Instruction currentInstruction = instructionStack.Peek();

        //                        switch (currentInstruction.OpCode)
        //                        {
        //                            case OpCode.Ldfld:
        //                                // LdFld means we may be loading a mock or stub created
        //                                // in a setup method.
        //                                ProcessOpcodeLdFld(instructionStack, currentMethod.Name.Name);
        //                                break;
        //                            case OpCode.Call:
        //                                ProcessOpcodeCall(instructionStack, currentMethod.Name.Name);
        //                                break;
                                        
        //                            default:
        //                                // The current instruction is not relevant to our search.
        //                                // Process the next instruction.
        //                                instructionStack.Pop();
        //                                break;
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }

        //    return Problems;
        //}



        

        #region Private Instance Helper Methods

        //private void ProcessOpcodeCall(Stack<Instruction> instructions, string currentMethodName)
        //{
        //    Instruction currentInstruction = instructions.Pop();

        //    if (currentInstruction.Value.ToString().StartsWith(RhinoMocksGenerateStub))
        //    {
        //        Instruction nextInstrunction = instructions.Peek();
        //        string localVariableLocation = string.Empty;

        //        switch (nextInstrunction.OpCode)
        //        {
        //            case OpCode.Stloc:
        //                break;
        //            case OpCode.Stloc_0:
        //                localVariableLocation = "0";
        //                break;
        //            case OpCode.Stloc_1:
        //                localVariableLocation = "1";
        //                break;
        //            case OpCode.Stloc_2:
        //                localVariableLocation = "2";
        //                break;
        //            case OpCode.Stloc_3:
        //                localVariableLocation = "3";
        //                break;
        //            case OpCode.Stloc_S:
        //                localVariableLocation = ((Local) nextInstrunction.Value).Name.Name;
        //                break;
        //        }

        //        _localsThatContainStubs.Add(localVariableLocation);

        //        instructions.Pop();
        //    }

        //    if (currentInstruction.Value.ToString().Contains("Expect"))
        //    {
        //        int x = 5;
        //    }

        //}


        //private void ProcessOpcodeLdFld(Stack<Instruction> instructions, string currentMethodName)
        //{
        //    Instruction currentInstruction = instructions.Pop();
            
        //    if (_fieldsThatContainStubs.Contains(currentInstruction.Value.ToString()))
        //    {
        //        string currentFieldName = currentInstruction.Value.ToString().Split('.').Last();

        //        Instruction nextInstruction = instructions.Peek();

        //        if ((nextInstruction.OpCode == OpCode.Call) &&
        //            (nextInstruction.Value.ToString().StartsWith(RhinoMocksVerifyAllExpectations)))
        //        {
        //            // Get ready to process the next instruction.
        //            instructions.Pop();
        //            Problem prob = new Problem(GetNamedResolution("VerifyAllOnStub",
        //                new object[] { currentMethodName, currentFieldName }));
        //            Problems.Add(prob);

        //            return;
        //        }




        //    }
        //    else if (_fieldsThatContainMocks.Contains(currentInstruction.Value.ToString()))
        //    {
        //        string currentFieldName = currentInstruction.Value.ToString().Split('.').Last();

        //        while (instructions.Count != 0)
        //        {
        //            currentInstruction = instructions.Pop();

        //            if (currentInstruction.OpCode != OpCode.Call)
        //            {
        //                instructions.Pop();
        //                continue;
        //            }

        //            // If we get here we found a call. Now check if the call is invalid.
        //            if (currentInstruction.Value.ToString().Contains("Rhino.Mocks.RhinoMocksExtensions.Stub<"))
        //            {
        //                Problem prob = new Problem(GetNamedResolution("StubOnMock",
        //                    new object[] { currentMethodName, currentFieldName }));
        //                Problems.Add(prob);
        //                break;
        //            }
        //        }
        //    }
        //}

        #endregion
    }
}
﻿//
// DoNotInvokeRhinoMocksVerifyAllExpectationWithoutSettingExpectations.cs
//
// Product:
//
// Component: Srl.FxCop.CustomDeveloperTestRules
//
// Description: Represents the logic that detects when a Rhino Mocks mock or stub is invoked with VerifyAllExpectatons,
//              but no expectations have been set on the mock or stub.
//              The helper is isolated from the FxCop environment to make the helper logic unit testable.
//
// Author: Scott Lurowist
//




#region Using Directives

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.FxCop.Sdk;
using Srl.FxCop.CustomRuleSdk;

#endregion




namespace Srl.FxCop.CustomDeveloperTestRules.Helpers
{
    /// <summary>
    /// Represents the logic that detects when a Rhino Mocks mock or stub is invoked with VerifyAllExpectatons,
    /// but no expectations have been set on the mock or stub.
    /// The helper is isolated from the FxCop environment to make the helper logic unit testable.
    /// </summary>
    public class DoNotInvokeRhinoMocksVerifyAllExpectationWithoutSettingExpectations
    {
        /// <summary>
        /// Checks if RhinoMocks's VerifyAllExpectations method is invoked on a stub or mock and 
        /// not expectations are set.
        /// </summary>
        /// <param name="methodName">
        /// The name of the method that is currently being procesed by FxCop.
        /// </param>
        /// <param name="testMethodInstructions">
        /// A list of CustomInstruction that represents the instructions for the test method that
        /// FxCop is analyzing.
        /// </param>
        public IList<CustomProblem> CheckIfRhinoMocksVerifyAllExpectationsIsInvokedAndNoExpecationsAreSet(String methodName,
            /*IList<CustomInstruction> setupMethodInstructions,*/
            IList<CustomInstruction> testMethodInstructions)
        {
            if (methodName == "TestMethodWhereVerifyAllExpectationsIsInvokedOnTwoMocksButOneExpectationIsSet")
            {
                Srl.FxCop.CustomRuleSdk.DevTools.Instructions.WriteInstructionListForMethodToTextFile(testMethodInstructions,
                    @"c:\users\ex6m1sk\desktop\instructions.txt");
            }

            IList<CustomProblem> problemsFound = new List<CustomProblem>();

            IList<string> mockOrStubsInvokingExpectList = new List<string>();

            int instructionCounter = 0;

            foreach (var customInstruction in testMethodInstructions)
            {
                if (customInstruction.OpCode == OpCode.Call &&
                    customInstruction.Value.ToString().Contains("Rhino.Mocks.RhinoMocksExtensions.Expect"))
                {
                    // The Expect method is an extension method. So, the first argument to the Call opcode
                    // will be the mock or stub instance. The second arg will the be the method to call
                    // on the mock or stub. This appears as a lamda expression in the original source code.
                    // Let us find these arguments in our set of customInstruction.
                    int expectCallOffset = customInstruction.Offset;

                    // The previous instruction should be our lamda expresion.
                    int lamdaExpressionOffset = testMethodInstructions[instructionCounter - 1].Offset;

                    // Find the branch instruction that branched to lamdaExpressionOffset. That branch
                    // instruction checks that the delegate that represents the lamda expression does
                    // indeed exist. Value on the instruction object will be the offset.
                    int count = 0;

                    var testMethodInstructionsCopy = testMethodInstructions.ToArray();

                    foreach (var instruction in testMethodInstructionsCopy)
                    {
                        if (instruction.OpCode == OpCode.Brtrue_S &&
                            instruction.Value.ToString() == Convert.ToString(lamdaExpressionOffset))
                        {
                            // The previous instruction will load the lamda expression onto the VES.
                            // The instruction before that will load the mock or stub onto the VES.
                            string mockOrStubName =
                                testMethodInstructionsCopy[count - 2].Value.ToString().Split('.').Last().TrimEnd('}');

                            mockOrStubsInvokingExpectList.Add(mockOrStubName);

                            break;
                        }

                        count++;
                    }
                }

                // Ldfld will load a field and if the next instruction is a Call, then it will
                // invoke a method on the field just loaded.
                if (customInstruction.OpCode == OpCode.Ldfld &&
                    testMethodInstructions[instructionCounter + 1].OpCode == OpCode.Call &&
                    testMethodInstructions[instructionCounter + 1].Value.ToString().Contains("VerifyAllExpectations"))
                {
                    // Now check if the field is a stub.
                    var fieldName = customInstruction.Value.ToString().Split('.').Last().TrimEnd('}');

                    if (!mockOrStubsInvokingExpectList.Contains(fieldName))
                    {
                        CustomProblem problem = new CustomProblem();
                        problem.ResolutionName = "VerifyAllExpectationsWithoutExpect";
                        problem.ResolutionArguments = new string[] { methodName, fieldName };

                        problemsFound.Add(problem);                        
                    }
                }

                instructionCounter++;
            }

            return problemsFound;
        }
    }
}
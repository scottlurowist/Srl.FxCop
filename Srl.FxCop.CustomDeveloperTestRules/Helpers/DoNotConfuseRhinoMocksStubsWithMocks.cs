﻿//
// DoNotConfuseRhinoMocksStubsWithMocksHelper.cs
//
// Product:
//
// Component: Srl.FxCop.CustomDeveloperTestRules
//
// Description: Represents the logic that detects when a Rhino Mocks stub is confused with a Rhino Mocks mock.
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
    /// Represents the logic that detects when a Rhino Mocks stub is confused with a Rhino Mocks mock.
    /// The helper is isolated from the FxCop environment to make the helper logic unit testable.
    /// </summary>
    public class DoNotConfuseRhinoMocksStubsWithMocks
    {
        /// <summary>
        /// Checks if RhinoMocks's VerifyAllExpectations model is called on a field stub.
        /// </summary>
        /// <param name="methodName">
        /// The name of the method that is currently being procesed by FxCop.
        /// </param>
        /// <param name="setupMethodInstructions">
        /// A list of CustomInstruction that represents the instructions for a setup method, if
        /// a setup method exists for the test.
        /// </param>
        /// <param name="testMethodInstructions">
        /// A list of CustomInstruction that represents the instructions for the test method that
        /// FxCop is analyzing.
        /// </param>
        public IList<CustomProblem> CheckIfRhinoMocksVerifyAllExpectationsIsInvokedOnAFieldThatIsAStub(String methodName,
            IList<CustomInstruction> setupMethodInstructions,
            IList<CustomInstruction> testMethodInstructions)
        {
            IList<CustomProblem> problemsFound = new List<CustomProblem>();

            int instructionCounter = 0;

            foreach (var customInstruction in testMethodInstructions)
            {
                // Ldfld will load a field and if the next instruction is a Call, then it will
                // invoke a method on the field just loaded.
                if (customInstruction.OpCode == OpCode.Ldfld &&
                    testMethodInstructions[instructionCounter + 1].OpCode == OpCode.Call &&
                    testMethodInstructions[instructionCounter + 1].Value.ToString().Contains("VerifyAllExpectations"))
                {
                    // Now check if the field is a stub.
                    var fieldName = customInstruction.Value.ToString().Split('.').Last();

                    int setupInstructionCounter = 0;

                    foreach (var setupMethodInstruction in setupMethodInstructions)
                    {
                        if (setupMethodInstruction.OpCode == OpCode.Call &&
                            setupMethodInstruction.Value.ToString().Contains("GenerateStub"))
                        {
                            // The next instructions MUST BE a stfld to store the new
                            // stub in the field.
                            var nextInstruction = setupMethodInstructions[setupInstructionCounter + 1];

                            if (nextInstruction.Value.ToString().Contains(fieldName))
                            {
                                CustomProblem problem = new CustomProblem();
                                problem.ResolutionName = "VerifyAllOnStub";
                                problem.ResolutionArguments = new string[] {methodName, fieldName};

                                problemsFound.Add(problem);

                                break;
                            }
                        }

                        setupInstructionCounter++;
                    }
                }

                instructionCounter++;
            }

            return problemsFound;
        }


        /// <summary>
        /// Checks if RhinoMocks's VerifyAllExpectations model is called on a local stub.
        /// </summary>
        /// <param name="methodName">
        /// The name of the method that is currently being procesed by FxCop.
        /// </param>
        /// <param name="setupMethodInstructions">
        /// A list of CustomInstruction that represents the instructions for a setup method, if
        /// a setup method exists for the test.
        /// </param>
        /// <param name="testMethodInstructions">
        /// A list of CustomInstruction that represents the instructions for the test method that
        /// FxCop is analyzing.
        /// </param>
        public IList<CustomProblem> CheckIfRhinoMocksVerifyAllExpectationsIsInvokedOnALocalThatIsAStub(String methodName,
            IList<CustomInstruction> setupMethodInstructions,
            IList<CustomInstruction> testMethodInstructions)
        {
            IList<CustomProblem> problemsFound = new List<CustomProblem>();

            IList<string> localStubNames = new List<string>();

            int currentInstructionIndex = 0;

            foreach (var customInstruction in testMethodInstructions)
            {
                if (customInstruction.OpCode == OpCode.Call &&
                    customInstruction.Value.ToString().Contains("GenerateStub") &&
                    testMethodInstructions[currentInstructionIndex + 1].Value is CustomLocal)
                {
                    // The next instruction MUST store the result of the GenerateStub call in
                    // a local variable.
                    localStubNames.Add((testMethodInstructions[currentInstructionIndex + 1].Value as CustomLocal).Name);
                    
                    currentInstructionIndex++;
                    continue;
                }

                if (customInstruction.Value is CustomLocal &&
                    testMethodInstructions[currentInstructionIndex + 1].OpCode == OpCode.Call &&
                    testMethodInstructions[currentInstructionIndex + 1].Value.ToString().Contains("VerifyAllExpectations") &&
                    localStubNames.Contains(((CustomLocal)customInstruction.Value).Name))
                {
                    CustomProblem problem = new CustomProblem();
                    problem.ResolutionName = "VerifyAllOnStub";
                    problem.ResolutionArguments = new string[] { methodName, ((CustomLocal)customInstruction.Value).Name };

                    problemsFound.Add(problem);                                     
                }

                currentInstructionIndex++;
            }

            return problemsFound;
        }


        /// <summary>
        /// Checks if RhinoMocks's VerifyAllExpectations model is called on a field stub.
        /// </summary>
        /// <param name="methodName">
        /// The name of the method that is currently being procesed by FxCop.
        /// </param>
        /// <param name="setupMethodInstructions">
        /// A list of CustomInstruction that represents the instructions for a setup method, if
        /// a setup method exists for the test.
        /// </param>
        /// <param name="testMethodInstructions">
        /// A list of CustomInstruction that represents the instructions for the test method that
        /// FxCop is analyzing.
        /// </param>
        public IList<CustomProblem> CheckIfRhinoMocksExpectIsInvokedOnAFieldThatIsAStub(String methodName,
            IList<CustomInstruction> setupMethodInstructions,
            IList<CustomInstruction> testMethodInstructions)
        {
            IList<CustomProblem> problemsFound = new List<CustomProblem>();

            int instructionCounter = 0;

            foreach (var customInstruction in testMethodInstructions)
            {
                // Ldfld will load a field and if the next instruction is a Call, then it will
                // invoke a method on the field just loaded.
                if (customInstruction.OpCode == OpCode.Call && 
                    customInstruction.Value.ToString().Contains("Rhino.Mocks.RhinoMocksExtensions.Expect"))
                {
                    int x = 4;

                    // The Expect method is an extension method. So, the first argument to the Call opcode
                    // will be the mock or stub instance. The second arg will the be the method to call
                    // on the mock or stub. This appears as a lamda expression in the original source code.
                    // Let us find these arguments in our set of customInstruction.
                    int expectCallOffset = customInstruction.Offset;
                    
                    // The previous instruction should be our lamda expresion.
                    int lamdaExpressionOFfset = testMethodInstructions[instructionCounter - 1].Offset;

                    // Find the branch instruction that branched to lamdaExpressionOffset. That branch
                    // instruction checks that the delegate that represents the lamda expression does
                    // indeed exist. Value on the instruction object will be the offset.
                    int count = 0;

                    foreach (var testMethodInstruction in testMethodInstructions)
                    {
                        if (testMethodInstruction.OpCode == OpCode.Brtrue_S &&
                            testMethodInstruction.Value.ToString() == Convert.ToString(lamdaExpressionOFfset))
                        {
                            // The previous instruction will load the lamda expression onto the VES.
                            // The instruction before that will load the mock or stub onto the VES.
                            string mockOrStubName =
                                testMethodInstructions[count - 2].Value.ToString().Split('.').Last().TrimEnd('}');
                        }

                        count++;
                    }
                }

                instructionCounter++;
            }

            return problemsFound;
        }
    }
}
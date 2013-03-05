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
                    var fieldName = customInstruction.Value.ToString().Split('.').Last().TrimEnd('}');

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
            // CanLoadClaimsPresenter
            // TestMonitorBatchTimeoutException
            if (methodName == "TestMonitorBatchTimeoutException")
            {
                Srl.FxCop.CustomRuleSdk.DevTools.Instructions.WriteInstructionListForMethodToTextFile(testMethodInstructions,
                    @"c:\users\ex6m1sk\desktop\TestMonitorBatchTimeoutException.txt");
                Srl.FxCop.CustomRuleSdk.DevTools.Instructions.GenerateCSharpCodeFromInstructionListForUnitTests(testMethodInstructions,
                    @"c:\users\ex6m1sk\desktop\TestMonitorBatchTimeoutException.cs.txt");
            }

            IList<CustomProblem> problemsFound = new List<CustomProblem>();

            foreach (var customInstruction in testMethodInstructions)
            {
                // Ldfld will load a field and if the next instruction is a Call, then it will
                // invoke a method on the field just loaded.
                if (customInstruction.OpCode == OpCode.Call && 
                    customInstruction.Value.ToString().Contains("Rhino.Mocks.RhinoMocksExtensions.Expect"))
                {
                    CustomInstruction extensionMethodTargetInstruction = 
                        CommonHelpers.GetInstructionThatLoadsTheTargetOfAnExtensionMethod(customInstruction,
                                                                                                   testMethodInstructions);

                    string mockOrStubName =
                        CommonHelpers.GetVariableNameFromInstructionValue(extensionMethodTargetInstruction);

                    int setupInstructionCounter = 0;

                    foreach (var setupMethodInstruction in setupMethodInstructions)
                    {
                        if (setupMethodInstruction.OpCode == OpCode.Call &&
                            setupMethodInstruction.Value.ToString().Contains("GenerateStub"))
                        {
                            // The next instructions MUST BE a stfld to store the new
                            // stub in the field.
                            var nextInstruction = setupMethodInstructions[setupInstructionCounter + 1];

                            if (nextInstruction.Value.ToString().Contains(mockOrStubName))
                            {
                                CustomProblem problem = new CustomProblem();
                                problem.ResolutionName = "ExpectOnStub";
                                problem.ResolutionArguments = new string[] { methodName, mockOrStubName };

                                problemsFound.Add(problem);

                                break;
                            }
                        }

                        setupInstructionCounter++;
                    }
                }
            }

            return problemsFound;
        }
    }
}
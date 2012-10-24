﻿﻿//
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
            IList<CustomProblem> problemsFound = new List<CustomProblem>();

            IList<string> mockOrStubsInvokingExpectList = new List<string>();

            int instructionCounter = 0;

            foreach (var customInstruction in testMethodInstructions)
            {
                if (customInstruction.OpCode == OpCode.Ldfld &&
                    testMethodInstructions[instructionCounter + 1].OpCode == OpCode.Call &&
                    testMethodInstructions[instructionCounter + 1].Value.ToString().Contains("Rhino.Mocks.RhinoMocksExtensions.Expect"))
                {
                    mockOrStubsInvokingExpectList.Add(testMethodInstructions[instructionCounter + 1]
                        .Value.ToString().Split('.').Last().TrimEnd('}'));
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
                        problem.ResolutionName = "";
                        problem.ResolutionArguments = new string[] { methodName, fieldName };

                        problemsFound.Add(problem);                        
                    }

                    //foreach (var setupMethodInstruction in setupMethodInstructions)
                    //{
                    //    if (setupMethodInstruction.OpCode == OpCode.Call &&
                    //        setupMethodInstruction.Value.ToString().Contains("GenerateStub"))
                    //    {
                    //        // The next instructions MUST BE a stfld to store the new
                    //        // stub in the field.
                    //        var nextInstruction = setupMethodInstructions[setupInstructionCounter + 1];

                    //        if (nextInstruction.Value.ToString().Contains(fieldName))
                    //        {
                    //            CustomProblem problem = new CustomProblem();
                    //            problem.ResolutionName = "VerifyAllOnStub";
                    //            problem.ResolutionArguments = new string[] {methodName, fieldName};

                    //            problemsFound.Add(problem);

                    //            break;
                    //        }
                    //    }

                    //    setupInstructionCounter++;
                    //}
                }

                instructionCounter++;
            }

            return problemsFound;
        }
    }
}
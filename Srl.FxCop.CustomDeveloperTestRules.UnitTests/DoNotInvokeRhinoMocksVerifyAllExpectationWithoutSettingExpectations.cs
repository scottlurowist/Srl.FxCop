//
// DoNotInvokeRhinoMocksVerifyAllExpectationWithoutSettingExpectations.cs
//
// Product:
//
// Component: Srl.FxCop.CustomDeveloperTestRules.UnitTests
//
// Description: Represents a test harness for the DoNotInvokeRhinoMocksVerifyAllExpectationWithoutSettingExpectations
//              custom developer test rule helper.
//
// Author: Scott Lurowist
//




#region Using Directives

using Microsoft.FxCop.Sdk;
using System.Collections.Generic;
using NUnit.Framework;
using Srl.FxCop.CustomRuleSdk;

#endregion




namespace Srl.FxCop.CustomDeveloperTestRules.UnitTests
{
    /// <summary>
    /// Represents a test harness for the DoNotInvokeRhinoMocksVerifyAllExpectationWithoutSettingExpectations
    /// custom developer test rule helper.
    /// </summary>
    [TestFixture]
    public class DoNotInvokeRhinoMocksVerifyAllExpectationWithoutSettingExpectations
    {
        [Test]
        public void CanRaiseProblemWhenVerifyAllExpectationsIsInvokedAndNoExpectationIsSet()
        {
            // Arrange
            IList<CustomInstruction> instructionsForMethod =
                GetInstructionsForCanRaiseProblemWhenVerifyAllExpectationsIsInvokedAndNoExpectationIsSet();

            var helper = new Helpers.DoNotInvokeRhinoMocksVerifyAllExpectationWithoutSettingExpectations();

            const string testMethodBeingAnalyzed =
                "TestMethodWhereVerifyAllExpectationsOnAMockIsInvokedAndExpectationsAreNotSet";


            // Act
            IList<CustomProblem> problemsFound = helper.
                CheckIfRhinoMocksVerifyAllExpectationsIsInvokedAndNoExpecationsAreSet(
                    testMethodBeingAnalyzed,
                    instructionsForMethod);


            // Assert
            const int expectedNumberOfProblemsFound = 1;
            const string expectedResolutionNameInXmlMetadataFile = "VerifyAllExpectationsWithoutExpect";
            const string expectedFieldNameArgument = "_barMock"; // The field that has the problem.

            Assert.That(problemsFound.Count, Is.EqualTo(expectedNumberOfProblemsFound));
            Assert.That(problemsFound[0].ResolutionName, Is.EqualTo(expectedResolutionNameInXmlMetadataFile));
            Assert.That(problemsFound[0].ResolutionArguments.Length, Is.EqualTo(2));
            Assert.That(problemsFound[0].ResolutionArguments[0], Is.EqualTo(testMethodBeingAnalyzed));
            Assert.That(problemsFound[0].ResolutionArguments[1], Is.EqualTo(expectedFieldNameArgument));
        }


        [Test]
        public void CannotRaiseProblemWhenVerifyAllExpectationsIsInvokedAndAnExpectationIsSet()
        {
            // Arrange
            IList<CustomInstruction> instructionsForMethod =
                GetInstructionsForCannotRaiseProblemWhenVerifyAllExpectationsIsInvokedAndAnExpectationIsSet();

            var helper = new Helpers.DoNotInvokeRhinoMocksVerifyAllExpectationWithoutSettingExpectations();

            const string testMethodBeingAnalyzed =
                "TestMethodWhereVerifyAllExpectationsOnAMockIsInvokedAndAnExpectationIsSet";


            // Act
            IList<CustomProblem> problemsFound = helper.
                CheckIfRhinoMocksVerifyAllExpectationsIsInvokedAndNoExpecationsAreSet(
                    testMethodBeingAnalyzed,
                    instructionsForMethod);


            // Assert
            const int expectedNumberOfProblemsFound = 0;

            Assert.That(problemsFound.Count, Is.EqualTo(expectedNumberOfProblemsFound));
        }


        [Test]
        public void CanRaiseProblemWhenVerifyAllExpectationsIsInvokedOnTwoMocksAndOneExpectationIsSet()
        {
            // Arrange
            IList<CustomInstruction> instructionsForMethod =
                GetInstructionsForCanRaiseProblemWhenVerifyAllExpectationsIsInvokedOnTwoMocksAndOneExpectationIsSet();

            var helper = new Helpers.DoNotInvokeRhinoMocksVerifyAllExpectationWithoutSettingExpectations();

            const string testMethodBeingAnalyzed =
                "TestMethodWhereVerifyAllExpectationsIsInvokedOnTwoMocksButOneExpectationIsSet";


            // Act
            IList<CustomProblem> problemsFound = helper.
                CheckIfRhinoMocksVerifyAllExpectationsIsInvokedAndNoExpecationsAreSet(
                    testMethodBeingAnalyzed,
                    instructionsForMethod);


            // Assert
            const int expectedNumberOfProblemsFound = 1;
            const string expectedResolutionNameInXmlMetadataFile = "VerifyAllExpectationsWithoutExpect";
            const string expectedFieldNameArgument = "_fooMock"; // The field that has the problem.

            Assert.That(problemsFound.Count, Is.EqualTo(expectedNumberOfProblemsFound));
            Assert.That(problemsFound[0].ResolutionName, Is.EqualTo(expectedResolutionNameInXmlMetadataFile));
            Assert.That(problemsFound[0].ResolutionArguments.Length, Is.EqualTo(2));
            Assert.That(problemsFound[0].ResolutionArguments[0], Is.EqualTo(testMethodBeingAnalyzed));
            Assert.That(problemsFound[0].ResolutionArguments[1], Is.EqualTo(expectedFieldNameArgument));
        }




        #region Private Instance Helper Methods

        /// <summary>
        /// Gets the instructions for the test CanRaiseProblemWhenVerifyAllExpectationsIsInvokedAndNoExpectionIsSet.
        /// </summary>
        /// <returns>
        /// A list of instructions that was empirically obtained from
        /// DoNotInvokeRhinoMocksVerifyAllExpectationWithoutSettingExpectationsTarget.cs
        /// </returns>
        IList<CustomInstruction> GetInstructionsForCanRaiseProblemWhenVerifyAllExpectationsIsInvokedAndNoExpectationIsSet()
        {
            IList<CustomInstruction> instructionList = new List<CustomInstruction>();

            // CIL Instruction 1.
            CustomInstruction instruction = new CustomInstruction();
            instruction.Offset = 0;
            instruction.OpCode = OpCode._Locals;
            instruction.Value = "{Microsoft.FxCop.Sdk.LocalCollection}";

            instructionList.Add(instruction);

            // CIL Instruction 2.
            instruction = new CustomInstruction();
            instruction.Offset = 0;
            instruction.OpCode = OpCode.Nop;
            instruction.Value = null;

            instructionList.Add(instruction);

            // CIL Instruction 3.
            instruction = new CustomInstruction();
            instruction.Offset = 1;
            instruction.OpCode = OpCode.Ldarg_0;
            instruction.Value =
                "{Microsoft.FxCop.Sdk.ClassNode:Srl.FxCop.CustomDeveloperTestRules.TestTargets.DoNotInvokeRhinoMocksVerifyAllExpectationsWithoutSettingExpectationsTarget this}";

            instructionList.Add(instruction);

            // CIL Instruction 4.
            instruction = new CustomInstruction();
            instruction.Offset = 2;
            instruction.OpCode = OpCode.Ldfld;
            instruction.Value =
                "{Srl.FxCop.CustomDeveloperTestRules.TestTargets.DoNotInvokeRhinoMocksVerifyAllExpectationsWithoutSettingExpectationsTarget._barMock}";

            instructionList.Add(instruction);

            // CIL Instruction 5.
            instruction = new CustomInstruction();
            instruction.Offset = 7;
            instruction.OpCode = OpCode.Call;
            instruction.Value =
                "{Rhino.Mocks.RhinoMocksExtensions.VerifyAllExpectations}";

            instructionList.Add(instruction);

            // CIL Instruction 6.
            instruction = new CustomInstruction();
            instruction.Offset = 12;
            instruction.OpCode = OpCode.Nop;
            instruction.Value = null;

            instructionList.Add(instruction);

            // CIL Instruction 7.
            instruction = new CustomInstruction();
            instruction.Offset = 13;
            instruction.OpCode = OpCode.Ret;
            instruction.Value = null;

            instructionList.Add(instruction);

            return instructionList;
        }


        /// <summary>
        /// Gets the instructions for the test CannotRaiseProblemWhenVerifyAllExpectationsIsInvokedAndAnExpectationIsSet.
        /// </summary>
        /// <returns>
        /// A list of instructions that was empirically obtained from
        /// DoNotInvokeRhinoMocksVerifyAllExpectationWithoutSettingExpectationsTarget.cs
        /// </returns>
        IList<CustomInstruction> GetInstructionsForCannotRaiseProblemWhenVerifyAllExpectationsIsInvokedAndAnExpectationIsSet()
        {
            IList<CustomInstruction> instructionList = new List<CustomInstruction>();

            // CIL Instruction 1.
            CustomInstruction instruction = new CustomInstruction();
            instruction.Offset = 0;
            instruction.OpCode = OpCode._Locals;
            instruction.Value = "{Microsoft.FxCop.Sdk.LocalCollection}";

            instructionList.Add(instruction);

            // CIL Instruction 2.
            instruction = new CustomInstruction();
            instruction.Offset = 0;
            instruction.OpCode = OpCode.Nop;
            instruction.Value = null;

            instructionList.Add(instruction);

            // CIL Instruction 3.
            instruction = new CustomInstruction();
            instruction.Offset = 1;
            instruction.OpCode = OpCode.Ldarg_0;
            instruction.Value =
                "{Microsoft.FxCop.Sdk.ClassNode:Srl.FxCop.CustomDeveloperTestRules.TestTargets.DoNotInvokeRhinoMocksVerifyAllExpectationsWithoutSettingExpectationsTarget this}";

            instructionList.Add(instruction);

            // CIL Instruction 4.
            instruction = new CustomInstruction();
            instruction.Offset = 2;
            instruction.OpCode = OpCode.Ldfld;
            instruction.Value =
                "{Srl.FxCop.CustomDeveloperTestRules.TestTargets.DoNotInvokeRhinoMocksVerifyAllExpectationsWithoutSettingExpectationsTarget._barMock}";

            instructionList.Add(instruction);

            // CIL Instruction 5.
            instruction = new CustomInstruction();
            instruction.Offset = 7;
            instruction.OpCode = OpCode.Ldsfld;
            instruction.Value =
                "{Srl.FxCop.CustomDeveloperTestRules.TestTargets.DoNotInvokeRhinoMocksVerifyAllExpectationsWithoutSettingExpectationsTarget.CS$<>9__CachedAnonymousMethodDelegate1}";

            instructionList.Add(instruction);

            // CIL Instruction 6.
            instruction = new CustomInstruction();
            instruction.Offset = 12;
            instruction.OpCode = OpCode.Brtrue_S;
            instruction.Value = 33;

            instructionList.Add(instruction);

            // CIL Instruction 7.
            instruction = new CustomInstruction();
            instruction.Offset = 14;
            instruction.OpCode = OpCode.Ldnull;
            instruction.Value = null;

            instructionList.Add(instruction);

            // CIL Instruction 8.
            instruction = new CustomInstruction();
            instruction.Offset = 15;
            instruction.OpCode = OpCode.Ldftn;
            instruction.Value = 
                "{Srl.FxCop.CustomDeveloperTestRules.TestTargets.DoNotInvokeRhinoMocksVerifyAllExpectationsWithoutSettingExpectationsTarget.<TestMethodWhereVerifyAllExpectationsOnAMockIsInvokedAndExpectationsAreSet>b__0}";

            instructionList.Add(instruction);

            // CIL Instruction 9.
            instruction = new CustomInstruction();
            instruction.Offset = 21;
            instruction.OpCode = OpCode.Newobj;
            instruction.Value = "{System.Action<Srl.FxCop.CustomDeveloperTestRules.TestTargets.IBar>(Microsoft.FxCop.Sdk.ParameterCollection)}";

            instructionList.Add(instruction);

            // CIL Instruction 10.
            instruction = new CustomInstruction();
            instruction.Offset = 26;
            instruction.OpCode = OpCode.Stsfld;
            instruction.Value = "{Srl.FxCop.CustomDeveloperTestRules.TestTargets.DoNotInvokeRhinoMocksVerifyAllExpectationsWithoutSettingExpectationsTarget.CS$<>9__CachedAnonymousMethodDelegate1}";

            instructionList.Add(instruction);

            // CIL Instruction 11.
            instruction = new CustomInstruction();
            instruction.Offset = 31;
            instruction.OpCode = OpCode.Br_S;
            instruction.Value = 33;

            instructionList.Add(instruction);

            // CIL Instruction 12.
            instruction = new CustomInstruction();
            instruction.Offset = 33;
            instruction.OpCode = OpCode.Ldsfld;
            instruction.Value = "{Srl.FxCop.CustomDeveloperTestRules.TestTargets.DoNotInvokeRhinoMocksVerifyAllExpectationsWithoutSettingExpectationsTarget.CS$<>9__CachedAnonymousMethodDelegate1}";

            instructionList.Add(instruction);

            // CIL Instruction 13.
            instruction = new CustomInstruction();
            instruction.Offset = 38;
            instruction.OpCode = OpCode.Call;
            instruction.Value = "{Rhino.Mocks.RhinoMocksExtensions.Expect<Srl.FxCop.CustomDeveloperTestRules.TestTargets.IBar>}";

            instructionList.Add(instruction);

            // CIL Instruction 14.
            instruction = new CustomInstruction();
            instruction.Offset = 43;
            instruction.OpCode = OpCode.Pop;
            instruction.Value = null;

            instructionList.Add(instruction);

            // CIL Instruction 15.
            instruction = new CustomInstruction();
            instruction.Offset = 44;
            instruction.OpCode = OpCode.Ldarg_0;
            instruction.Value = 
                "{Microsoft.FxCop.Sdk.ClassNode:Srl.FxCop.CustomDeveloperTestRules.TestTargets.DoNotInvokeRhinoMocksVerifyAllExpectationsWithoutSettingExpectationsTarget this}";

            instructionList.Add(instruction);

            // CIL Instruction 16.
            instruction = new CustomInstruction();
            instruction.Offset = 45;
            instruction.OpCode = OpCode.Ldfld;
            instruction.Value =
                "{Srl.FxCop.CustomDeveloperTestRules.TestTargets.DoNotInvokeRhinoMocksVerifyAllExpectationsWithoutSettingExpectationsTarget._barMock}";

            instructionList.Add(instruction);

            // CIL Instruction 17.
            instruction = new CustomInstruction();
            instruction.Offset = 50;
            instruction.OpCode = OpCode.Call;
            instruction.Value =
                "{Rhino.Mocks.RhinoMocksExtensions.VerifyAllExpectations}";

            instructionList.Add(instruction);

            // CIL Instruction 18.
            instruction = new CustomInstruction();
            instruction.Offset = 55;
            instruction.OpCode = OpCode.Nop;
            instruction.Value = null;

            instructionList.Add(instruction);

            // CIL Instruction 19.
            instruction = new CustomInstruction();
            instruction.Offset = 56;
            instruction.OpCode = OpCode.Ret;
            instruction.Value = null;

            instructionList.Add(instruction);

            return instructionList;
        }


        /// <summary>
        /// Gets the instructions for the test CannotRaiseProblemWhenVerifyAllExpectationsIsInvokedAndAnExpectationIsSet.
        /// </summary>
        /// <returns>
        /// A list of instructions that was empirically obtained from
        /// DoNotInvokeRhinoMocksVerifyAllExpectationWithoutSettingExpectationsTarget.cs
        /// </returns>
        IList<CustomInstruction> GetInstructionsForCanRaiseProblemWhenVerifyAllExpectationsIsInvokedOnTwoMocksAndOneExpectationIsSet()
        {
            IList<CustomInstruction> instructionList = new List<CustomInstruction>();

            // CIL Instruction 1.
            CustomInstruction instruction = new CustomInstruction();
            instruction.Offset = 0;
            instruction.OpCode = OpCode._Locals;
            instruction.Value = "{Microsoft.FxCop.Sdk.LocalCollection}";

            instructionList.Add(instruction);

            // CIL Instruction 2.
            instruction = new CustomInstruction();
            instruction.Offset = 0;
            instruction.OpCode = OpCode.Nop;
            instruction.Value = null;

            instructionList.Add(instruction);

            // CIL Instruction 3.
            instruction = new CustomInstruction();
            instruction.Offset = 1;
            instruction.OpCode = OpCode.Ldarg_0;
            instruction.Value =
                "{Microsoft.FxCop.Sdk.ClassNode:Srl.FxCop.CustomDeveloperTestRules.TestTargets.DoNotInvokeRhinoMocksVerifyAllExpectationsWithoutSettingExpectationsTarget this}";

            instructionList.Add(instruction);

            // CIL Instruction 4.
            instruction = new CustomInstruction();
            instruction.Offset = 2;
            instruction.OpCode = OpCode.Ldfld;
            instruction.Value =
                "{Srl.FxCop.CustomDeveloperTestRules.TestTargets.DoNotInvokeRhinoMocksVerifyAllExpectationsWithoutSettingExpectationsTarget._barMock}";

            instructionList.Add(instruction);

            // CIL Instruction 5.
            instruction = new CustomInstruction();
            instruction.Offset = 7;
            instruction.OpCode = OpCode.Ldsfld;
            instruction.Value =
                "{Srl.FxCop.CustomDeveloperTestRules.TestTargets.DoNotInvokeRhinoMocksVerifyAllExpectationsWithoutSettingExpectationsTarget.CS$<>9__CachedAnonymousMethodDelegate1}";

            instructionList.Add(instruction);

            // CIL Instruction 6.
            instruction = new CustomInstruction();
            instruction.Offset = 12;
            instruction.OpCode = OpCode.Brtrue_S;
            instruction.Value = 33;

            instructionList.Add(instruction);

            // CIL Instruction 7.
            instruction = new CustomInstruction();
            instruction.Offset = 14;
            instruction.OpCode = OpCode.Ldnull;
            instruction.Value = null;

            instructionList.Add(instruction);

            // CIL Instruction 8.
            instruction = new CustomInstruction();
            instruction.Offset = 15;
            instruction.OpCode = OpCode.Ldftn;
            instruction.Value =
                "{Srl.FxCop.CustomDeveloperTestRules.TestTargets.DoNotInvokeRhinoMocksVerifyAllExpectationsWithoutSettingExpectationsTarget.<TestMethodWhereVerifyAllExpectationsOnAMockIsInvokedAndExpectationsAreSet>b__0}";

            instructionList.Add(instruction);

            // CIL Instruction 9.
            instruction = new CustomInstruction();
            instruction.Offset = 21;
            instruction.OpCode = OpCode.Newobj;
            instruction.Value = "{System.Action<Srl.FxCop.CustomDeveloperTestRules.TestTargets.IBar>(Microsoft.FxCop.Sdk.ParameterCollection)}";

            instructionList.Add(instruction);

            // CIL Instruction 10.
            instruction = new CustomInstruction();
            instruction.Offset = 26;
            instruction.OpCode = OpCode.Stsfld;
            instruction.Value = "{Srl.FxCop.CustomDeveloperTestRules.TestTargets.DoNotInvokeRhinoMocksVerifyAllExpectationsWithoutSettingExpectationsTarget.CS$<>9__CachedAnonymousMethodDelegate1}";

            instructionList.Add(instruction);

            // CIL Instruction 11.
            instruction = new CustomInstruction();
            instruction.Offset = 31;
            instruction.OpCode = OpCode.Br_S;
            instruction.Value = 33;

            instructionList.Add(instruction);

            // CIL Instruction 12.
            instruction = new CustomInstruction();
            instruction.Offset = 33;
            instruction.OpCode = OpCode.Ldsfld;
            instruction.Value = "{Srl.FxCop.CustomDeveloperTestRules.TestTargets.DoNotInvokeRhinoMocksVerifyAllExpectationsWithoutSettingExpectationsTarget.CS$<>9__CachedAnonymousMethodDelegate1}";

            instructionList.Add(instruction);

            // CIL Instruction 13.
            instruction = new CustomInstruction();
            instruction.Offset = 38;
            instruction.OpCode = OpCode.Call;
            instruction.Value = "{Rhino.Mocks.RhinoMocksExtensions.Expect<Srl.FxCop.CustomDeveloperTestRules.TestTargets.IBar>}";

            instructionList.Add(instruction);

            // CIL Instruction 14.
            instruction = new CustomInstruction();
            instruction.Offset = 43;
            instruction.OpCode = OpCode.Pop;
            instruction.Value = null;

            instructionList.Add(instruction);

            // CIL Instruction 15.
            instruction = new CustomInstruction();
            instruction.Offset = 44;
            instruction.OpCode = OpCode.Ldarg_0;
            instruction.Value =
                "{Microsoft.FxCop.Sdk.ClassNode:Srl.FxCop.CustomDeveloperTestRules.TestTargets.DoNotInvokeRhinoMocksVerifyAllExpectationsWithoutSettingExpectationsTarget this}";

            instructionList.Add(instruction);

            // CIL Instruction 16.
            instruction = new CustomInstruction();
            instruction.Offset = 45;
            instruction.OpCode = OpCode.Ldfld;
            instruction.Value =
                "{Srl.FxCop.CustomDeveloperTestRules.TestTargets.DoNotInvokeRhinoMocksVerifyAllExpectationsWithoutSettingExpectationsTarget._barMock}";

            instructionList.Add(instruction);

            // CIL Instruction 17.
            instruction = new CustomInstruction();
            instruction.Offset = 50;
            instruction.OpCode = OpCode.Call;
            instruction.Value =
                "{Rhino.Mocks.RhinoMocksExtensions.VerifyAllExpectations}";

            instructionList.Add(instruction);

            // CIL Instruction 18.
            instruction = new CustomInstruction();
            instruction.Offset = 55;
            instruction.OpCode = OpCode.Nop;
            instruction.Value = null;

            instructionList.Add(instruction);

            // CIL Instruction 19.
            instruction = new CustomInstruction();
            instruction.Offset = 56;
            instruction.OpCode = OpCode.Ldarg_0;
            instruction.Value = 
                "{Microsoft.FxCop.Sdk.ClassNode:Srl.FxCop.CustomDeveloperTestRules.TestTargets.DoNotInvokeRhinoMocksVerifyAllExpectationsWithoutSettingExpectationsTarget this}";

            instructionList.Add(instruction);

            // CIL Instruction 20.
            instruction = new CustomInstruction();
            instruction.Offset = 57;
            instruction.OpCode = OpCode.Ldfld;
            instruction.Value =
                "{Srl.FxCop.CustomDeveloperTestRules.TestTargets.DoNotInvokeRhinoMocksVerifyAllExpectationsWithoutSettingExpectationsTarget._fooMock}";

            instructionList.Add(instruction);

            // CIL Instruction 21.
            instruction = new CustomInstruction();
            instruction.Offset = 62;
            instruction.OpCode = OpCode.Call;
            instruction.Value = "{Rhino.Mocks.RhinoMocksExtensions.VerifyAllExpectations}";

            instructionList.Add(instruction);

            // CIL Instruction 22.
            instruction = new CustomInstruction();
            instruction.Offset = 67;
            instruction.OpCode = OpCode.Nop;
            instruction.Value = null;

            // CIL Instruction 23.
            instruction = new CustomInstruction();
            instruction.Offset = 68;
            instruction.OpCode = OpCode.Ret;
            instruction.Value = null;

            instructionList.Add(instruction);

            return instructionList;
        }

        #endregion
    }
}
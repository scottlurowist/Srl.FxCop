//
// DoNotConfuseRhinoMocksStubsWithMocksTests.cs
//
// Product:
//
// Component: Srl.FxCop.CustomDeveloperTestRules.UnitTests
//
// Description: Represents a test harness for the DoNotConfuseRhinoMocksStubsWithMocks custom 
//              developer test rule helper.
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
    /// Represents a test harness for the DoNotConfuseRhinoMocksStubsWithMocks custom 
    /// developer test rule.
    /// </summary>
    [TestFixture]
    public class DoNotConfuseRhinoMocksStubsWithMocksTests
    {
        [Test]
        public void CanRaiseProblemWhenAFieldStubIsInvokedWithVerifyAllExpectations()
        {
            // Arrange
            IList<CustomInstruction> setupMethodInstructions = GetListOfCustomInstructionForSetupMethod();

            IList<CustomInstruction> instructionsForMethod =
                GetInstructionsForCanRaiseProblemWhenAFieldStubIsUsedAsAMock();

            var helper = new Helpers.DoNotConfuseRhinoMocksStubsWithMocks();

            const string testMethodBeingAnalyzed = "TestMethodWhereAFieldStubIsInvokedWithVerifyAllExpectations";


            // Act
            IList<CustomProblem> problemsFound = helper.
                CheckIfRhinoMocksVerifyAllExpectationsIsInvokedOnAFieldThatIsAStub(
                    testMethodBeingAnalyzed,
                    setupMethodInstructions,
                    instructionsForMethod);


            // Assert
            const int expectedNumberOfProblemsFound = 1;
            const string expectedResolutionNameInXmlMetadataFile = "VerifyAllOnStub";
            const string expectedFieldNameArgument = "_barStub"; // The field that has the problem.

            Assert.That(problemsFound.Count, Is.EqualTo(expectedNumberOfProblemsFound));
            Assert.That(problemsFound[0].ResolutionName, Is.EqualTo(expectedResolutionNameInXmlMetadataFile));
            Assert.That(problemsFound[0].ResolutionArguments.Length, Is.EqualTo(2));
            Assert.That(problemsFound[0].ResolutionArguments[0], Is.EqualTo(testMethodBeingAnalyzed));
            Assert.That(problemsFound[0].ResolutionArguments[1], Is.EqualTo(expectedFieldNameArgument));
        }


        [Test]
        public void CanRaiseProblemWhenALocalStubIsIsInvokedWithVerifyAllExpectations()
        {
            // Arrange
            IList<CustomInstruction> setupMethodInstructions = GetListOfCustomInstructionForSetupMethod();

            IList<CustomInstruction> instructionsForMethod = 
                GetInstructionsForCanRaiseProblemWhenALocalStubIsUsedAsAMock();

            var helper = new Helpers.DoNotConfuseRhinoMocksStubsWithMocks();

            const string testMethodBeingAnalyzed = "TestMethodWhereALocalStubIsInvokedWithVerifyAllExpectations";


            // Act
            IList<CustomProblem> problemsFound = helper.
                CheckIfRhinoMocksVerifyAllExpectationsIsInvokedOnALocalThatIsAStub(
                    testMethodBeingAnalyzed,
                    setupMethodInstructions,
                    instructionsForMethod);


            // Assert
            const int expectedNumberOfProblemsFound = 1;
            const string expectedResolutionNameInXmlMetadataFile = "VerifyAllOnStub";
            const string expectedLocalNameArgument = "localStub"; // The local that has the problem.

            Assert.That(problemsFound.Count, Is.EqualTo(expectedNumberOfProblemsFound));
            Assert.That(problemsFound[0].ResolutionName, Is.EqualTo(expectedResolutionNameInXmlMetadataFile));
            Assert.That(problemsFound[0].ResolutionArguments.Length, Is.EqualTo(2));
            Assert.That(problemsFound[0].ResolutionArguments[0], Is.EqualTo(testMethodBeingAnalyzed));
            Assert.That(problemsFound[0].ResolutionArguments[1], Is.EqualTo(expectedLocalNameArgument));
        }


        [Test]
        public void CannotRaiseProblemWhenAFieldStubOnlyInvokesStub()
        {
            // Arrange
            IList<CustomInstruction> setupMethodInstructions = GetListOfCustomInstructionForSetupMethod();

            IList<CustomInstruction> instructionsForMethod =
                GetInstructionsForCannotRaiseProblemWhenAFieldStubOnlyInvokesStub();

            var helper = new Helpers.DoNotConfuseRhinoMocksStubsWithMocks();

            const string testMethodBeingAnalyzed = "TestMethodWhereAFieldStubIsInvokedWithStub";


            // Act
            IList<CustomProblem> problemsFound = helper.
                CheckIfRhinoMocksVerifyAllExpectationsIsInvokedOnAFieldThatIsAStub(
                    testMethodBeingAnalyzed,
                    setupMethodInstructions,
                    instructionsForMethod);


            // Assert
            const int expectedNumberOfProblemsFound = 0;  // We used a stub correctly.

            Assert.That(problemsFound.Count, Is.EqualTo(expectedNumberOfProblemsFound));
        }


        [Test]
        public void CanRaiseProblemWhenAFieldStubIsInvokedWithExpect()
        {
            // Arrange
            IList<CustomInstruction> setupMethodInstructions = GetListOfCustomInstructionForSetupMethod();

            IList<CustomInstruction> instructionsForMethod =
                GetInstructionsForCanRaiseProblemWhenAFieldStubIsInvokedWithExpect();

            var helper = new Helpers.DoNotConfuseRhinoMocksStubsWithMocks();

            const string testMethodBeingAnalyzed = "TestMethodWhereAFieldStubIsInvokedWithExpect";


            // Act
            IList<CustomProblem> problemsFound = helper.
                CheckIfRhinoMocksExpectIsInvokedOnAFieldThatIsAStub(
                    testMethodBeingAnalyzed,
                    setupMethodInstructions,
                    instructionsForMethod);


            // Assert
            const int expectedNumberOfProblemsFound = 1;
            const string expectedResolutionNameInXmlMetadataFile = "ExpectOnStub";
            const string expectedFieldNameArgument = "_barStub"; // The field that has the problem.

            Assert.That(problemsFound.Count, Is.EqualTo(expectedNumberOfProblemsFound));
            Assert.That(problemsFound[0].ResolutionName, Is.EqualTo(expectedResolutionNameInXmlMetadataFile));
            Assert.That(problemsFound[0].ResolutionArguments.Length, Is.EqualTo(2));
            Assert.That(problemsFound[0].ResolutionArguments[0], Is.EqualTo(testMethodBeingAnalyzed));
            Assert.That(problemsFound[0].ResolutionArguments[1], Is.EqualTo(expectedFieldNameArgument));          
        }


        #region Private Instance Helper Methods

        /// <summary>
        /// Gets the instructions for the test CanRaiseProblemWhenAFieldStubIsUsedAsAMock.
        /// </summary>
        /// <returns>
        /// A list of instructions that was empirically obtained from
        /// DoNotConfuseRhinoMocksStubsWithMocksTarget.cs
        /// </returns>
        IList<CustomInstruction> GetInstructionsForCanRaiseProblemWhenAFieldStubIsUsedAsAMock()
        {
            IList<CustomInstruction> instructionList = new List<CustomInstruction>();

            // CIL Instruction 1.
            CustomInstruction instruction = new CustomInstruction();
            instruction.Offset = 0;
            instruction.OpCode = OpCode._Locals;
            // TODO: Replace with a custom type.
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
            // TODO: Replace with a custom type.
            instruction.Value =
                "{Microsoft.FxCop.Sdk.ClassNode:Srl.FxCop.CustomDeveloperTestRules.TestTargets.DoNotConfuseRhinoMocksStubsWithMocksTarget this}";

            instructionList.Add(instruction);

            // CIL Instruction 4.
            instruction = new CustomInstruction();
            instruction.Offset = 2;
            instruction.OpCode = OpCode.Ldfld;
            // TODO: Replace with a custom type.
            instruction.Value =
                "{Srl.FxCop.CustomDeveloperTestRules.TestTargets.DoNotConfuseRhinoMocksStubsWithMocksTarget._barStub}";

            instructionList.Add(instruction);

            // CIL Instruction 5.
            instruction = new CustomInstruction();
            instruction.Offset = 7;
            instruction.OpCode = OpCode.Call;
            // TODO: Replace with a custom type.
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
        /// Generates the instructions for the setup method. These instructions are the actual
        /// instructions for the setup method in DoNoConfuseMocksWithStubsTarget.cs
        /// </summary>
        /// <returns>
        /// A list of instructions that was empirically obtained from
        /// DoNotConfuseRhinoMocksStubsWithMocksTarget.cs
        /// </returns>
        private IList<CustomInstruction> GetListOfCustomInstructionForSetupMethod()
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
            instruction.Value = "{Microsoft.FxCop.Sdk.ClassNode:Srl.FxCop.CustomDeveloperTestRules.TestTargets.DoNotConfuseRhinoMocksStubsWithMocksTarget this}";

            instructionList.Add(instruction);

            // CIL Instruction 4.
            instruction = new CustomInstruction();
            instruction.Offset = 2;
            instruction.OpCode = OpCode.Ldc_I4_0;
            instruction.Value = 0;

            instructionList.Add(instruction);

            // CIL Instruction 5.
            instruction = new CustomInstruction();
            instruction.Offset = 3;
            instruction.OpCode = OpCode.Newarr;
            // TODO:
            instruction.Value = "{Microsoft.FxCop.Sdk.ClassNode:System.Object}";

            instructionList.Add(instruction);

            // CIL Instruction 6.
            instruction = new CustomInstruction();
            instruction.Offset = 8;
            instruction.OpCode = OpCode.Call;
            // TODO:
            instruction.Value = "{Rhino.Mocks.MockRepository.GenerateStub<Srl.FxCop.CustomDeveloperTestRules.TestTargets.IBar>}";

            instructionList.Add(instruction);

            // CIL Instruction 7.
            instruction = new CustomInstruction();
            instruction.Offset = 13;
            instruction.OpCode = OpCode.Stfld;
            // TODO:
            instruction.Value = "{Srl.FxCop.CustomDeveloperTestRules.TestTargets.DoNotConfuseRhinoMocksStubsWithMocksTarget._barStub}";

            instructionList.Add(instruction);

            // CIL Instruction 8.
            instruction = new CustomInstruction();
            instruction.Offset = 18;
            instruction.OpCode = OpCode.Ldarg_0;
            instruction.Value = "{Microsoft.FxCop.Sdk.ClassNode:Srl.FxCop.CustomDeveloperTestRules.TestTargets.DoNotConfuseRhinoMocksStubsWithMocksTarget this}";

            instructionList.Add(instruction);

            // CIL Instruction 9.
            instruction = new CustomInstruction();
            instruction.Offset = 19;
            instruction.OpCode = OpCode.Ldc_I4_0;
            instruction.Value = 0;

            instructionList.Add(instruction);

            // CIL Instruction 10.
            instruction = new CustomInstruction();
            instruction.Offset = 20;
            instruction.OpCode = OpCode.Newarr;
            // TODO:
            instruction.Value = "{Microsoft.FxCop.Sdk.ClassNode:System.Object}";

            instructionList.Add(instruction);

            // CIL Instruction 11.
            instruction = new CustomInstruction();
            instruction.Offset = 25;
            instruction.OpCode = OpCode.Call;
            // TODO:
            instruction.Value = "{Rhino.Mocks.MockRepository.GenerateMock<Srl.FxCop.CustomDeveloperTestRules.TestTargets.IBar>}";

            instructionList.Add(instruction);

            // CIL Instruction 12.
            instruction = new CustomInstruction();
            instruction.Offset = 30;
            instruction.OpCode = OpCode.Stfld;
            // TODO:
            instruction.Value = "{Srl.FxCop.CustomDeveloperTestRules.TestTargets.DoNotConfuseRhinoMocksStubsWithMocksTarget._barMock}";

            instructionList.Add(instruction);

            // CIL Instruction 13.
            instruction = new CustomInstruction();
            instruction.Offset = 35;
            instruction.OpCode = OpCode.Ldarg_0;
            instruction.Value = "{Microsoft.FxCop.Sdk.ClassNode:Srl.FxCop.CustomDeveloperTestRules.TestTargets.DoNotConfuseRhinoMocksStubsWithMocksTarget this}";

            instructionList.Add(instruction);

            // CIL Instruction 14.
            instruction = new CustomInstruction();
            instruction.Offset = 36;
            instruction.OpCode = OpCode.Ldc_I4_0;
            instruction.Value = 0;

            instructionList.Add(instruction);

            // CIL Instruction 15.
            instruction = new CustomInstruction();
            instruction.Offset = 37;
            instruction.OpCode = OpCode.Newarr;
            // TODO:
            instruction.Value = "{Microsoft.FxCop.Sdk.ClassNode:System.Object}";

            instructionList.Add(instruction);

            // CIL Instruction 16.
            instruction = new CustomInstruction();
            instruction.Offset = 42;
            instruction.OpCode = OpCode.Call;
            // TODO:
            instruction.Value = "{Rhino.Mocks.MockRepository.GenerateStub<Srl.FxCop.CustomDeveloperTestRules.TestTargets.IBar>}";

            instructionList.Add(instruction);

            // CIL Instruction 17.
            instruction = new CustomInstruction();
            instruction.Offset = 47;
            instruction.OpCode = OpCode.Stfld;
            // TODO:
            instruction.Value = "{Srl.FxCop.CustomDeveloperTestRules.TestTargets.DoNotConfuseRhinoMocksStubsWithMocksTarget._barStub2}";

            instructionList.Add(instruction);

            // CIL Instruction 18.
            instruction = new CustomInstruction();
            instruction.Offset = 52;
            instruction.OpCode = OpCode.Ldarg_0;
            instruction.Value = "{Microsoft.FxCop.Sdk.ClassNode:Srl.FxCop.CustomDeveloperTestRules.TestTargets.DoNotConfuseRhinoMocksStubsWithMocksTarget this}";

            instructionList.Add(instruction);

            // CIL Instruction 19.
            instruction = new CustomInstruction();
            instruction.Offset = 53;
            instruction.OpCode = OpCode.Ldc_I4_0;
            instruction.Value = 0;

            instructionList.Add(instruction);

            // CIL Instruction 20.
            instruction = new CustomInstruction();
            instruction.Offset = 54;
            instruction.OpCode = OpCode.Newarr;
            // TODO:
            instruction.Value = "{Microsoft.FxCop.Sdk.ClassNode:System.Object}";

            instructionList.Add(instruction);

            // CIL Instruction 21.
            instruction = new CustomInstruction();
            instruction.Offset = 59;
            instruction.OpCode = OpCode.Call;
            // TODO:
            instruction.Value = "{Rhino.Mocks.MockRepository.GenerateMock<Srl.FxCop.CustomDeveloperTestRules.TestTargets.IBar>}";

            instructionList.Add(instruction);

            // CIL Instruction 22.
            instruction = new CustomInstruction();
            instruction.Offset = 64;
            instruction.OpCode = OpCode.Stfld;
            // TODO:
            instruction.Value = "{Srl.FxCop.CustomDeveloperTestRules.TestTargets.DoNotConfuseRhinoMocksStubsWithMocksTarget._barMock2}";

            instructionList.Add(instruction);

            // CIL Instruction 23.
            instruction = new CustomInstruction();
            instruction.Offset = 69;
            instruction.OpCode = OpCode.Ret;
            instruction.Value = null;

            instructionList.Add(instruction);

            return instructionList;
        }


        /// <summary>
        /// Gets the instructions for the test CannotRaiseProblemWhenAFieldStubOnlyInvokesStub.
        /// </summary>
        /// <returns>
        /// A list of instructions that was empirically obtained from
        /// DoNotConfuseRhinoMocksStubsWithMocksTarget.cs
        /// </returns>
        private IList<CustomInstruction> GetInstructionsForCannotRaiseProblemWhenAFieldStubOnlyInvokesStub()
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
                "{Microsoft.FxCop.Sdk.ClassNode:Srl.FxCop.CustomDeveloperTestRules.TestTargets.DoNotConfuseRhinoMocksStubsWithMocksTarget this}";

            instructionList.Add(instruction);

            // CIL Instruction 4.
            instruction = new CustomInstruction();
            instruction.Offset = 2;
            instruction.OpCode = OpCode.Ldfld;
            instruction.Value = "{Srl.FxCop.CustomDeveloperTestRules.TestTargets.DoNotConfuseRhinoMocksStubsWithMocksTarget._barStub}";

            instructionList.Add(instruction);

            // CIL Instruction 5.
            instruction = new CustomInstruction();
            instruction.Offset = 7;
            instruction.OpCode = OpCode.Ldsfld;
            instruction.Value = 
                "{Srl.FxCop.CustomDeveloperTestRules.TestTargets.DoNotConfuseRhinoMocksStubsWithMocksTarget.<TestMethodWhereAFieldStubIsInvokedWithStub>b__0}";

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
                "{Srl.FxCop.CustomDeveloperTestRules.TestTargets.DoNotConfuseRhinoMocksStubsWithMocksTarget.<TestMethodWhereAFieldStubIsInvokedWithStub>b__0}";

            instructionList.Add(instruction);            
            
            // CIL Instruction 9.
            instruction = new CustomInstruction();
            instruction.Offset = 21;
            instruction.OpCode = OpCode.Newobj;
            instruction.Value = 
                "{System.Action<Srl.FxCop.CustomDeveloperTestRules.TestTargets.IBar>(Microsoft.FxCop.Sdk.ParameterCollection)}";

            instructionList.Add(instruction);

            // CIL Instruction 10.
            instruction = new CustomInstruction();
            instruction.Offset = 26;
            instruction.OpCode = OpCode.Stfld;
            instruction.Value = 
                "{Srl.FxCop.CustomDeveloperTestRules.TestTargets.DoNotConfuseRhinoMocksStubsWithMocksTarget.CS$<>9__CachedAnonymousMethodDelegate1}";

            instructionList.Add(instruction);

            // CIL Instruction 11.
            instruction = new CustomInstruction();
            instruction.Offset = 31;
            instruction.OpCode = OpCode.Br_S;
            instruction.Value = "33";

            instructionList.Add(instruction);

            // CIL Instruction 12.
            instruction = new CustomInstruction();
            instruction.Offset = 33;
            instruction.OpCode = OpCode.Ldsfld;
            instruction.Value =
                "{Srl.FxCop.CustomDeveloperTestRules.TestTargets.DoNotConfuseRhinoMocksStubsWithMocksTarget.CS$<>9__CachedAnonymousMethodDelegate1}";

            instructionList.Add(instruction);

            // CIL Instruction 13.
            instruction = new CustomInstruction();
            instruction.Offset = 38;
            instruction.OpCode = OpCode.Call;
            instruction.Value =
                "{Rhino.Mocks.RhinoMocksExtensions.Stub<Srl.FxCop.CustomDeveloperTestRules.TestTargets.IBar>}";

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
            instruction.OpCode = OpCode.Ret;
            instruction.Value = null;

            instructionList.Add(instruction);

            return instructionList;
        }


        /// <summary>
        /// Gets the instructions for the test CanRaiseProblemWhenAFieldStubIsInvokedWithExpect.
        /// </summary>
        /// <returns>
        /// A list of instructions that was empirically obtained from
        /// DoNotConfuseRhinoMocksStubsWithMocksTarget.cs
        /// </returns>
        private IList<CustomInstruction> GetInstructionsForCanRaiseProblemWhenAFieldStubIsInvokedWithExpect()
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
                "{Microsoft.FxCop.Sdk.ClassNode:Srl.FxCop.CustomDeveloperTestRules.TestTargets.DoNotConfuseRhinoMocksStubsWithMocksTarget this}";

            instructionList.Add(instruction);

            // CIL Instruction 4.
            instruction = new CustomInstruction();
            instruction.Offset = 2;
            instruction.OpCode = OpCode.Ldfld;
            instruction.Value = "{Srl.FxCop.CustomDeveloperTestRules.TestTargets.DoNotConfuseRhinoMocksStubsWithMocksTarget._barStub}";

            instructionList.Add(instruction);

            // CIL Instruction 5.
            instruction = new CustomInstruction();
            instruction.Offset = 7;
            instruction.OpCode = OpCode.Ldsfld;
            instruction.Value =
                "{Srl.FxCop.CustomDeveloperTestRules.TestTargets.DoNotConfuseRhinoMocksStubsWithMocksTarget.CS$<>9__CachedAnonymousMethodDelegate1}";

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
                "{Srl.FxCop.CustomDeveloperTestRules.TestTargets.DoNotConfuseRhinoMocksStubsWithMocksTarget.<TestMethodWhereAFieldStubIsInvokedWithStub>b__0}";

            instructionList.Add(instruction);

            // CIL Instruction 9.
            instruction = new CustomInstruction();
            instruction.Offset = 21;
            instruction.OpCode = OpCode.Newobj;
            instruction.Value =
                "{System.Action<Srl.FxCop.CustomDeveloperTestRules.TestTargets.IBar>(Microsoft.FxCop.Sdk.ParameterCollection)}";

            instructionList.Add(instruction);

            // CIL Instruction 10.
            instruction = new CustomInstruction();
            instruction.Offset = 26;
            instruction.OpCode = OpCode.Stfld;
            instruction.Value =
                "{Srl.FxCop.CustomDeveloperTestRules.TestTargets.DoNotConfuseRhinoMocksStubsWithMocksTarget.CS$<>9__CachedAnonymousMethodDelegate1}";

            instructionList.Add(instruction);

            // CIL Instruction 11.
            instruction = new CustomInstruction();
            instruction.Offset = 31;
            instruction.OpCode = OpCode.Br_S;
            instruction.Value = "33";

            instructionList.Add(instruction);

            // CIL Instruction 12.
            instruction = new CustomInstruction();
            instruction.Offset = 33;
            instruction.OpCode = OpCode.Ldsfld;
            instruction.Value =
                "{Srl.FxCop.CustomDeveloperTestRules.TestTargets.DoNotConfuseRhinoMocksStubsWithMocksTarget.CS$<>9__CachedAnonymousMethodDelegate1}";

            instructionList.Add(instruction);

            // CIL Instruction 13.
            instruction = new CustomInstruction();
            instruction.Offset = 38;
            instruction.OpCode = OpCode.Call;
            instruction.Value =
                "{Rhino.Mocks.RhinoMocksExtensions.Expect<Srl.FxCop.CustomDeveloperTestRules.TestTargets.IBar>}";

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
            instruction.OpCode = OpCode.Ret;
            instruction.Value = null;

            instructionList.Add(instruction);

            return instructionList;
        }


        /// <summary>
        /// Gets the instructions for the test CanRaiseProblemWhenALocalStubIsUsedAsAMock.
        /// </summary>
        /// <returns>
        /// A list of instructions that was empirically obtained from
        /// DoNotConfuseRhinoMocksStubsWithMocksTarget.cs
        /// </returns>
        private IList<CustomInstruction> GetInstructionsForCanRaiseProblemWhenALocalStubIsUsedAsAMock()
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
            instruction.OpCode = OpCode.Ldc_I4_0;
            instruction.Value = 0;

            instructionList.Add(instruction);

            // CIL Instruction 4.
            instruction = new CustomInstruction();
            instruction.Offset = 2;
            instruction.OpCode = OpCode.Newarr;
            instruction.Value = "{Microsoft.FxCop.Sdk.ClassNode:System.Object}";

            instructionList.Add(instruction);

            // CIL Instruction 5.
            instruction = new CustomInstruction();
            instruction.Offset = 7;
            instruction.OpCode = OpCode.Call;
            instruction.Value = "{Rhino.Mocks.MockRepository.GenerateStub<Srl.FxCop.CustomDeveloperTestRules.TestTargets.IBar>}";

            instructionList.Add(instruction);

            // CIL Instruction 6.
            instruction = new CustomInstruction();
            instruction.Offset = 12;
            instruction.OpCode = OpCode.Stloc_0;
            instruction.Value = new CustomLocal() { Name = "localStub" };

            instructionList.Add(instruction);

            // CIL Instruction 7.
            instruction = new CustomInstruction();
            instruction.Offset = 13;
            instruction.OpCode = OpCode.Ldloc_0;
            instruction.Value = new CustomLocal() { Name = "localStub" };

            instructionList.Add(instruction);

            // CIL Instruction 8.
            instruction = new CustomInstruction();
            instruction.Offset = 14;
            instruction.OpCode = OpCode.Call;
            instruction.Value = "{Rhino.Mocks.RhinoMocksExtensions.VerifyAllExpectations}";

            instructionList.Add(instruction);

            // CIL Instruction 9.
            instruction = new CustomInstruction();
            instruction.Offset = 19;
            instruction.OpCode = OpCode.Nop;
            instruction.Value = null;

            instructionList.Add(instruction);

            // CIL Instruction 10.
            instruction = new CustomInstruction();
            instruction.Offset = 20;
            instruction.OpCode = OpCode.Ret;
            instruction.Value = null;

            instructionList.Add(instruction);

            return instructionList;
        }

        #endregion
    }
}
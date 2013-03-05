//
// CommonHelpersTests.cs
//
// Product:
//
// Component: Srl.FxCop.CustomRuleSdk.UnitTests
//
// Description: Represents a test harness for the CommonHelpers class.
//
// Author: Scott Lurowist
//




#region Using Directives

using System;
using System.Collections.Generic;
using Microsoft.FxCop.Sdk;
using NUnit.Framework;

#endregion




namespace Srl.FxCop.CustomRuleSdk.UnitTests
{
    /// <summary>
    /// Represents a test harness for the CommonHelpers class.
    /// </summary>
    [TestFixture]
    public class DoNotConfuseRhinoMocksStubsWithMocksTests
    {
        [Test]
        public void CanGetInstructionThatLoadsTheTargetOfAnExtensionMethodByCustomInstructionList()
        {
            // Arrange
            IList<CustomInstruction> instructionsForMethod =
                GetInstructionsForCanGetInstructionThatLoadsTheTargetOfAnExtensionMethodByCustomInstructionList();

            // this is the index into the instructions that we just received that calls the extension
            // method. We want to find the class instance that appears to have the extension method. It 
            // is an operand on the VES for the extension method.
            const int indexForInstructionThatCallsExtensionMethod = 12;


            // Act
            CustomInstruction extensionMethodTarget = CommonHelpers
                .GetInstructionThatLoadsTheTargetOfAnExtensionMethod(
                    instructionsForMethod[indexForInstructionThatCallsExtensionMethod],
                    instructionsForMethod);


            // Assert
            const int expectedInstructionOffsetValue = 2;
            const OpCode expectedInstructionOpcodeValue = OpCode.Ldfld;
            const string expectedInstructionValue =
                "{Srl.FxCop.CustomDeveloperTestRules.TestTargets.DoNotConfuseRhinoMocksStubsWithMocksTarget._barMock}";

            Assert.That(extensionMethodTarget.Offset, Is.EqualTo(expectedInstructionOffsetValue));
            Assert.That(extensionMethodTarget.OpCode, Is.EqualTo(expectedInstructionOpcodeValue));
            Assert.That(extensionMethodTarget.Value, Is.EqualTo(expectedInstructionValue));
        }


        [Test]
        public void CanGetVariableNameFromCustomInstructionValue()
        {
            // Arrange
            IList<CustomInstruction> instructions =
                GetInstructionsForCanGetInstructionThatLoadsTheTargetOfAnExtensionMethodByCustomInstructionList();

            // this is the index into the instructions that we just received that loads a field.
            const int indexForInstructionThatLoadsAField = 3;


            // Act
            string actualFieldName =
                CommonHelpers.GetVariableNameFromInstructionValue(instructions[indexForInstructionThatLoadsAField]);


            // Assert
            const string expectedFieldName = "_barMock";

            Assert.That(actualFieldName, Is.EqualTo(expectedFieldName));
        }


        [Test]
        public void CanThrowArgumentNullExceptionInGetVariableNameFromInstructionValueWhenInstructionIsNull()
        {
            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => CommonHelpers.GetVariableNameFromInstructionValue(null));
        }


        [Test]
        public void TestPathStack()
        {
            // Arrange
            IList<CustomInstruction> instructions =
                //GetInstructionsToTestFindingTheTargetOfAnExtensionMethod();
                //GetInstructionsCanLoadClaimsPresenter();
                TestMonitorBatchTimeoutExcpetion();


            // Act
            CommonHelpers.FindBranchPathToInstruction(instructions[112], instructions);
        }



        //[Test]
        //public void CanThrowArgumentNullExceptionInGetVariableNameFromInstructionValueWhenInstructionValueIsNull()
        //{
        //    // Arrange
        //    CustomInstruction instruction = new CustomInstruction();
        //    instruction.Value = null;

        //    // Act and Assert
        //    Assert.Throws<ArgumentNullException>(() => CommonHelpers.GetVariableNameFromInstructionValue(null));
        //}


        //[Test]
        //public void CanReturnNullWhenInstructionForGetVariableNameFromInstructionValueWhenOpcodeValueIsNotAField()
        //{
                
        //}


        [Test]
        public void Foo()
        {
            // Arrange
            IList<CustomInstruction> instructions =
                //GetInstructionsToTestFindingTheTargetOfAnExtensionMethod();
                //GetInstructionsCanLoadClaimsPresenter();
                TestMonitorBatchTimeoutExcpetion();
                //GetInstructionsForCannotRaiseProblemWhenVerifyAllExpectationsIsInvokedAndAnExpectationIsSet();
                //CheckCommandParameterTest();
            // this is the index into the instructions that we just received that
            // has the extension method of interest.
            //const int indexForInstructionThatIsAnExtensionMethod = 59;
            const int indexForInstructionThatIsAnExtensionMethod = 147;


            // Act
            var extMethodInstruction = CommonHelpers.GetInstructionThatLoadsTheTargetOfAnExtensionMethod(
                instructions[indexForInstructionThatIsAnExtensionMethod],
                instructions);

            // Assert
            // This offset can be found by inspecting GetInstructionsToTestFindingTheTargetOfAnExtensionMethod.
            int expectedOffsetOfTargetInstruction = 396;
            Assert.That(extMethodInstruction.Offset == expectedOffsetOfTargetInstruction);
        }


        //[Test]
        //public void FindPathToInstruction()
        //{
        //    // Arrange
        //    IList<CustomInstruction> instructions =
        //        //GetInstructionsToTestFindingTheTargetOfAnExtensionMethod();
        //        //GetInstructionsCanLoadClaimsPresenter();
        //        TestMonitorBatchTimeoutExcpetion();

        //    // this is the index into the instructions that we just received that
        //    // has the extension method of interest.
        //    //const int indexForInstructionThatIsAnExtensionMethod = 59;
        //    const int indexForInstructionThatIsAnExtensionMethod = 112;


        //    // Act
        //    CommonHelpers.FindPathToInstructionStart(
        //        instructions[indexForInstructionThatIsAnExtensionMethod],
        //        instructions);

        //    // Assert
        //    // This offset can be found by inspecting GetInstructionsToTestFindingTheTargetOfAnExtensionMethod.
        //    int expectedOffsetOfTargetInstruction = 183;
        //    //Assert.That(extMethodInstruction.Offset == expectedOffsetOfTargetInstruction);
        //}

        #region Private Instance Helper Methods

        /// <summary>
        /// Gets the instructions for the test CanRaiseProblemWhenAFieldStubIsInvokedWithExpect.
        /// </summary>
        /// <returns>
        /// A list of instructions that was empirically obtained from
        /// DoNotConfuseRhinoMocksStubsWithMocksTarget.cs
        /// </returns>
        private IList<CustomInstruction>
            GetInstructionsForCanGetInstructionThatLoadsTheTargetOfAnExtensionMethodByCustomInstructionList()
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
            instruction.Value =
                "{Srl.FxCop.CustomDeveloperTestRules.TestTargets.DoNotConfuseRhinoMocksStubsWithMocksTarget._barMock}";

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
        /// Gets the instructions for testing finding the target of extension methods.
        /// </summary>
        /// <returns>
        /// A list of instructions.
        /// </returns>
        private IList<CustomInstruction> GetInstructionsToTestFindingTheTargetOfAnExtensionMethod()
        {
            IList<CustomInstruction> instructionList = new List<CustomInstruction>();

            CustomInstruction instruction;
            CustomMethod meth;
            CustomLocal custLocal;

            // CIL Instruction 1.
            instruction = new CustomInstruction();
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
            meth = new CustomMethod();
            meth.IsReturnTypeVoid = false;
            meth.IsStatic = true;
            meth.Signature = "{Rhino.Mocks.MockRepository.GenerateMock<McKesson.TPP.UI.Modules.SearchManager.Views.IClaimSearchView>(System.Object[])}";
            instruction.Value = meth;

            instructionList.Add(instruction);

            // CIL Instruction 6.
            instruction = new CustomInstruction();
            instruction.Offset = 12;
            instruction.OpCode = OpCode.Stloc_0;
            custLocal = new CustomLocal();
            custLocal.Name = "control";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 7.
            instruction = new CustomInstruction();
            instruction.Offset = 13;
            instruction.OpCode = OpCode.Ldarg_0;
            instruction.Value = "{Microsoft.FxCop.Sdk.ClassNode:McKesson.TPP.UI.Modules.SearchManager.Tests.Views.AdvancedSearchPresenterTest this}";

            instructionList.Add(instruction);

            // CIL Instruction 8.
            instruction = new CustomInstruction();
            instruction.Offset = 14;
            instruction.OpCode = OpCode.Ldfld;
            instruction.Value = "{McKesson.TPP.UI.Modules.SearchManager.Tests.Views.AdvancedSearchPresenterTest._view}";

            instructionList.Add(instruction);

            // CIL Instruction 9.
            instruction = new CustomInstruction();
            instruction.Offset = 19;
            instruction.OpCode = OpCode.Ldsfld;
            instruction.Value = "{McKesson.TPP.UI.Modules.SearchManager.Tests.Views.AdvancedSearchPresenterTest.CS$<>9__CachedAnonymousMethodDelegate5}";

            instructionList.Add(instruction);

            // CIL Instruction 10.
            instruction = new CustomInstruction();
            instruction.Offset = 24;
            instruction.OpCode = OpCode.Brtrue_S;
            instruction.Value = 45;

            instructionList.Add(instruction);

            // CIL Instruction 11.
            instruction = new CustomInstruction();
            instruction.Offset = 26;
            instruction.OpCode = OpCode.Ldnull;
            instruction.Value = null;

            instructionList.Add(instruction);

            // CIL Instruction 12.
            instruction = new CustomInstruction();
            instruction.Offset = 27;
            instruction.OpCode = OpCode.Ldftn;
            instruction.Value = "{McKesson.TPP.UI.Modules.SearchManager.Tests.Views.AdvancedSearchPresenterTest.<TestLoadClaims>b__1}";

            instructionList.Add(instruction);

            // CIL Instruction 13.
            instruction = new CustomInstruction();
            instruction.Offset = 33;
            instruction.OpCode = OpCode.Newobj;
            instruction.Value = "{Rhino.Mocks.Function<McKesson.TPP.UI.Modules.SearchManager.Views.IAdvancedSearchView,McKesson.TPP.UI.Modules.SearchManager.Entities.SearchModeEnum>(Microsoft.FxCop.Sdk.ParameterCollection)}";

            instructionList.Add(instruction);

            // CIL Instruction 14.
            instruction = new CustomInstruction();
            instruction.Offset = 38;
            instruction.OpCode = OpCode.Stsfld;
            instruction.Value = "{McKesson.TPP.UI.Modules.SearchManager.Tests.Views.AdvancedSearchPresenterTest.CS$<>9__CachedAnonymousMethodDelegate5}";

            instructionList.Add(instruction);

            // CIL Instruction 15.
            instruction = new CustomInstruction();
            instruction.Offset = 43;
            instruction.OpCode = OpCode.Br_S;
            instruction.Value = 45;

            instructionList.Add(instruction);

            // CIL Instruction 16.
            instruction = new CustomInstruction();
            instruction.Offset = 45;
            instruction.OpCode = OpCode.Ldsfld;
            instruction.Value = "{McKesson.TPP.UI.Modules.SearchManager.Tests.Views.AdvancedSearchPresenterTest.CS$<>9__CachedAnonymousMethodDelegate5}";

            instructionList.Add(instruction);

            // CIL Instruction 17.
            instruction = new CustomInstruction();
            instruction.Offset = 50;
            instruction.OpCode = OpCode.Call;
            meth = new CustomMethod();
            meth.IsReturnTypeVoid = false;
            meth.IsStatic = true;
            meth.Signature = "{Rhino.Mocks.RhinoMocksExtensions.Expect<McKesson.TPP.UI.Modules.SearchManager.Views.IAdvancedSearchView,McKesson.TPP.UI.Modules.SearchManager.Entities.SearchModeEnum>(McKesson.TPP.UI.Modules.SearchManager.Views.IAdvancedSearchView,Rhino.Mocks.Function`2<McKesson.TPP.UI.Modules.SearchManager.Views.IAdvancedSearchView,McKesson.TPP.UI.Modules.SearchManager.Entities.SearchModeEnum>)}";
            instruction.Value = meth;

            instructionList.Add(instruction);

            // CIL Instruction 18.
            instruction = new CustomInstruction();
            instruction.Offset = 55;
            instruction.OpCode = OpCode.Ldc_I4_2;
            instruction.Value = 2;

            instructionList.Add(instruction);

            // CIL Instruction 19.
            instruction = new CustomInstruction();
            instruction.Offset = 56;
            instruction.OpCode = OpCode.Callvirt;
            meth = new CustomMethod();
            meth.IsReturnTypeVoid = false;
            meth.IsStatic = false;
            meth.Signature = "{Rhino.Mocks.Interfaces.IMethodOptions`1<McKesson.TPP.UI.Modules.SearchManager.Entities.SearchModeEnum>.Return(McKesson.TPP.UI.Modules.SearchManager.Entities.SearchModeEnum)}";
            instruction.Value = meth;

            instructionList.Add(instruction);

            // CIL Instruction 20.
            instruction = new CustomInstruction();
            instruction.Offset = 61;
            instruction.OpCode = OpCode.Callvirt;
            meth = new CustomMethod();
            meth.IsReturnTypeVoid = false;
            meth.IsStatic = false;
            meth.Signature = "{Rhino.Mocks.Interfaces.IMethodOptions`1<McKesson.TPP.UI.Modules.SearchManager.Entities.SearchModeEnum>.get_Repeat}";
            instruction.Value = meth;

            instructionList.Add(instruction);

            // CIL Instruction 21.
            instruction = new CustomInstruction();
            instruction.Offset = 66;
            instruction.OpCode = OpCode.Callvirt;
            meth = new CustomMethod();
            meth.IsReturnTypeVoid = false;
            meth.IsStatic = false;
            meth.Signature = "{Rhino.Mocks.Interfaces.IRepeat`1<McKesson.TPP.UI.Modules.SearchManager.Entities.SearchModeEnum>.Any}";
            instruction.Value = meth;

            instructionList.Add(instruction);

            // CIL Instruction 22.
            instruction = new CustomInstruction();
            instruction.Offset = 71;
            instruction.OpCode = OpCode.Pop;
            instruction.Value = null;

            instructionList.Add(instruction);

            // CIL Instruction 23.
            instruction = new CustomInstruction();
            instruction.Offset = 72;
            instruction.OpCode = OpCode.Ldarg_0;
            instruction.Value = "{Microsoft.FxCop.Sdk.ClassNode:McKesson.TPP.UI.Modules.SearchManager.Tests.Views.AdvancedSearchPresenterTest this}";

            instructionList.Add(instruction);

            // CIL Instruction 24.
            instruction = new CustomInstruction();
            instruction.Offset = 73;
            instruction.OpCode = OpCode.Ldfld;
            instruction.Value = "{McKesson.TPP.UI.Modules.SearchManager.Tests.Views.AdvancedSearchPresenterTest._view}";

            instructionList.Add(instruction);

            // CIL Instruction 25.
            instruction = new CustomInstruction();
            instruction.Offset = 78;
            instruction.OpCode = OpCode.Ldsfld;
            instruction.Value = "{McKesson.TPP.UI.Modules.SearchManager.Tests.Views.AdvancedSearchPresenterTest.CS$<>9__CachedAnonymousMethodDelegate6}";

            instructionList.Add(instruction);

            // CIL Instruction 26.
            instruction = new CustomInstruction();
            instruction.Offset = 83;
            instruction.OpCode = OpCode.Brtrue_S;
            instruction.Value = 104;

            instructionList.Add(instruction);

            // CIL Instruction 27.
            instruction = new CustomInstruction();
            instruction.Offset = 85;
            instruction.OpCode = OpCode.Ldnull;
            instruction.Value = null;

            instructionList.Add(instruction);

            // CIL Instruction 28.
            instruction = new CustomInstruction();
            instruction.Offset = 86;
            instruction.OpCode = OpCode.Ldftn;
            instruction.Value = "{McKesson.TPP.UI.Modules.SearchManager.Tests.Views.AdvancedSearchPresenterTest.<TestLoadClaims>b__2}";

            instructionList.Add(instruction);

            // CIL Instruction 29.
            instruction = new CustomInstruction();
            instruction.Offset = 92;
            instruction.OpCode = OpCode.Newobj;
            instruction.Value = "{Rhino.Mocks.Function<McKesson.TPP.UI.Modules.SearchManager.Views.IAdvancedSearchView,McKesson.TPP.UI.Modules.SearchManager.Views.ISearchControl>(Microsoft.FxCop.Sdk.ParameterCollection)}";

            instructionList.Add(instruction);

            // CIL Instruction 30.
            instruction = new CustomInstruction();
            instruction.Offset = 97;
            instruction.OpCode = OpCode.Stsfld;
            instruction.Value = "{McKesson.TPP.UI.Modules.SearchManager.Tests.Views.AdvancedSearchPresenterTest.CS$<>9__CachedAnonymousMethodDelegate6}";

            instructionList.Add(instruction);

            // CIL Instruction 31.
            instruction = new CustomInstruction();
            instruction.Offset = 102;
            instruction.OpCode = OpCode.Br_S;
            instruction.Value = 104;

            instructionList.Add(instruction);

            // CIL Instruction 32.
            instruction = new CustomInstruction();
            instruction.Offset = 104;
            instruction.OpCode = OpCode.Ldsfld;
            instruction.Value = "{McKesson.TPP.UI.Modules.SearchManager.Tests.Views.AdvancedSearchPresenterTest.CS$<>9__CachedAnonymousMethodDelegate6}";

            instructionList.Add(instruction);

            // CIL Instruction 33.
            instruction = new CustomInstruction();
            instruction.Offset = 109;
            instruction.OpCode = OpCode.Call;
            meth = new CustomMethod();
            meth.IsReturnTypeVoid = false;
            meth.IsStatic = true;
            meth.Signature = "{Rhino.Mocks.RhinoMocksExtensions.Expect<McKesson.TPP.UI.Modules.SearchManager.Views.IAdvancedSearchView,McKesson.TPP.UI.Modules.SearchManager.Views.ISearchControl>(McKesson.TPP.UI.Modules.SearchManager.Views.IAdvancedSearchView,Rhino.Mocks.Function`2<McKesson.TPP.UI.Modules.SearchManager.Views.IAdvancedSearchView,McKesson.TPP.UI.Modules.SearchManager.Views.ISearchControl>)}";
            instruction.Value = meth;

            instructionList.Add(instruction);

            // CIL Instruction 34.
            instruction = new CustomInstruction();
            instruction.Offset = 114;
            instruction.OpCode = OpCode.Ldloc_0;
            custLocal = new CustomLocal();
            custLocal.Name = "control";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 35.
            instruction = new CustomInstruction();
            instruction.Offset = 115;
            instruction.OpCode = OpCode.Callvirt;
            meth = new CustomMethod();
            meth.IsReturnTypeVoid = false;
            meth.IsStatic = false;
            meth.Signature = "{Rhino.Mocks.Interfaces.IMethodOptions`1<McKesson.TPP.UI.Modules.SearchManager.Views.ISearchControl>.Return(McKesson.TPP.UI.Modules.SearchManager.Views.ISearchControl)}";
            instruction.Value = meth;

            instructionList.Add(instruction);

            // CIL Instruction 36.
            instruction = new CustomInstruction();
            instruction.Offset = 120;
            instruction.OpCode = OpCode.Pop;
            instruction.Value = null;

            instructionList.Add(instruction);

            // CIL Instruction 37.
            instruction = new CustomInstruction();
            instruction.Offset = 121;
            instruction.OpCode = OpCode.Ldarg_0;
            instruction.Value = "{Microsoft.FxCop.Sdk.ClassNode:McKesson.TPP.UI.Modules.SearchManager.Tests.Views.AdvancedSearchPresenterTest this}";

            instructionList.Add(instruction);

            // CIL Instruction 38.
            instruction = new CustomInstruction();
            instruction.Offset = 122;
            instruction.OpCode = OpCode.Ldfld;
            instruction.Value = "{McKesson.TPP.UI.Modules.SearchManager.Tests.Views.AdvancedSearchPresenterTest._view}";

            instructionList.Add(instruction);

            // CIL Instruction 39.
            instruction = new CustomInstruction();
            instruction.Offset = 127;
            instruction.OpCode = OpCode.Ldsfld;
            instruction.Value = "{McKesson.TPP.UI.Modules.SearchManager.Tests.Views.AdvancedSearchPresenterTest.CS$<>9__CachedAnonymousMethodDelegate7}";

            instructionList.Add(instruction);

            // CIL Instruction 40.
            instruction = new CustomInstruction();
            instruction.Offset = 132;
            instruction.OpCode = OpCode.Brtrue_S;
            instruction.Value = 153;

            instructionList.Add(instruction);

            // CIL Instruction 41.
            instruction = new CustomInstruction();
            instruction.Offset = 134;
            instruction.OpCode = OpCode.Ldnull;
            instruction.Value = null;

            instructionList.Add(instruction);

            // CIL Instruction 42.
            instruction = new CustomInstruction();
            instruction.Offset = 135;
            instruction.OpCode = OpCode.Ldftn;
            instruction.Value = "{McKesson.TPP.UI.Modules.SearchManager.Tests.Views.AdvancedSearchPresenterTest.<TestLoadClaims>b__3}";

            instructionList.Add(instruction);

            // CIL Instruction 43.
            instruction = new CustomInstruction();
            instruction.Offset = 141;
            instruction.OpCode = OpCode.Newobj;
            instruction.Value = "{Rhino.Mocks.Function<McKesson.TPP.UI.Modules.SearchManager.Views.IAdvancedSearchView,System.Boolean>(Microsoft.FxCop.Sdk.ParameterCollection)}";

            instructionList.Add(instruction);

            // CIL Instruction 44.
            instruction = new CustomInstruction();
            instruction.Offset = 146;
            instruction.OpCode = OpCode.Stsfld;
            instruction.Value = "{McKesson.TPP.UI.Modules.SearchManager.Tests.Views.AdvancedSearchPresenterTest.CS$<>9__CachedAnonymousMethodDelegate7}";

            instructionList.Add(instruction);

            // CIL Instruction 45.
            instruction = new CustomInstruction();
            instruction.Offset = 151;
            instruction.OpCode = OpCode.Br_S;
            instruction.Value = 153;

            instructionList.Add(instruction);

            // CIL Instruction 46.
            instruction = new CustomInstruction();
            instruction.Offset = 153;
            instruction.OpCode = OpCode.Ldsfld;
            instruction.Value = "{McKesson.TPP.UI.Modules.SearchManager.Tests.Views.AdvancedSearchPresenterTest.CS$<>9__CachedAnonymousMethodDelegate7}";

            instructionList.Add(instruction);

            // CIL Instruction 47.
            instruction = new CustomInstruction();
            instruction.Offset = 158;
            instruction.OpCode = OpCode.Call;
            meth = new CustomMethod();
            meth.IsReturnTypeVoid = false;
            meth.IsStatic = true;
            meth.Signature = "{Rhino.Mocks.RhinoMocksExtensions.Expect<McKesson.TPP.UI.Modules.SearchManager.Views.IAdvancedSearchView,System.Boolean>(McKesson.TPP.UI.Modules.SearchManager.Views.IAdvancedSearchView,Rhino.Mocks.Function`2<McKesson.TPP.UI.Modules.SearchManager.Views.IAdvancedSearchView,System.Boolean>)}";
            instruction.Value = meth;

            instructionList.Add(instruction);

            // CIL Instruction 48.
            instruction = new CustomInstruction();
            instruction.Offset = 163;
            instruction.OpCode = OpCode.Ldc_I4_0;
            instruction.Value = 0;

            instructionList.Add(instruction);

            // CIL Instruction 49.
            instruction = new CustomInstruction();
            instruction.Offset = 164;
            instruction.OpCode = OpCode.Callvirt;
            meth = new CustomMethod();
            meth.IsReturnTypeVoid = false;
            meth.IsStatic = false;
            meth.Signature = "{Rhino.Mocks.Interfaces.IMethodOptions`1<System.Boolean>.Return(System.Boolean)}";
            instruction.Value = meth;

            instructionList.Add(instruction);

            // CIL Instruction 50.
            instruction = new CustomInstruction();
            instruction.Offset = 169;
            instruction.OpCode = OpCode.Pop;
            instruction.Value = null;

            instructionList.Add(instruction);

            // CIL Instruction 51.
            instruction = new CustomInstruction();
            instruction.Offset = 170;
            instruction.OpCode = OpCode.Ldloc_0;
            custLocal = new CustomLocal();
            custLocal.Name = "control";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 52.
            instruction = new CustomInstruction();
            instruction.Offset = 171;
            instruction.OpCode = OpCode.Ldarg_0;
            instruction.Value = "{Microsoft.FxCop.Sdk.ClassNode:McKesson.TPP.UI.Modules.SearchManager.Tests.Views.AdvancedSearchPresenterTest this}";

            instructionList.Add(instruction);

            // CIL Instruction 53.
            instruction = new CustomInstruction();
            instruction.Offset = 172;
            instruction.OpCode = OpCode.Ldfld;
            instruction.Value = "{McKesson.TPP.UI.Modules.SearchManager.Tests.Views.AdvancedSearchPresenterTest._view}";

            instructionList.Add(instruction);

            // CIL Instruction 54.
            instruction = new CustomInstruction();
            instruction.Offset = 177;
            instruction.OpCode = OpCode.Callvirt;
            meth = new CustomMethod();
            meth.IsReturnTypeVoid = true;
            meth.IsStatic = false;
            meth.Signature = "{McKesson.TPP.UI.Modules.SearchManager.Views.ISearchControl.set_ParentView(McKesson.TPP.UI.Modules.SearchManager.Views.IErrorReporter)}";
            instruction.Value = meth;

            instructionList.Add(instruction);

            // CIL Instruction 55.
            instruction = new CustomInstruction();
            instruction.Offset = 182;
            instruction.OpCode = OpCode.Nop;
            instruction.Value = null;

            instructionList.Add(instruction);

            // CIL Instruction 56.
            instruction = new CustomInstruction();
            instruction.Offset = 183;
            instruction.OpCode = OpCode.Ldloc_0;
            custLocal = new CustomLocal();
            custLocal.Name = "control";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 57.
            instruction = new CustomInstruction();
            instruction.Offset = 184;
            instruction.OpCode = OpCode.Ldarg_0;
            instruction.Value = "{Microsoft.FxCop.Sdk.ClassNode:McKesson.TPP.UI.Modules.SearchManager.Tests.Views.AdvancedSearchPresenterTest this}";

            instructionList.Add(instruction);

            // CIL Instruction 58.
            instruction = new CustomInstruction();
            instruction.Offset = 185;
            instruction.OpCode = OpCode.Ldftn;
            instruction.Value = "{McKesson.TPP.UI.Modules.SearchManager.Tests.Views.AdvancedSearchPresenterTest.<TestLoadClaims>b__4}";

            instructionList.Add(instruction);

            // CIL Instruction 59.
            instruction = new CustomInstruction();
            instruction.Offset = 191;
            instruction.OpCode = OpCode.Newobj;
            instruction.Value = "{Rhino.Mocks.Function<McKesson.TPP.UI.Modules.SearchManager.Views.IClaimSearchView,McKesson.TPP.UI.Modules.SearchManager.Views.ClaimSearchPresenter>(Microsoft.FxCop.Sdk.ParameterCollection)}";

            instructionList.Add(instruction);

            // CIL Instruction 60.
            instruction = new CustomInstruction();
            instruction.Offset = 196;
            instruction.OpCode = OpCode.Call;
            meth = new CustomMethod();
            meth.IsReturnTypeVoid = false;
            meth.IsStatic = true;
            meth.Signature = "{Rhino.Mocks.RhinoMocksExtensions.Expect<McKesson.TPP.UI.Modules.SearchManager.Views.IClaimSearchView,McKesson.TPP.UI.Modules.SearchManager.Views.ClaimSearchPresenter>(McKesson.TPP.UI.Modules.SearchManager.Views.IClaimSearchView,Rhino.Mocks.Function`2<McKesson.TPP.UI.Modules.SearchManager.Views.IClaimSearchView,McKesson.TPP.UI.Modules.SearchManager.Views.ClaimSearchPresenter>)}";
            instruction.Value = meth;

            instructionList.Add(instruction);

            // CIL Instruction 61.
            instruction = new CustomInstruction();
            instruction.Offset = 201;
            instruction.OpCode = OpCode.Pop;
            instruction.Value = null;

            instructionList.Add(instruction);

            // CIL Instruction 62.
            instruction = new CustomInstruction();
            instruction.Offset = 202;
            instruction.OpCode = OpCode.Ldarg_0;
            instruction.Value = "{Microsoft.FxCop.Sdk.ClassNode:McKesson.TPP.UI.Modules.SearchManager.Tests.Views.AdvancedSearchPresenterTest this}";

            instructionList.Add(instruction);

            // CIL Instruction 63.
            instruction = new CustomInstruction();
            instruction.Offset = 203;
            instruction.OpCode = OpCode.Ldfld;
            instruction.Value = "{McKesson.TPP.UI.Modules.SearchManager.Tests.Views.AdvancedSearchPresenterTest._testee}";

            instructionList.Add(instruction);

            // CIL Instruction 64.
            instruction = new CustomInstruction();
            instruction.Offset = 208;
            instruction.OpCode = OpCode.Callvirt;
            meth = new CustomMethod();
            meth.IsReturnTypeVoid = true;
            meth.IsStatic = false;
            meth.Signature = "{Microsoft.Practices.CompositeWeb.Presenter`1<McKesson.TPP.UI.Modules.SearchManager.Views.IAdvancedSearchView>.OnViewLoaded}";
            instruction.Value = meth;

            instructionList.Add(instruction);

            // CIL Instruction 65.
            instruction = new CustomInstruction();
            instruction.Offset = 213;
            instruction.OpCode = OpCode.Nop;
            instruction.Value = null;

            instructionList.Add(instruction);

            // CIL Instruction 66.
            instruction = new CustomInstruction();
            instruction.Offset = 214;
            instruction.OpCode = OpCode.Ret;
            instruction.Value = null;

            instructionList.Add(instruction);

            return instructionList;
        }


        private IList<CustomInstruction> TestMonitorBatchTimeoutExcpetion()
        {
            IList<CustomInstruction> instructionList = new List<CustomInstruction>();

            CustomInstruction instruction;
            CustomMethod meth;
            CustomLocal custLocal;

            // CIL Instruction 1.
            instruction = new CustomInstruction();
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
            instruction.OpCode = OpCode.Newobj;
            meth = new CustomMethod();
            meth.IsReturnTypeVoid = true;
            meth.IsStatic = false;
            meth.NumberOfParameters = 0;
            meth.Signature = "{McKesson.TPP.DataAccess.DomainModel.Entities.Batch.#ctor}";
            instruction.Value = meth;

            instructionList.Add(instruction);

            // CIL Instruction 4.
            instruction = new CustomInstruction();
            instruction.Offset = 6;
            instruction.OpCode = OpCode.Stloc_S;
            custLocal = new CustomLocal();
            custLocal.Name = "<>g__initLocal7";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 5.
            instruction = new CustomInstruction();
            instruction.Offset = 8;
            instruction.OpCode = OpCode.Ldloc_S;
            custLocal = new CustomLocal();
            custLocal.Name = "<>g__initLocal7";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 6.
            instruction = new CustomInstruction();
            instruction.Offset = 10;
            instruction.OpCode = OpCode.Ldc_I4;
            instruction.Value = 2009;

            instructionList.Add(instruction);

            // CIL Instruction 7.
            instruction = new CustomInstruction();
            instruction.Offset = 15;
            instruction.OpCode = OpCode.Ldc_I4_S;
            instruction.Value = 12;

            instructionList.Add(instruction);

            // CIL Instruction 8.
            instruction = new CustomInstruction();
            instruction.Offset = 17;
            instruction.OpCode = OpCode.Ldc_I4_S;
            instruction.Value = 23;

            instructionList.Add(instruction);

            // CIL Instruction 9.
            instruction = new CustomInstruction();
            instruction.Offset = 19;
            instruction.OpCode = OpCode.Newobj;
            meth = new CustomMethod();
            meth.IsReturnTypeVoid = true;
            meth.IsStatic = false;
            meth.NumberOfParameters = 3;
            meth.Signature = "{System.DateTime.#ctor(System.Int32,System.Int32,System.Int32)}";
            instruction.Value = meth;

            instructionList.Add(instruction);

            // CIL Instruction 10.
            instruction = new CustomInstruction();
            instruction.Offset = 24;
            instruction.OpCode = OpCode.Callvirt;
            meth = new CustomMethod();
            meth.IsReturnTypeVoid = true;
            meth.IsStatic = false;
            meth.NumberOfParameters = 1;
            meth.Signature = "{McKesson.TPP.DataAccess.DomainModel.Entities.Batch.set_DateCreated(System.DateTime)}";
            instruction.Value = meth;

            instructionList.Add(instruction);

            // CIL Instruction 11.
            instruction = new CustomInstruction();
            instruction.Offset = 29;
            instruction.OpCode = OpCode.Nop;
            instruction.Value = null;

            instructionList.Add(instruction);

            // CIL Instruction 12.
            instruction = new CustomInstruction();
            instruction.Offset = 30;
            instruction.OpCode = OpCode.Ldloc_S;
            custLocal = new CustomLocal();
            custLocal.Name = "<>g__initLocal7";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 13.
            instruction = new CustomInstruction();
            instruction.Offset = 32;
            instruction.OpCode = OpCode.Ldc_I4;
            instruction.Value = 2009;

            instructionList.Add(instruction);

            // CIL Instruction 14.
            instruction = new CustomInstruction();
            instruction.Offset = 37;
            instruction.OpCode = OpCode.Ldc_I4_1;
            instruction.Value = 1;

            instructionList.Add(instruction);

            // CIL Instruction 15.
            instruction = new CustomInstruction();
            instruction.Offset = 38;
            instruction.OpCode = OpCode.Ldc_I4_1;
            instruction.Value = 1;

            instructionList.Add(instruction);

            // CIL Instruction 16.
            instruction = new CustomInstruction();
            instruction.Offset = 39;
            instruction.OpCode = OpCode.Newobj;
            meth = new CustomMethod();
            meth.IsReturnTypeVoid = true;
            meth.IsStatic = false;
            meth.NumberOfParameters = 3;
            meth.Signature = "{System.DateTime.#ctor(System.Int32,System.Int32,System.Int32)}";
            instruction.Value = meth;

            instructionList.Add(instruction);

            // CIL Instruction 17.
            instruction = new CustomInstruction();
            instruction.Offset = 44;
            instruction.OpCode = OpCode.Newobj;
            meth = new CustomMethod();
            meth.IsReturnTypeVoid = true;
            meth.IsStatic = false;
            meth.NumberOfParameters = 1;
            meth.Signature = "{System.Nullable`1<System.DateTime>.#ctor(System.DateTime)}";
            instruction.Value = meth;

            instructionList.Add(instruction);

            // CIL Instruction 18.
            instruction = new CustomInstruction();
            instruction.Offset = 49;
            instruction.OpCode = OpCode.Callvirt;
            meth = new CustomMethod();
            meth.IsReturnTypeVoid = true;
            meth.IsStatic = false;
            meth.NumberOfParameters = 1;
            meth.Signature = "{McKesson.TPP.DataAccess.DomainModel.Entities.Batch.set_ArchivedDate(System.Nullable`1<System.DateTime>)}";
            instruction.Value = meth;

            instructionList.Add(instruction);

            // CIL Instruction 19.
            instruction = new CustomInstruction();
            instruction.Offset = 54;
            instruction.OpCode = OpCode.Nop;
            instruction.Value = null;

            instructionList.Add(instruction);

            // CIL Instruction 20.
            instruction = new CustomInstruction();
            instruction.Offset = 55;
            instruction.OpCode = OpCode.Ldloc_S;
            custLocal = new CustomLocal();
            custLocal.Name = "<>g__initLocal7";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 21.
            instruction = new CustomInstruction();
            instruction.Offset = 57;
            instruction.OpCode = OpCode.Ldstr;
            instruction.Value = "{N}";

            instructionList.Add(instruction);

            // CIL Instruction 22.
            instruction = new CustomInstruction();
            instruction.Offset = 62;
            instruction.OpCode = OpCode.Callvirt;
            meth = new CustomMethod();
            meth.IsReturnTypeVoid = true;
            meth.IsStatic = false;
            meth.NumberOfParameters = 1;
            meth.Signature = "{McKesson.TPP.DataAccess.DomainModel.Entities.Batch.set_ArchivedFlag(System.String)}";
            instruction.Value = meth;

            instructionList.Add(instruction);

            // CIL Instruction 23.
            instruction = new CustomInstruction();
            instruction.Offset = 67;
            instruction.OpCode = OpCode.Nop;
            instruction.Value = null;

            instructionList.Add(instruction);

            // CIL Instruction 24.
            instruction = new CustomInstruction();
            instruction.Offset = 68;
            instruction.OpCode = OpCode.Ldloc_S;
            custLocal = new CustomLocal();
            custLocal.Name = "<>g__initLocal7";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 25.
            instruction = new CustomInstruction();
            instruction.Offset = 70;
            instruction.OpCode = OpCode.Ldstr;
            instruction.Value = "{12345}";

            instructionList.Add(instruction);

            // CIL Instruction 26.
            instruction = new CustomInstruction();
            instruction.Offset = 75;
            instruction.OpCode = OpCode.Callvirt;
            meth = new CustomMethod();
            meth.IsReturnTypeVoid = true;
            meth.IsStatic = false;
            meth.NumberOfParameters = 1;
            meth.Signature = "{McKesson.TPP.DataAccess.DomainModel.Entities.Batch.set_Checksum(System.String)}";
            instruction.Value = meth;

            instructionList.Add(instruction);

            // CIL Instruction 27.
            instruction = new CustomInstruction();
            instruction.Offset = 80;
            instruction.OpCode = OpCode.Nop;
            instruction.Value = null;

            instructionList.Add(instruction);

            // CIL Instruction 28.
            instruction = new CustomInstruction();
            instruction.Offset = 81;
            instruction.OpCode = OpCode.Ldloc_S;
            custLocal = new CustomLocal();
            custLocal.Name = "<>g__initLocal7";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 29.
            instruction = new CustomInstruction();
            instruction.Offset = 83;
            instruction.OpCode = OpCode.Ldstr;
            instruction.Value = "{c:bcbc.txt}";

            instructionList.Add(instruction);

            // CIL Instruction 30.
            instruction = new CustomInstruction();
            instruction.Offset = 88;
            instruction.OpCode = OpCode.Callvirt;
            meth = new CustomMethod();
            meth.IsReturnTypeVoid = true;
            meth.IsStatic = false;
            meth.NumberOfParameters = 1;
            meth.Signature = "{McKesson.TPP.DataAccess.DomainModel.Entities.Batch.set_Filename(System.String)}";
            instruction.Value = meth;

            instructionList.Add(instruction);

            // CIL Instruction 31.
            instruction = new CustomInstruction();
            instruction.Offset = 93;
            instruction.OpCode = OpCode.Nop;
            instruction.Value = null;

            instructionList.Add(instruction);

            // CIL Instruction 32.
            instruction = new CustomInstruction();
            instruction.Offset = 94;
            instruction.OpCode = OpCode.Ldloc_S;
            custLocal = new CustomLocal();
            custLocal.Name = "<>g__initLocal7";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 33.
            instruction = new CustomInstruction();
            instruction.Offset = 96;
            instruction.OpCode = OpCode.Ldstr;
            instruction.Value = "{temp}";

            instructionList.Add(instruction);

            // CIL Instruction 34.
            instruction = new CustomInstruction();
            instruction.Offset = 101;
            instruction.OpCode = OpCode.Callvirt;
            meth = new CustomMethod();
            meth.IsReturnTypeVoid = true;
            meth.IsStatic = false;
            meth.NumberOfParameters = 1;
            meth.Signature = "{McKesson.TPP.DataAccess.DomainModel.Entities.Batch.set_HostName(System.String)}";
            instruction.Value = meth;

            instructionList.Add(instruction);

            // CIL Instruction 35.
            instruction = new CustomInstruction();
            instruction.Offset = 106;
            instruction.OpCode = OpCode.Nop;
            instruction.Value = null;

            instructionList.Add(instruction);

            // CIL Instruction 36.
            instruction = new CustomInstruction();
            instruction.Offset = 107;
            instruction.OpCode = OpCode.Ldloc_S;
            custLocal = new CustomLocal();
            custLocal.Name = "<>g__initLocal7";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 37.
            instruction = new CustomInstruction();
            instruction.Offset = 109;
            instruction.OpCode = OpCode.Ldc_I4;
            instruction.Value = 200;

            instructionList.Add(instruction);

            // CIL Instruction 38.
            instruction = new CustomInstruction();
            instruction.Offset = 114;
            instruction.OpCode = OpCode.Conv_I8;
            instruction.Value = null;

            instructionList.Add(instruction);

            // CIL Instruction 39.
            instruction = new CustomInstruction();
            instruction.Offset = 115;
            instruction.OpCode = OpCode.Newobj;
            meth = new CustomMethod();
            meth.IsReturnTypeVoid = true;
            meth.IsStatic = false;
            meth.NumberOfParameters = 1;
            meth.Signature = "{System.Nullable`1<System.Int64>.#ctor(System.Int64)}";
            instruction.Value = meth;

            instructionList.Add(instruction);

            // CIL Instruction 40.
            instruction = new CustomInstruction();
            instruction.Offset = 120;
            instruction.OpCode = OpCode.Callvirt;
            meth = new CustomMethod();
            meth.IsReturnTypeVoid = true;
            meth.IsStatic = false;
            meth.NumberOfParameters = 1;
            meth.Signature = "{McKesson.TPP.DataAccess.DomainModel.Entities.Batch.set_NumClaimSetSubmitted(System.Nullable`1<System.Int64>)}";
            instruction.Value = meth;

            instructionList.Add(instruction);

            // CIL Instruction 41.
            instruction = new CustomInstruction();
            instruction.Offset = 125;
            instruction.OpCode = OpCode.Nop;
            instruction.Value = null;

            instructionList.Add(instruction);

            // CIL Instruction 42.
            instruction = new CustomInstruction();
            instruction.Offset = 126;
            instruction.OpCode = OpCode.Ldloc_S;
            custLocal = new CustomLocal();
            custLocal.Name = "<>g__initLocal7";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 43.
            instruction = new CustomInstruction();
            instruction.Offset = 128;
            instruction.OpCode = OpCode.Ldstr;
            instruction.Value = "{c:	emp	emp.txt}";

            instructionList.Add(instruction);

            // CIL Instruction 44.
            instruction = new CustomInstruction();
            instruction.Offset = 133;
            instruction.OpCode = OpCode.Callvirt;
            meth = new CustomMethod();
            meth.IsReturnTypeVoid = true;
            meth.IsStatic = false;
            meth.NumberOfParameters = 1;
            meth.Signature = "{McKesson.TPP.DataAccess.DomainModel.Entities.Batch.set_OriginalFilename(System.String)}";
            instruction.Value = meth;

            instructionList.Add(instruction);

            // CIL Instruction 45.
            instruction = new CustomInstruction();
            instruction.Offset = 138;
            instruction.OpCode = OpCode.Nop;
            instruction.Value = null;

            instructionList.Add(instruction);

            // CIL Instruction 46.
            instruction = new CustomInstruction();
            instruction.Offset = 139;
            instruction.OpCode = OpCode.Ldloc_S;
            custLocal = new CustomLocal();
            custLocal.Name = "<>g__initLocal7";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 47.
            instruction = new CustomInstruction();
            instruction.Offset = 141;
            instruction.OpCode = OpCode.Stloc_0;
            custLocal = new CustomLocal();
            custLocal.Name = "batch";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 48.
            instruction = new CustomInstruction();
            instruction.Offset = 142;
            instruction.OpCode = OpCode.Newobj;
            meth = new CustomMethod();
            meth.IsReturnTypeVoid = true;
            meth.IsStatic = false;
            meth.NumberOfParameters = 0;
            meth.Signature = "{McKesson.TPP.DataAccess.DomainModel.Entities.ClaimSet.#ctor}";
            instruction.Value = meth;

            instructionList.Add(instruction);

            // CIL Instruction 49.
            instruction = new CustomInstruction();
            instruction.Offset = 147;
            instruction.OpCode = OpCode.Stloc_S;
            custLocal = new CustomLocal();
            custLocal.Name = "<>g__initLocal8";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 50.
            instruction = new CustomInstruction();
            instruction.Offset = 149;
            instruction.OpCode = OpCode.Ldloc_S;
            custLocal = new CustomLocal();
            custLocal.Name = "<>g__initLocal8";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 51.
            instruction = new CustomInstruction();
            instruction.Offset = 151;
            instruction.OpCode = OpCode.Ldc_I4;
            instruction.Value = 2009;

            instructionList.Add(instruction);

            // CIL Instruction 52.
            instruction = new CustomInstruction();
            instruction.Offset = 156;
            instruction.OpCode = OpCode.Ldc_I4_S;
            instruction.Value = 12;

            instructionList.Add(instruction);

            // CIL Instruction 53.
            instruction = new CustomInstruction();
            instruction.Offset = 158;
            instruction.OpCode = OpCode.Ldc_I4_S;
            instruction.Value = 23;

            instructionList.Add(instruction);

            // CIL Instruction 54.
            instruction = new CustomInstruction();
            instruction.Offset = 160;
            instruction.OpCode = OpCode.Newobj;
            meth = new CustomMethod();
            meth.IsReturnTypeVoid = true;
            meth.IsStatic = false;
            meth.NumberOfParameters = 3;
            meth.Signature = "{System.DateTime.#ctor(System.Int32,System.Int32,System.Int32)}";
            instruction.Value = meth;

            instructionList.Add(instruction);

            // CIL Instruction 55.
            instruction = new CustomInstruction();
            instruction.Offset = 165;
            instruction.OpCode = OpCode.Callvirt;
            meth = new CustomMethod();
            meth.IsReturnTypeVoid = true;
            meth.IsStatic = false;
            meth.NumberOfParameters = 1;
            meth.Signature = "{McKesson.TPP.DataAccess.DomainModel.Entities.ClaimSet.set_DateCreated(System.DateTime)}";
            instruction.Value = meth;

            instructionList.Add(instruction);

            // CIL Instruction 56.
            instruction = new CustomInstruction();
            instruction.Offset = 170;
            instruction.OpCode = OpCode.Nop;
            instruction.Value = null;

            instructionList.Add(instruction);

            // CIL Instruction 57.
            instruction = new CustomInstruction();
            instruction.Offset = 171;
            instruction.OpCode = OpCode.Ldloc_S;
            custLocal = new CustomLocal();
            custLocal.Name = "<>g__initLocal8";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 58.
            instruction = new CustomInstruction();
            instruction.Offset = 173;
            instruction.OpCode = OpCode.Ldstr;
            instruction.Value = "{ABC}";

            instructionList.Add(instruction);

            // CIL Instruction 59.
            instruction = new CustomInstruction();
            instruction.Offset = 178;
            instruction.OpCode = OpCode.Callvirt;
            meth = new CustomMethod();
            meth.IsReturnTypeVoid = true;
            meth.IsStatic = false;
            meth.NumberOfParameters = 1;
            meth.Signature = "{McKesson.TPP.DataAccess.DomainModel.Entities.ClaimSet.set_Workflow(System.String)}";
            instruction.Value = meth;

            instructionList.Add(instruction);

            // CIL Instruction 60.
            instruction = new CustomInstruction();
            instruction.Offset = 183;
            instruction.OpCode = OpCode.Nop;
            instruction.Value = null;

            instructionList.Add(instruction);

            // CIL Instruction 61.
            instruction = new CustomInstruction();
            instruction.Offset = 184;
            instruction.OpCode = OpCode.Ldloc_S;
            custLocal = new CustomLocal();
            custLocal.Name = "<>g__initLocal8";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 62.
            instruction = new CustomInstruction();
            instruction.Offset = 186;
            instruction.OpCode = OpCode.Ldloc_0;
            custLocal = new CustomLocal();
            custLocal.Name = "batch";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 63.
            instruction = new CustomInstruction();
            instruction.Offset = 187;
            instruction.OpCode = OpCode.Callvirt;
            meth = new CustomMethod();
            meth.IsReturnTypeVoid = true;
            meth.IsStatic = false;
            meth.NumberOfParameters = 1;
            meth.Signature = "{McKesson.TPP.DataAccess.DomainModel.Entities.ClaimSet.set_Batch(McKesson.TPP.DataAccess.DomainModel.Entities.Batch)}";
            instruction.Value = meth;

            instructionList.Add(instruction);

            // CIL Instruction 64.
            instruction = new CustomInstruction();
            instruction.Offset = 192;
            instruction.OpCode = OpCode.Nop;
            instruction.Value = null;

            instructionList.Add(instruction);

            // CIL Instruction 65.
            instruction = new CustomInstruction();
            instruction.Offset = 193;
            instruction.OpCode = OpCode.Ldloc_S;
            custLocal = new CustomLocal();
            custLocal.Name = "<>g__initLocal8";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 66.
            instruction = new CustomInstruction();
            instruction.Offset = 195;
            instruction.OpCode = OpCode.Ldstr;
            instruction.Value = "{123434343323}";

            instructionList.Add(instruction);

            // CIL Instruction 67.
            instruction = new CustomInstruction();
            instruction.Offset = 200;
            instruction.OpCode = OpCode.Callvirt;
            meth = new CustomMethod();
            meth.IsReturnTypeVoid = true;
            meth.IsStatic = false;
            meth.NumberOfParameters = 1;
            meth.Signature = "{McKesson.TPP.DataAccess.DomainModel.Entities.ClaimSet.set_CustomerTransactionId(System.String)}";
            instruction.Value = meth;

            instructionList.Add(instruction);

            // CIL Instruction 68.
            instruction = new CustomInstruction();
            instruction.Offset = 205;
            instruction.OpCode = OpCode.Nop;
            instruction.Value = null;

            instructionList.Add(instruction);

            // CIL Instruction 69.
            instruction = new CustomInstruction();
            instruction.Offset = 206;
            instruction.OpCode = OpCode.Ldloc_S;
            custLocal = new CustomLocal();
            custLocal.Name = "<>g__initLocal8";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 70.
            instruction = new CustomInstruction();
            instruction.Offset = 208;
            instruction.OpCode = OpCode.Stloc_1;
            custLocal = new CustomLocal();
            custLocal.Name = "claimSet";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 71.
            instruction = new CustomInstruction();
            instruction.Offset = 209;
            instruction.OpCode = OpCode.Newobj;
            meth = new CustomMethod();
            meth.IsReturnTypeVoid = true;
            meth.IsStatic = false;
            meth.NumberOfParameters = 0;
            meth.Signature = "{System.Collections.Generic.List`1<McKesson.TPP.DataAccess.DomainModel.Entities.ClaimSet>.#ctor}";
            instruction.Value = meth;

            instructionList.Add(instruction);

            // CIL Instruction 72.
            instruction = new CustomInstruction();
            instruction.Offset = 214;
            instruction.OpCode = OpCode.Stloc_2;
            custLocal = new CustomLocal();
            custLocal.Name = "claimSetList";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 73.
            instruction = new CustomInstruction();
            instruction.Offset = 215;
            instruction.OpCode = OpCode.Ldloc_2;
            custLocal = new CustomLocal();
            custLocal.Name = "claimSetList";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 74.
            instruction = new CustomInstruction();
            instruction.Offset = 216;
            instruction.OpCode = OpCode.Ldloc_1;
            custLocal = new CustomLocal();
            custLocal.Name = "claimSet";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 75.
            instruction = new CustomInstruction();
            instruction.Offset = 217;
            instruction.OpCode = OpCode.Callvirt;
            meth = new CustomMethod();
            meth.IsReturnTypeVoid = true;
            meth.IsStatic = false;
            meth.NumberOfParameters = 1;
            meth.Signature = "{System.Collections.Generic.List`1<McKesson.TPP.DataAccess.DomainModel.Entities.ClaimSet>.Add(McKesson.TPP.DataAccess.DomainModel.Entities.ClaimSet)}";
            instruction.Value = meth;

            instructionList.Add(instruction);

            // CIL Instruction 76.
            instruction = new CustomInstruction();
            instruction.Offset = 222;
            instruction.OpCode = OpCode.Nop;
            instruction.Value = null;

            instructionList.Add(instruction);

            // CIL Instruction 77.
            instruction = new CustomInstruction();
            instruction.Offset = 223;
            instruction.OpCode = OpCode.Ldarg_0;
            instruction.Value = "{Microsoft.FxCop.Sdk.ClassNode:McKesson.TPP.BusinessLibrary.Providers.Tests.BatchMonitorProviderTest this}";

            instructionList.Add(instruction);

            // CIL Instruction 78.
            instruction = new CustomInstruction();
            instruction.Offset = 224;
            instruction.OpCode = OpCode.Ldfld;
            instruction.Value = "{McKesson.TPP.BusinessLibrary.Providers.Tests.BatchMonitorProviderTest._claimSetDao}";

            instructionList.Add(instruction);

            // CIL Instruction 79.
            instruction = new CustomInstruction();
            instruction.Offset = 229;
            instruction.OpCode = OpCode.Ldarg_0;
            instruction.Value = "{Microsoft.FxCop.Sdk.ClassNode:McKesson.TPP.BusinessLibrary.Providers.Tests.BatchMonitorProviderTest this}";

            instructionList.Add(instruction);

            // CIL Instruction 80.
            instruction = new CustomInstruction();
            instruction.Offset = 230;
            instruction.OpCode = OpCode.Ldfld;
            instruction.Value = "{McKesson.TPP.BusinessLibrary.Providers.Tests.BatchMonitorProviderTest._batchDao}";

            instructionList.Add(instruction);

            // CIL Instruction 81.
            instruction = new CustomInstruction();
            instruction.Offset = 235;
            instruction.OpCode = OpCode.Ldarg_1;
            instruction.Value = "{Microsoft.FxCop.Sdk.Struct:System.Int32 timeOutMinutes}";

            instructionList.Add(instruction);

            // CIL Instruction 82.
            instruction = new CustomInstruction();
            instruction.Offset = 236;
            instruction.OpCode = OpCode.Ldc_I4_0;
            instruction.Value = 0;

            instructionList.Add(instruction);

            // CIL Instruction 83.
            instruction = new CustomInstruction();
            instruction.Offset = 237;
            instruction.OpCode = OpCode.Newobj;
            meth = new CustomMethod();
            meth.IsReturnTypeVoid = true;
            meth.IsStatic = false;
            meth.NumberOfParameters = 4;
            meth.Signature = "{McKesson.TPP.BusinessLibrary.Providers.BatchMonitorProvider.#ctor(McKesson.TPP.DataAccess.DAL.Interfaces.IClaimSetDao,McKesson.TPP.DataAccess.DAL.Interfaces.IBatchDao,System.Int32,System.Int32)}";
            instruction.Value = meth;

            instructionList.Add(instruction);

            // CIL Instruction 84.
            instruction = new CustomInstruction();
            instruction.Offset = 242;
            instruction.OpCode = OpCode.Stloc_3;
            custLocal = new CustomLocal();
            custLocal.Name = "batchMonitorProvider";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 85.
            instruction = new CustomInstruction();
            instruction.Offset = 243;
            instruction.OpCode = OpCode.Ldc_I4_0;
            instruction.Value = 0;

            instructionList.Add(instruction);

            // CIL Instruction 86.
            instruction = new CustomInstruction();
            instruction.Offset = 244;
            instruction.OpCode = OpCode.Newarr;
            instruction.Value = "{Microsoft.FxCop.Sdk.ClassNode:System.Object}";

            instructionList.Add(instruction);

            // CIL Instruction 87.
            instruction = new CustomInstruction();
            instruction.Offset = 249;
            instruction.OpCode = OpCode.Call;
            meth = new CustomMethod();
            meth.IsReturnTypeVoid = false;
            meth.IsStatic = true;
            meth.NumberOfParameters = 1;
            meth.Signature = "{Rhino.Mocks.MockRepository.GenerateStub<McKesson.TPP.Framework.Infrastructure.NonWcfServiceHost>(System.Object[])}";
            instruction.Value = meth;

            instructionList.Add(instruction);

            // CIL Instruction 88.
            instruction = new CustomInstruction();
            instruction.Offset = 254;
            instruction.OpCode = OpCode.Stloc_S;
            custLocal = new CustomLocal();
            custLocal.Name = "serviceHostStub";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 89.
            instruction = new CustomInstruction();
            instruction.Offset = 256;
            instruction.OpCode = OpCode.Ldloc_S;
            custLocal = new CustomLocal();
            custLocal.Name = "serviceHostStub";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 90.
            instruction = new CustomInstruction();
            instruction.Offset = 258;
            instruction.OpCode = OpCode.Ldc_I4_0;
            instruction.Value = 0;

            instructionList.Add(instruction);

            // CIL Instruction 91.
            instruction = new CustomInstruction();
            instruction.Offset = 259;
            instruction.OpCode = OpCode.Volatile_;
            instruction.Value = null;

            instructionList.Add(instruction);

            // CIL Instruction 92.
            instruction = new CustomInstruction();
            instruction.Offset = 261;
            instruction.OpCode = OpCode.Stfld;
            instruction.Value = "{McKesson.TPP.Framework.Infrastructure.NonWcfServiceHost.StopRequested}";

            instructionList.Add(instruction);

            // CIL Instruction 93.
            instruction = new CustomInstruction();
            instruction.Offset = 266;
            instruction.OpCode = OpCode.Ldloc_3;
            custLocal = new CustomLocal();
            custLocal.Name = "batchMonitorProvider";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 94.
            instruction = new CustomInstruction();
            instruction.Offset = 267;
            instruction.OpCode = OpCode.Ldloc_S;
            custLocal = new CustomLocal();
            custLocal.Name = "serviceHostStub";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 95.
            instruction = new CustomInstruction();
            instruction.Offset = 269;
            instruction.OpCode = OpCode.Callvirt;
            meth = new CustomMethod();
            meth.IsReturnTypeVoid = true;
            meth.IsStatic = false;
            meth.NumberOfParameters = 1;
            meth.Signature = "{McKesson.TPP.BusinessLibrary.Providers.BatchMonitorProvider.set_ServiceHost(McKesson.TPP.Framework.Infrastructure.NonWcfServiceHost)}";
            instruction.Value = meth;

            instructionList.Add(instruction);

            // CIL Instruction 96.
            instruction = new CustomInstruction();
            instruction.Offset = 274;
            instruction.OpCode = OpCode.Nop;
            instruction.Value = null;

            instructionList.Add(instruction);

            // CIL Instruction 97.
            instruction = new CustomInstruction();
            instruction.Offset = 275;
            instruction.OpCode = OpCode.Ldarg_3;
            instruction.Value = "{Microsoft.FxCop.Sdk.Struct:System.Boolean isClaimSetTrue}";

            instructionList.Add(instruction);

            // CIL Instruction 98.
            instruction = new CustomInstruction();
            instruction.Offset = 276;
            instruction.OpCode = OpCode.Ldc_I4_0;
            instruction.Value = 0;

            instructionList.Add(instruction);

            // CIL Instruction 99.
            instruction = new CustomInstruction();
            instruction.Offset = 277;
            instruction.OpCode = OpCode.Ceq;
            instruction.Value = null;

            instructionList.Add(instruction);

            // CIL Instruction 100.
            instruction = new CustomInstruction();
            instruction.Offset = 279;
            instruction.OpCode = OpCode.Stloc_S;
            custLocal = new CustomLocal();
            custLocal.Name = "CS$4$0000";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 101.
            instruction = new CustomInstruction();
            instruction.Offset = 281;
            instruction.OpCode = OpCode.Ldloc_S;
            custLocal = new CustomLocal();
            custLocal.Name = "CS$4$0000";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 102.
            instruction = new CustomInstruction();
            instruction.Offset = 283;
            instruction.OpCode = OpCode.Brtrue_S;
            instruction.Value = 336;

            instructionList.Add(instruction);

            // CIL Instruction 103.
            instruction = new CustomInstruction();
            instruction.Offset = 285;
            instruction.OpCode = OpCode.Ldarg_0;
            instruction.Value = "{Microsoft.FxCop.Sdk.ClassNode:McKesson.TPP.BusinessLibrary.Providers.Tests.BatchMonitorProviderTest this}";

            instructionList.Add(instruction);

            // CIL Instruction 104.
            instruction = new CustomInstruction();
            instruction.Offset = 286;
            instruction.OpCode = OpCode.Ldfld;
            instruction.Value = "{McKesson.TPP.BusinessLibrary.Providers.Tests.BatchMonitorProviderTest._claimSetDao}";

            instructionList.Add(instruction);

            // CIL Instruction 105.
            instruction = new CustomInstruction();
            instruction.Offset = 291;
            instruction.OpCode = OpCode.Ldsfld;
            instruction.Value = "{McKesson.TPP.BusinessLibrary.Providers.Tests.BatchMonitorProviderTest.CS$<>9__CachedAnonymousMethodDelegatee}";

            instructionList.Add(instruction);

            // CIL Instruction 106.
            instruction = new CustomInstruction();
            instruction.Offset = 296;
            instruction.OpCode = OpCode.Brtrue_S;
            instruction.Value = 317;

            instructionList.Add(instruction);

            // CIL Instruction 107.
            instruction = new CustomInstruction();
            instruction.Offset = 298;
            instruction.OpCode = OpCode.Ldnull;
            instruction.Value = null;

            instructionList.Add(instruction);

            // CIL Instruction 108.
            instruction = new CustomInstruction();
            instruction.Offset = 299;
            instruction.OpCode = OpCode.Ldftn;
            instruction.Value = "{McKesson.TPP.BusinessLibrary.Providers.Tests.BatchMonitorProviderTest.<TestMonitorBatchTimeoutException>b__9}";

            instructionList.Add(instruction);

            // CIL Instruction 109.
            instruction = new CustomInstruction();
            instruction.Offset = 305;
            instruction.OpCode = OpCode.Newobj;
            meth = new CustomMethod();
            meth.IsReturnTypeVoid = true;
            meth.IsStatic = false;
            meth.NumberOfParameters = 2;
            meth.Signature = "{Rhino.Mocks.Function`2<McKesson.TPP.DataAccess.DAL.Interfaces.IClaimSetDao,System.Collections.Generic.IList`1<McKesson.TPP.DataAccess.DomainModel.Entities.ClaimSet>>.#ctor(System.Object,System.IntPtr)}";
            instruction.Value = meth;

            instructionList.Add(instruction);

            // CIL Instruction 110.
            instruction = new CustomInstruction();
            instruction.Offset = 310;
            instruction.OpCode = OpCode.Stsfld;
            instruction.Value = "{McKesson.TPP.BusinessLibrary.Providers.Tests.BatchMonitorProviderTest.CS$<>9__CachedAnonymousMethodDelegatee}";

            instructionList.Add(instruction);

            // CIL Instruction 111.
            instruction = new CustomInstruction();
            instruction.Offset = 315;
            instruction.OpCode = OpCode.Br_S;
            instruction.Value = 317;

            instructionList.Add(instruction);

            // CIL Instruction 112.
            instruction = new CustomInstruction();
            instruction.Offset = 317;
            instruction.OpCode = OpCode.Ldsfld;
            instruction.Value = "{McKesson.TPP.BusinessLibrary.Providers.Tests.BatchMonitorProviderTest.CS$<>9__CachedAnonymousMethodDelegatee}";

            instructionList.Add(instruction);

            // CIL Instruction 113.
            instruction = new CustomInstruction();
            instruction.Offset = 322;
            instruction.OpCode = OpCode.Call;
            meth = new CustomMethod();
            meth.IsReturnTypeVoid = false;
            meth.IsStatic = true;
            meth.NumberOfParameters = 2;
            meth.Signature = "{Rhino.Mocks.RhinoMocksExtensions.Expect<McKesson.TPP.DataAccess.DAL.Interfaces.IClaimSetDao,System.Collections.Generic.IList`1<McKesson.TPP.DataAccess.DomainModel.Entities.ClaimSet>>(McKesson.TPP.DataAccess.DAL.Interfaces.IClaimSetDao,Rhino.Mocks.Function`2<McKesson.TPP.DataAccess.DAL.Interfaces.IClaimSetDao,System.Collections.Generic.IList`1<McKesson.TPP.DataAccess.DomainModel.Entities.ClaimSet>>)}";
            instruction.Value = meth;

            instructionList.Add(instruction);

            // CIL Instruction 114.
            instruction = new CustomInstruction();
            instruction.Offset = 327;
            instruction.OpCode = OpCode.Ldloc_2;
            custLocal = new CustomLocal();
            custLocal.Name = "claimSetList";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 115.
            instruction = new CustomInstruction();
            instruction.Offset = 328;
            instruction.OpCode = OpCode.Callvirt;
            meth = new CustomMethod();
            meth.IsReturnTypeVoid = false;
            meth.IsStatic = false;
            meth.NumberOfParameters = 1;
            meth.Signature = "{Rhino.Mocks.Interfaces.IMethodOptions`1<System.Collections.Generic.IList`1<McKesson.TPP.DataAccess.DomainModel.Entities.ClaimSet>>.Return(System.Collections.Generic.IList`1<McKesson.TPP.DataAccess.DomainModel.Entities.ClaimSet>)}";
            instruction.Value = meth;

            instructionList.Add(instruction);

            // CIL Instruction 116.
            instruction = new CustomInstruction();
            instruction.Offset = 333;
            instruction.OpCode = OpCode.Pop;
            instruction.Value = null;

            instructionList.Add(instruction);

            // CIL Instruction 117.
            instruction = new CustomInstruction();
            instruction.Offset = 334;
            instruction.OpCode = OpCode.Br_S;
            instruction.Value = 385;

            instructionList.Add(instruction);

            // CIL Instruction 118.
            instruction = new CustomInstruction();
            instruction.Offset = 336;
            instruction.OpCode = OpCode.Ldarg_0;
            instruction.Value = "{Microsoft.FxCop.Sdk.ClassNode:McKesson.TPP.BusinessLibrary.Providers.Tests.BatchMonitorProviderTest this}";

            instructionList.Add(instruction);

            // CIL Instruction 119.
            instruction = new CustomInstruction();
            instruction.Offset = 337;
            instruction.OpCode = OpCode.Ldfld;
            instruction.Value = "{McKesson.TPP.BusinessLibrary.Providers.Tests.BatchMonitorProviderTest._claimSetDao}";

            instructionList.Add(instruction);

            // CIL Instruction 120.
            instruction = new CustomInstruction();
            instruction.Offset = 342;
            instruction.OpCode = OpCode.Ldsfld;
            instruction.Value = "{McKesson.TPP.BusinessLibrary.Providers.Tests.BatchMonitorProviderTest.CS$<>9__CachedAnonymousMethodDelegatef}";

            instructionList.Add(instruction);

            // CIL Instruction 121.
            instruction = new CustomInstruction();
            instruction.Offset = 347;
            instruction.OpCode = OpCode.Brtrue_S;
            instruction.Value = 368;

            instructionList.Add(instruction);

            // CIL Instruction 122.
            instruction = new CustomInstruction();
            instruction.Offset = 349;
            instruction.OpCode = OpCode.Ldnull;
            instruction.Value = null;

            instructionList.Add(instruction);

            // CIL Instruction 123.
            instruction = new CustomInstruction();
            instruction.Offset = 350;
            instruction.OpCode = OpCode.Ldftn;
            instruction.Value = "{McKesson.TPP.BusinessLibrary.Providers.Tests.BatchMonitorProviderTest.<TestMonitorBatchTimeoutException>b__a}";

            instructionList.Add(instruction);

            // CIL Instruction 124.
            instruction = new CustomInstruction();
            instruction.Offset = 356;
            instruction.OpCode = OpCode.Newobj;
            meth = new CustomMethod();
            meth.IsReturnTypeVoid = true;
            meth.IsStatic = false;
            meth.NumberOfParameters = 2;
            meth.Signature = "{Rhino.Mocks.Function`2<McKesson.TPP.DataAccess.DAL.Interfaces.IClaimSetDao,System.Collections.Generic.IList`1<McKesson.TPP.DataAccess.DomainModel.Entities.ClaimSet>>.#ctor(System.Object,System.IntPtr)}";
            instruction.Value = meth;

            instructionList.Add(instruction);

            // CIL Instruction 125.
            instruction = new CustomInstruction();
            instruction.Offset = 361;
            instruction.OpCode = OpCode.Stsfld;
            instruction.Value = "{McKesson.TPP.BusinessLibrary.Providers.Tests.BatchMonitorProviderTest.CS$<>9__CachedAnonymousMethodDelegatef}";

            instructionList.Add(instruction);

            // CIL Instruction 126.
            instruction = new CustomInstruction();
            instruction.Offset = 366;
            instruction.OpCode = OpCode.Br_S;
            instruction.Value = 368;

            instructionList.Add(instruction);

            // CIL Instruction 127.
            instruction = new CustomInstruction();
            instruction.Offset = 368;
            instruction.OpCode = OpCode.Ldsfld;
            instruction.Value = "{McKesson.TPP.BusinessLibrary.Providers.Tests.BatchMonitorProviderTest.CS$<>9__CachedAnonymousMethodDelegatef}";

            instructionList.Add(instruction);

            // CIL Instruction 128.
            instruction = new CustomInstruction();
            instruction.Offset = 373;
            instruction.OpCode = OpCode.Call;
            meth = new CustomMethod();
            meth.IsReturnTypeVoid = false;
            meth.IsStatic = true;
            meth.NumberOfParameters = 2;
            meth.Signature = "{Rhino.Mocks.RhinoMocksExtensions.Expect<McKesson.TPP.DataAccess.DAL.Interfaces.IClaimSetDao,System.Collections.Generic.IList`1<McKesson.TPP.DataAccess.DomainModel.Entities.ClaimSet>>(McKesson.TPP.DataAccess.DAL.Interfaces.IClaimSetDao,Rhino.Mocks.Function`2<McKesson.TPP.DataAccess.DAL.Interfaces.IClaimSetDao,System.Collections.Generic.IList`1<McKesson.TPP.DataAccess.DomainModel.Entities.ClaimSet>>)}";
            instruction.Value = meth;

            instructionList.Add(instruction);

            // CIL Instruction 129.
            instruction = new CustomInstruction();
            instruction.Offset = 378;
            instruction.OpCode = OpCode.Ldnull;
            instruction.Value = null;

            instructionList.Add(instruction);

            // CIL Instruction 130.
            instruction = new CustomInstruction();
            instruction.Offset = 379;
            instruction.OpCode = OpCode.Callvirt;
            meth = new CustomMethod();
            meth.IsReturnTypeVoid = false;
            meth.IsStatic = false;
            meth.NumberOfParameters = 1;
            meth.Signature = "{Rhino.Mocks.Interfaces.IMethodOptions`1<System.Collections.Generic.IList`1<McKesson.TPP.DataAccess.DomainModel.Entities.ClaimSet>>.Return(System.Collections.Generic.IList`1<McKesson.TPP.DataAccess.DomainModel.Entities.ClaimSet>)}";
            instruction.Value = meth;

            instructionList.Add(instruction);

            // CIL Instruction 131.
            instruction = new CustomInstruction();
            instruction.Offset = 384;
            instruction.OpCode = OpCode.Pop;
            instruction.Value = null;

            instructionList.Add(instruction);

            // CIL Instruction 132.
            instruction = new CustomInstruction();
            instruction.Offset = 385;
            instruction.OpCode = OpCode.Ldarg_2;
            instruction.Value = "{Microsoft.FxCop.Sdk.Struct:System.Boolean isBatchTrue}";

            instructionList.Add(instruction);

            // CIL Instruction 133.
            instruction = new CustomInstruction();
            instruction.Offset = 386;
            instruction.OpCode = OpCode.Ldc_I4_0;
            instruction.Value = 0;

            instructionList.Add(instruction);

            // CIL Instruction 134.
            instruction = new CustomInstruction();
            instruction.Offset = 387;
            instruction.OpCode = OpCode.Ceq;
            instruction.Value = null;

            instructionList.Add(instruction);

            // CIL Instruction 135.
            instruction = new CustomInstruction();
            instruction.Offset = 389;
            instruction.OpCode = OpCode.Stloc_S;
            custLocal = new CustomLocal();
            custLocal.Name = "CS$4$0000";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 136.
            instruction = new CustomInstruction();
            instruction.Offset = 391;
            instruction.OpCode = OpCode.Ldloc_S;
            custLocal = new CustomLocal();
            custLocal.Name = "CS$4$0000";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 137.
            instruction = new CustomInstruction();
            instruction.Offset = 393;
            instruction.OpCode = OpCode.Brtrue_S;
            instruction.Value = 446;

            instructionList.Add(instruction);

            // CIL Instruction 138.
            instruction = new CustomInstruction();
            instruction.Offset = 395;
            instruction.OpCode = OpCode.Ldarg_0;
            instruction.Value = "{Microsoft.FxCop.Sdk.ClassNode:McKesson.TPP.BusinessLibrary.Providers.Tests.BatchMonitorProviderTest this}";

            instructionList.Add(instruction);

            // CIL Instruction 139.
            instruction = new CustomInstruction();
            instruction.Offset = 396;
            instruction.OpCode = OpCode.Ldfld;
            instruction.Value = "{McKesson.TPP.BusinessLibrary.Providers.Tests.BatchMonitorProviderTest._batchDao}";

            instructionList.Add(instruction);

            // CIL Instruction 140.
            instruction = new CustomInstruction();
            instruction.Offset = 401;
            instruction.OpCode = OpCode.Ldsfld;
            instruction.Value = "{McKesson.TPP.BusinessLibrary.Providers.Tests.BatchMonitorProviderTest.CS$<>9__CachedAnonymousMethodDelegate10}";

            instructionList.Add(instruction);

            // CIL Instruction 141.
            instruction = new CustomInstruction();
            instruction.Offset = 406;
            instruction.OpCode = OpCode.Brtrue_S;
            instruction.Value = 427;

            instructionList.Add(instruction);

            // CIL Instruction 142.
            instruction = new CustomInstruction();
            instruction.Offset = 408;
            instruction.OpCode = OpCode.Ldnull;
            instruction.Value = null;

            instructionList.Add(instruction);

            // CIL Instruction 143.
            instruction = new CustomInstruction();
            instruction.Offset = 409;
            instruction.OpCode = OpCode.Ldftn;
            instruction.Value = "{McKesson.TPP.BusinessLibrary.Providers.Tests.BatchMonitorProviderTest.<TestMonitorBatchTimeoutException>b__b}";

            instructionList.Add(instruction);

            // CIL Instruction 144.
            instruction = new CustomInstruction();
            instruction.Offset = 415;
            instruction.OpCode = OpCode.Newobj;
            meth = new CustomMethod();
            meth.IsReturnTypeVoid = true;
            meth.IsStatic = false;
            meth.NumberOfParameters = 2;
            meth.Signature = "{Rhino.Mocks.Function`2<McKesson.TPP.DataAccess.DAL.Interfaces.IBatchDao,McKesson.TPP.DataAccess.DomainModel.Entities.Batch>.#ctor(System.Object,System.IntPtr)}";
            instruction.Value = meth;

            instructionList.Add(instruction);

            // CIL Instruction 145.
            instruction = new CustomInstruction();
            instruction.Offset = 420;
            instruction.OpCode = OpCode.Stsfld;
            instruction.Value = "{McKesson.TPP.BusinessLibrary.Providers.Tests.BatchMonitorProviderTest.CS$<>9__CachedAnonymousMethodDelegate10}";

            instructionList.Add(instruction);

            // CIL Instruction 146.
            instruction = new CustomInstruction();
            instruction.Offset = 425;
            instruction.OpCode = OpCode.Br_S;
            instruction.Value = 427;

            instructionList.Add(instruction);

            // CIL Instruction 147.
            instruction = new CustomInstruction();
            instruction.Offset = 427;
            instruction.OpCode = OpCode.Ldsfld;
            instruction.Value = "{McKesson.TPP.BusinessLibrary.Providers.Tests.BatchMonitorProviderTest.CS$<>9__CachedAnonymousMethodDelegate10}";

            instructionList.Add(instruction);

            // CIL Instruction 148.
            instruction = new CustomInstruction();
            instruction.Offset = 432;
            instruction.OpCode = OpCode.Call;
            meth = new CustomMethod();
            meth.IsReturnTypeVoid = false;
            meth.IsStatic = true;
            meth.NumberOfParameters = 2;
            meth.Signature = "{Rhino.Mocks.RhinoMocksExtensions.Expect<McKesson.TPP.DataAccess.DAL.Interfaces.IBatchDao,McKesson.TPP.DataAccess.DomainModel.Entities.Batch>(McKesson.TPP.DataAccess.DAL.Interfaces.IBatchDao,Rhino.Mocks.Function`2<McKesson.TPP.DataAccess.DAL.Interfaces.IBatchDao,McKesson.TPP.DataAccess.DomainModel.Entities.Batch>)}";
            instruction.Value = meth;

            instructionList.Add(instruction);

            // CIL Instruction 149.
            instruction = new CustomInstruction();
            instruction.Offset = 437;
            instruction.OpCode = OpCode.Ldloc_0;
            custLocal = new CustomLocal();
            custLocal.Name = "batch";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 150.
            instruction = new CustomInstruction();
            instruction.Offset = 438;
            instruction.OpCode = OpCode.Callvirt;
            meth = new CustomMethod();
            meth.IsReturnTypeVoid = false;
            meth.IsStatic = false;
            meth.NumberOfParameters = 1;
            meth.Signature = "{Rhino.Mocks.Interfaces.IMethodOptions`1<McKesson.TPP.DataAccess.DomainModel.Entities.Batch>.Return(McKesson.TPP.DataAccess.DomainModel.Entities.Batch)}";
            instruction.Value = meth;

            instructionList.Add(instruction);

            // CIL Instruction 151.
            instruction = new CustomInstruction();
            instruction.Offset = 443;
            instruction.OpCode = OpCode.Pop;
            instruction.Value = null;

            instructionList.Add(instruction);

            // CIL Instruction 152.
            instruction = new CustomInstruction();
            instruction.Offset = 444;
            instruction.OpCode = OpCode.Br_S;
            instruction.Value = 495;

            instructionList.Add(instruction);

            // CIL Instruction 153.
            instruction = new CustomInstruction();
            instruction.Offset = 446;
            instruction.OpCode = OpCode.Ldarg_0;
            instruction.Value = "{Microsoft.FxCop.Sdk.ClassNode:McKesson.TPP.BusinessLibrary.Providers.Tests.BatchMonitorProviderTest this}";

            instructionList.Add(instruction);

            // CIL Instruction 154.
            instruction = new CustomInstruction();
            instruction.Offset = 447;
            instruction.OpCode = OpCode.Ldfld;
            instruction.Value = "{McKesson.TPP.BusinessLibrary.Providers.Tests.BatchMonitorProviderTest._batchDao}";

            instructionList.Add(instruction);

            // CIL Instruction 155.
            instruction = new CustomInstruction();
            instruction.Offset = 452;
            instruction.OpCode = OpCode.Ldsfld;
            instruction.Value = "{McKesson.TPP.BusinessLibrary.Providers.Tests.BatchMonitorProviderTest.CS$<>9__CachedAnonymousMethodDelegate11}";

            instructionList.Add(instruction);

            // CIL Instruction 156.
            instruction = new CustomInstruction();
            instruction.Offset = 457;
            instruction.OpCode = OpCode.Brtrue_S;
            instruction.Value = 478;

            instructionList.Add(instruction);

            // CIL Instruction 157.
            instruction = new CustomInstruction();
            instruction.Offset = 459;
            instruction.OpCode = OpCode.Ldnull;
            instruction.Value = null;

            instructionList.Add(instruction);

            // CIL Instruction 158.
            instruction = new CustomInstruction();
            instruction.Offset = 460;
            instruction.OpCode = OpCode.Ldftn;
            instruction.Value = "{McKesson.TPP.BusinessLibrary.Providers.Tests.BatchMonitorProviderTest.<TestMonitorBatchTimeoutException>b__c}";

            instructionList.Add(instruction);

            // CIL Instruction 159.
            instruction = new CustomInstruction();
            instruction.Offset = 466;
            instruction.OpCode = OpCode.Newobj;
            meth = new CustomMethod();
            meth.IsReturnTypeVoid = true;
            meth.IsStatic = false;
            meth.NumberOfParameters = 2;
            meth.Signature = "{Rhino.Mocks.Function`2<McKesson.TPP.DataAccess.DAL.Interfaces.IBatchDao,McKesson.TPP.DataAccess.DomainModel.Entities.Batch>.#ctor(System.Object,System.IntPtr)}";
            instruction.Value = meth;

            instructionList.Add(instruction);

            // CIL Instruction 160.
            instruction = new CustomInstruction();
            instruction.Offset = 471;
            instruction.OpCode = OpCode.Stsfld;
            instruction.Value = "{McKesson.TPP.BusinessLibrary.Providers.Tests.BatchMonitorProviderTest.CS$<>9__CachedAnonymousMethodDelegate11}";

            instructionList.Add(instruction);

            // CIL Instruction 161.
            instruction = new CustomInstruction();
            instruction.Offset = 476;
            instruction.OpCode = OpCode.Br_S;
            instruction.Value = 478;

            instructionList.Add(instruction);

            // CIL Instruction 162.
            instruction = new CustomInstruction();
            instruction.Offset = 478;
            instruction.OpCode = OpCode.Ldsfld;
            instruction.Value = "{McKesson.TPP.BusinessLibrary.Providers.Tests.BatchMonitorProviderTest.CS$<>9__CachedAnonymousMethodDelegate11}";

            instructionList.Add(instruction);

            // CIL Instruction 163.
            instruction = new CustomInstruction();
            instruction.Offset = 483;
            instruction.OpCode = OpCode.Call;
            meth = new CustomMethod();
            meth.IsReturnTypeVoid = false;
            meth.IsStatic = true;
            meth.NumberOfParameters = 2;
            meth.Signature = "{Rhino.Mocks.RhinoMocksExtensions.Expect<McKesson.TPP.DataAccess.DAL.Interfaces.IBatchDao,McKesson.TPP.DataAccess.DomainModel.Entities.Batch>(McKesson.TPP.DataAccess.DAL.Interfaces.IBatchDao,Rhino.Mocks.Function`2<McKesson.TPP.DataAccess.DAL.Interfaces.IBatchDao,McKesson.TPP.DataAccess.DomainModel.Entities.Batch>)}";
            instruction.Value = meth;

            instructionList.Add(instruction);

            // CIL Instruction 164.
            instruction = new CustomInstruction();
            instruction.Offset = 488;
            instruction.OpCode = OpCode.Ldnull;
            instruction.Value = null;

            instructionList.Add(instruction);

            // CIL Instruction 165.
            instruction = new CustomInstruction();
            instruction.Offset = 489;
            instruction.OpCode = OpCode.Callvirt;
            meth = new CustomMethod();
            meth.IsReturnTypeVoid = false;
            meth.IsStatic = false;
            meth.NumberOfParameters = 1;
            meth.Signature = "{Rhino.Mocks.Interfaces.IMethodOptions`1<McKesson.TPP.DataAccess.DomainModel.Entities.Batch>.Return(McKesson.TPP.DataAccess.DomainModel.Entities.Batch)}";
            instruction.Value = meth;

            instructionList.Add(instruction);

            // CIL Instruction 166.
            instruction = new CustomInstruction();
            instruction.Offset = 494;
            instruction.OpCode = OpCode.Pop;
            instruction.Value = null;

            instructionList.Add(instruction);

            // CIL Instruction 167.
            instruction = new CustomInstruction();
            instruction.Offset = 495;
            instruction.OpCode = OpCode.Ldarg_0;
            instruction.Value = "{Microsoft.FxCop.Sdk.ClassNode:McKesson.TPP.BusinessLibrary.Providers.Tests.BatchMonitorProviderTest this}";

            instructionList.Add(instruction);

            // CIL Instruction 168.
            instruction = new CustomInstruction();
            instruction.Offset = 496;
            instruction.OpCode = OpCode.Ldfld;
            instruction.Value = "{McKesson.TPP.BusinessLibrary.Providers.Tests.BatchMonitorProviderTest._batchDao}";

            instructionList.Add(instruction);

            // CIL Instruction 169.
            instruction = new CustomInstruction();
            instruction.Offset = 501;
            instruction.OpCode = OpCode.Ldsfld;
            instruction.Value = "{McKesson.TPP.BusinessLibrary.Providers.Tests.BatchMonitorProviderTest.CS$<>9__CachedAnonymousMethodDelegate12}";

            instructionList.Add(instruction);

            // CIL Instruction 170.
            instruction = new CustomInstruction();
            instruction.Offset = 506;
            instruction.OpCode = OpCode.Brtrue_S;
            instruction.Value = 527;

            instructionList.Add(instruction);

            // CIL Instruction 171.
            instruction = new CustomInstruction();
            instruction.Offset = 508;
            instruction.OpCode = OpCode.Ldnull;
            instruction.Value = null;

            instructionList.Add(instruction);

            // CIL Instruction 172.
            instruction = new CustomInstruction();
            instruction.Offset = 509;
            instruction.OpCode = OpCode.Ldftn;
            instruction.Value = "{McKesson.TPP.BusinessLibrary.Providers.Tests.BatchMonitorProviderTest.<TestMonitorBatchTimeoutException>b__d}";

            instructionList.Add(instruction);

            // CIL Instruction 173.
            instruction = new CustomInstruction();
            instruction.Offset = 515;
            instruction.OpCode = OpCode.Newobj;
            meth = new CustomMethod();
            meth.IsReturnTypeVoid = true;
            meth.IsStatic = false;
            meth.NumberOfParameters = 2;
            meth.Signature = "{Rhino.Mocks.Function`2<McKesson.TPP.DataAccess.DAL.Interfaces.IBatchDao,McKesson.TPP.DataAccess.DomainModel.Entities.Batch>.#ctor(System.Object,System.IntPtr)}";
            instruction.Value = meth;

            instructionList.Add(instruction);

            // CIL Instruction 174.
            instruction = new CustomInstruction();
            instruction.Offset = 520;
            instruction.OpCode = OpCode.Stsfld;
            instruction.Value = "{McKesson.TPP.BusinessLibrary.Providers.Tests.BatchMonitorProviderTest.CS$<>9__CachedAnonymousMethodDelegate12}";

            instructionList.Add(instruction);

            // CIL Instruction 175.
            instruction = new CustomInstruction();
            instruction.Offset = 525;
            instruction.OpCode = OpCode.Br_S;
            instruction.Value = 527;

            instructionList.Add(instruction);

            // CIL Instruction 176.
            instruction = new CustomInstruction();
            instruction.Offset = 527;
            instruction.OpCode = OpCode.Ldsfld;
            instruction.Value = "{McKesson.TPP.BusinessLibrary.Providers.Tests.BatchMonitorProviderTest.CS$<>9__CachedAnonymousMethodDelegate12}";

            instructionList.Add(instruction);

            // CIL Instruction 177.
            instruction = new CustomInstruction();
            instruction.Offset = 532;
            instruction.OpCode = OpCode.Call;
            meth = new CustomMethod();
            meth.IsReturnTypeVoid = false;
            meth.IsStatic = true;
            meth.NumberOfParameters = 2;
            meth.Signature = "{Rhino.Mocks.RhinoMocksExtensions.Expect<McKesson.TPP.DataAccess.DAL.Interfaces.IBatchDao,McKesson.TPP.DataAccess.DomainModel.Entities.Batch>(McKesson.TPP.DataAccess.DAL.Interfaces.IBatchDao,Rhino.Mocks.Function`2<McKesson.TPP.DataAccess.DAL.Interfaces.IBatchDao,McKesson.TPP.DataAccess.DomainModel.Entities.Batch>)}";
            instruction.Value = meth;

            instructionList.Add(instruction);

            // CIL Instruction 178.
            instruction = new CustomInstruction();
            instruction.Offset = 537;
            instruction.OpCode = OpCode.Ldloc_0;
            custLocal = new CustomLocal();
            custLocal.Name = "batch";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 179.
            instruction = new CustomInstruction();
            instruction.Offset = 538;
            instruction.OpCode = OpCode.Callvirt;
            meth = new CustomMethod();
            meth.IsReturnTypeVoid = false;
            meth.IsStatic = false;
            meth.NumberOfParameters = 1;
            meth.Signature = "{Rhino.Mocks.Interfaces.IMethodOptions`1<McKesson.TPP.DataAccess.DomainModel.Entities.Batch>.Return(McKesson.TPP.DataAccess.DomainModel.Entities.Batch)}";
            instruction.Value = meth;

            instructionList.Add(instruction);

            // CIL Instruction 180.
            instruction = new CustomInstruction();
            instruction.Offset = 543;
            instruction.OpCode = OpCode.Pop;
            instruction.Value = null;

            instructionList.Add(instruction);

            // CIL Instruction 181.
            instruction = new CustomInstruction();
            instruction.Offset = 544;
            instruction.OpCode = OpCode.Ldloc_3;
            custLocal = new CustomLocal();
            custLocal.Name = "batchMonitorProvider";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 182.
            instruction = new CustomInstruction();
            instruction.Offset = 545;
            instruction.OpCode = OpCode.Ldc_I4_1;
            instruction.Value = 1;

            instructionList.Add(instruction);

            // CIL Instruction 183.
            instruction = new CustomInstruction();
            instruction.Offset = 546;
            instruction.OpCode = OpCode.Conv_I8;
            instruction.Value = null;

            instructionList.Add(instruction);

            // CIL Instruction 184.
            instruction = new CustomInstruction();
            instruction.Offset = 547;
            instruction.OpCode = OpCode.Ldc_I4_S;
            instruction.Value = 100;

            instructionList.Add(instruction);

            // CIL Instruction 185.
            instruction = new CustomInstruction();
            instruction.Offset = 549;
            instruction.OpCode = OpCode.Conv_I8;
            instruction.Value = null;

            instructionList.Add(instruction);

            // CIL Instruction 186.
            instruction = new CustomInstruction();
            instruction.Offset = 550;
            instruction.OpCode = OpCode.Callvirt;
            meth = new CustomMethod();
            meth.IsReturnTypeVoid = false;
            meth.IsStatic = false;
            meth.NumberOfParameters = 2;
            meth.Signature = "{McKesson.TPP.BusinessLibrary.Providers.BatchMonitorProvider.MonitorBatch(System.Int64,System.Int64)}";
            instruction.Value = meth;

            instructionList.Add(instruction);

            // CIL Instruction 187.
            instruction = new CustomInstruction();
            instruction.Offset = 555;
            instruction.OpCode = OpCode.Stloc_S;
            custLocal = new CustomLocal();
            custLocal.Name = "ret";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 188.
            instruction = new CustomInstruction();
            instruction.Offset = 557;
            instruction.OpCode = OpCode.Ldloc_S;
            custLocal = new CustomLocal();
            custLocal.Name = "ret";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 189.
            instruction = new CustomInstruction();
            instruction.Offset = 559;
            instruction.OpCode = OpCode.Box;
            instruction.Value = "{Microsoft.FxCop.Sdk.Struct:System.Boolean}";

            instructionList.Add(instruction);

            // CIL Instruction 190.
            instruction = new CustomInstruction();
            instruction.Offset = 564;
            instruction.OpCode = OpCode.Ldc_I4_0;
            instruction.Value = 0;

            instructionList.Add(instruction);

            // CIL Instruction 191.
            instruction = new CustomInstruction();
            instruction.Offset = 565;
            instruction.OpCode = OpCode.Box;
            instruction.Value = "{Microsoft.FxCop.Sdk.Struct:System.Boolean}";

            instructionList.Add(instruction);

            // CIL Instruction 192.
            instruction = new CustomInstruction();
            instruction.Offset = 570;
            instruction.OpCode = OpCode.Call;
            meth = new CustomMethod();
            meth.IsReturnTypeVoid = true;
            meth.IsStatic = true;
            meth.NumberOfParameters = 2;
            meth.Signature = "{NUnit.Framework.Assert.AreEqual(System.Object,System.Object)}";
            instruction.Value = meth;

            instructionList.Add(instruction);

            // CIL Instruction 193.
            instruction = new CustomInstruction();
            instruction.Offset = 575;
            instruction.OpCode = OpCode.Nop;
            instruction.Value = null;

            instructionList.Add(instruction);

            // CIL Instruction 194.
            instruction = new CustomInstruction();
            instruction.Offset = 576;
            instruction.OpCode = OpCode.Ret;
            instruction.Value = null;

            instructionList.Add(instruction);

            return instructionList;
        }

        #endregion


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

            CustomInstruction instruction;
            CustomMethod meth;
            CustomLocal custLocal;

            // CIL Instruction 1.
            instruction = new CustomInstruction();
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
            instruction.Value = "{Microsoft.FxCop.Sdk.ClassNode:Srl.FxCop.CustomDeveloperTestRules.TestTargets.DoNotInvokeRhinoMocksVerifyAllExpectationsWithoutSettingExpectationsTarget this}";

            instructionList.Add(instruction);

            // CIL Instruction 4.
            instruction = new CustomInstruction();
            instruction.Offset = 2;
            instruction.OpCode = OpCode.Ldfld;
            instruction.Value = "{Srl.FxCop.CustomDeveloperTestRules.TestTargets.DoNotInvokeRhinoMocksVerifyAllExpectationsWithoutSettingExpectationsTarget._barMock}";

            instructionList.Add(instruction);

            // CIL Instruction 5.
            instruction = new CustomInstruction();
            instruction.Offset = 7;
            instruction.OpCode = OpCode.Ldsfld;
            instruction.Value = "{Srl.FxCop.CustomDeveloperTestRules.TestTargets.DoNotInvokeRhinoMocksVerifyAllExpectationsWithoutSettingExpectationsTarget.CS$<>9__CachedAnonymousMethodDelegate1}";

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
            instruction.Value = "{Srl.FxCop.CustomDeveloperTestRules.TestTargets.DoNotInvokeRhinoMocksVerifyAllExpectationsWithoutSettingExpectationsTarget.<TestMethodWhereVerifyAllExpectationsOnAMockIsInvokedAndAnExpectationIsSet>b__0}";

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
            meth = new CustomMethod();
            meth.IsReturnTypeVoid = false;
            meth.IsStatic = true;
            meth.NumberOfParameters = 2;
            meth.Signature = "{Rhino.Mocks.RhinoMocksExtensions.Expect<Srl.FxCop.CustomDeveloperTestRules.TestTargets.IBar>(Srl.FxCop.CustomDeveloperTestRules.TestTargets.IBar,System.Action`1<Srl.FxCop.CustomDeveloperTestRules.TestTargets.IBar>)}";
            instruction.Value = meth;

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
            instruction.Value = "{Microsoft.FxCop.Sdk.ClassNode:Srl.FxCop.CustomDeveloperTestRules.TestTargets.DoNotInvokeRhinoMocksVerifyAllExpectationsWithoutSettingExpectationsTarget this}";

            instructionList.Add(instruction);

            // CIL Instruction 16.
            instruction = new CustomInstruction();
            instruction.Offset = 45;
            instruction.OpCode = OpCode.Ldfld;
            instruction.Value = "{Srl.FxCop.CustomDeveloperTestRules.TestTargets.DoNotInvokeRhinoMocksVerifyAllExpectationsWithoutSettingExpectationsTarget._barMock}";

            instructionList.Add(instruction);

            // CIL Instruction 17.
            instruction = new CustomInstruction();
            instruction.Offset = 50;
            instruction.OpCode = OpCode.Call;
            meth = new CustomMethod();
            meth.IsReturnTypeVoid = true;
            meth.IsStatic = true;
            meth.NumberOfParameters = 1;
            meth.Signature = "{Rhino.Mocks.RhinoMocksExtensions.VerifyAllExpectations(System.Object)}";
            instruction.Value = meth;

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


        private IList<CustomInstruction> CheckCommandParameterTest()
        {
            IList<CustomInstruction> instructionList = new List<CustomInstruction>();

            CustomInstruction instruction;
            CustomMethod meth;
            CustomLocal custLocal;

            // CIL Instruction 1.
            instruction = new CustomInstruction();
            instruction.Offset = 0;
            instruction.OpCode = OpCode._Locals;
            instruction.Value = "{Microsoft.FxCop.Sdk.LocalCollection}";

            instructionList.Add(instruction);

            // CIL Instruction 2.
            instruction = new CustomInstruction();
            instruction.Offset = 0;
            instruction.OpCode = OpCode.Ldnull;
            instruction.Value = null;

            instructionList.Add(instruction);

            // CIL Instruction 3.
            instruction = new CustomInstruction();
            instruction.Offset = 1;
            instruction.OpCode = OpCode.Stloc_S;
            custLocal = new CustomLocal();
            custLocal.Name = "CS$<>9__CachedAnonymousMethodDelegate5";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 4.
            instruction = new CustomInstruction();
            instruction.Offset = 3;
            instruction.OpCode = OpCode.Newobj;
            instruction.Value = "{McKesson.TPP.Tools.DBBuild.Test.Console.ArgumentsValidatorTest+<>c__DisplayClass6(Microsoft.FxCop.Sdk.ParameterCollection)}";

            instructionList.Add(instruction);

            // CIL Instruction 5.
            instruction = new CustomInstruction();
            instruction.Offset = 8;
            instruction.OpCode = OpCode.Stloc_S;
            custLocal = new CustomLocal();
            custLocal.Name = "CS$<>8__locals7";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 6.
            instruction = new CustomInstruction();
            instruction.Offset = 10;
            instruction.OpCode = OpCode.Nop;
            instruction.Value = null;

            instructionList.Add(instruction);

            // CIL Instruction 7.
            instruction = new CustomInstruction();
            instruction.Offset = 11;
            instruction.OpCode = OpCode.Ldc_I4_0;
            instruction.Value = 0;

            instructionList.Add(instruction);

            // CIL Instruction 8.
            instruction = new CustomInstruction();
            instruction.Offset = 12;
            instruction.OpCode = OpCode.Stloc_0;
            custLocal = new CustomLocal();
            custLocal.Name = "bDirectoryCreated";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 9.
            instruction = new CustomInstruction();
            instruction.Offset = 13;
            instruction.OpCode = OpCode.Call;
            meth = new CustomMethod();
            meth.IsReturnTypeVoid = false;
            meth.IsStatic = true;
            meth.NumberOfParameters = 0;
            meth.Signature = "{System.IO.Path.GetTempPath}";
            instruction.Value = meth;

            instructionList.Add(instruction);

            // CIL Instruction 10.
            instruction = new CustomInstruction();
            instruction.Offset = 18;
            instruction.OpCode = OpCode.Stloc_1;
            custLocal = new CustomLocal();
            custLocal.Name = "projectPath";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 11.
            instruction = new CustomInstruction();
            instruction.Offset = 19;
            instruction.OpCode = OpCode.Ldloc_S;
            custLocal = new CustomLocal();
            custLocal.Name = "CS$<>8__locals7";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 12.
            instruction = new CustomInstruction();
            instruction.Offset = 21;
            instruction.OpCode = OpCode.Ldc_I4_3;
            instruction.Value = 3;

            instructionList.Add(instruction);

            // CIL Instruction 13.
            instruction = new CustomInstruction();
            instruction.Offset = 22;
            instruction.OpCode = OpCode.Newarr;
            instruction.Value = "{Microsoft.FxCop.Sdk.ClassNode:System.String}";

            instructionList.Add(instruction);

            // CIL Instruction 14.
            instruction = new CustomInstruction();
            instruction.Offset = 27;
            instruction.OpCode = OpCode.Stloc_S;
            custLocal = new CustomLocal();
            custLocal.Name = "CS$0$0000";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 15.
            instruction = new CustomInstruction();
            instruction.Offset = 29;
            instruction.OpCode = OpCode.Ldloc_S;
            custLocal = new CustomLocal();
            custLocal.Name = "CS$0$0000";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 16.
            instruction = new CustomInstruction();
            instruction.Offset = 31;
            instruction.OpCode = OpCode.Ldc_I4_0;
            instruction.Value = 0;

            instructionList.Add(instruction);

            // CIL Instruction 17.
            instruction = new CustomInstruction();
            instruction.Offset = 32;
            instruction.OpCode = OpCode.Ldstr;
            instruction.Value = "{Framework}";

            instructionList.Add(instruction);

            // CIL Instruction 18.
            instruction = new CustomInstruction();
            instruction.Offset = 37;
            instruction.OpCode = OpCode.Stelem_Ref;
            instruction.Value = null;

            instructionList.Add(instruction);

            // CIL Instruction 19.
            instruction = new CustomInstruction();
            instruction.Offset = 38;
            instruction.OpCode = OpCode.Ldloc_S;
            custLocal = new CustomLocal();
            custLocal.Name = "CS$0$0000";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 20.
            instruction = new CustomInstruction();
            instruction.Offset = 40;
            instruction.OpCode = OpCode.Ldc_I4_1;
            instruction.Value = 1;

            instructionList.Add(instruction);

            // CIL Instruction 21.
            instruction = new CustomInstruction();
            instruction.Offset = 41;
            instruction.OpCode = OpCode.Ldarg_0;
            instruction.Value = "{Microsoft.FxCop.Sdk.ClassNode:McKesson.TPP.Tools.DBBuild.Test.Console.ArgumentsValidatorTest this}";

            instructionList.Add(instruction);

            // CIL Instruction 22.
            instruction = new CustomInstruction();
            instruction.Offset = 42;
            instruction.OpCode = OpCode.Ldfld;
            instruction.Value = "{McKesson.TPP.Tools.DBBuild.Test.Console.ArgumentsValidatorTest._oraCredentials}";

            instructionList.Add(instruction);

            // CIL Instruction 23.
            instruction = new CustomInstruction();
            instruction.Offset = 47;
            instruction.OpCode = OpCode.Stelem_Ref;
            instruction.Value = null;

            instructionList.Add(instruction);

            // CIL Instruction 24.
            instruction = new CustomInstruction();
            instruction.Offset = 48;
            instruction.OpCode = OpCode.Ldloc_S;
            custLocal = new CustomLocal();
            custLocal.Name = "CS$0$0000";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 25.
            instruction = new CustomInstruction();
            instruction.Offset = 50;
            instruction.OpCode = OpCode.Ldc_I4_2;
            instruction.Value = 2;

            instructionList.Add(instruction);

            // CIL Instruction 26.
            instruction = new CustomInstruction();
            instruction.Offset = 51;
            instruction.OpCode = OpCode.Ldstr;
            instruction.Value = "{someUnknownCommand}";

            instructionList.Add(instruction);

            // CIL Instruction 27.
            instruction = new CustomInstruction();
            instruction.Offset = 56;
            instruction.OpCode = OpCode.Stelem_Ref;
            instruction.Value = null;

            instructionList.Add(instruction);

            // CIL Instruction 28.
            instruction = new CustomInstruction();
            instruction.Offset = 57;
            instruction.OpCode = OpCode.Ldloc_S;
            custLocal = new CustomLocal();
            custLocal.Name = "CS$0$0000";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 29.
            instruction = new CustomInstruction();
            instruction.Offset = 59;
            instruction.OpCode = OpCode.Stfld;
            instruction.Value = "{McKesson.TPP.Tools.DBBuild.Test.Console.ArgumentsValidatorTest+<>c__DisplayClass6.args}";

            instructionList.Add(instruction);

            // CIL Instruction 30.
            instruction = new CustomInstruction();
            instruction.Offset = 64;
            instruction.OpCode = OpCode.Ldloc_1;
            custLocal = new CustomLocal();
            custLocal.Name = "projectPath";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 31.
            instruction = new CustomInstruction();
            instruction.Offset = 65;
            instruction.OpCode = OpCode.Ldloc_S;
            custLocal = new CustomLocal();
            custLocal.Name = "CS$<>8__locals7";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 32.
            instruction = new CustomInstruction();
            instruction.Offset = 67;
            instruction.OpCode = OpCode.Ldfld;
            instruction.Value = "{McKesson.TPP.Tools.DBBuild.Test.Console.ArgumentsValidatorTest+<>c__DisplayClass6.args}";

            instructionList.Add(instruction);

            // CIL Instruction 33.
            instruction = new CustomInstruction();
            instruction.Offset = 72;
            instruction.OpCode = OpCode.Ldc_I4_0;
            instruction.Value = 0;

            instructionList.Add(instruction);

            // CIL Instruction 34.
            instruction = new CustomInstruction();
            instruction.Offset = 73;
            instruction.OpCode = OpCode.Ldelem_Ref;
            instruction.Value = null;

            instructionList.Add(instruction);

            // CIL Instruction 35.
            instruction = new CustomInstruction();
            instruction.Offset = 74;
            instruction.OpCode = OpCode.Call;
            meth = new CustomMethod();
            meth.IsReturnTypeVoid = false;
            meth.IsStatic = true;
            meth.NumberOfParameters = 2;
            meth.Signature = "{System.IO.Path.Combine(System.String,System.String)}";
            instruction.Value = meth;

            instructionList.Add(instruction);

            // CIL Instruction 36.
            instruction = new CustomInstruction();
            instruction.Offset = 79;
            instruction.OpCode = OpCode.Stloc_2;
            custLocal = new CustomLocal();
            custLocal.Name = "path";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 37.
            instruction = new CustomInstruction();
            instruction.Offset = 80;
            instruction.OpCode = OpCode.Newobj;
            instruction.Value = "{McKesson.TPP.Tools.DBBuild.Lib.Entities.Settings(Microsoft.FxCop.Sdk.ParameterCollection)}";

            instructionList.Add(instruction);

            // CIL Instruction 38.
            instruction = new CustomInstruction();
            instruction.Offset = 85;
            instruction.OpCode = OpCode.Stloc_S;
            custLocal = new CustomLocal();
            custLocal.Name = "<>g__initLocal2";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 39.
            instruction = new CustomInstruction();
            instruction.Offset = 87;
            instruction.OpCode = OpCode.Ldloc_S;
            custLocal = new CustomLocal();
            custLocal.Name = "<>g__initLocal2";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 40.
            instruction = new CustomInstruction();
            instruction.Offset = 89;
            instruction.OpCode = OpCode.Ldloc_1;
            custLocal = new CustomLocal();
            custLocal.Name = "projectPath";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 41.
            instruction = new CustomInstruction();
            instruction.Offset = 90;
            instruction.OpCode = OpCode.Callvirt;
            meth = new CustomMethod();
            meth.IsReturnTypeVoid = true;
            meth.IsStatic = false;
            meth.NumberOfParameters = 1;
            meth.Signature = "{McKesson.TPP.Tools.DBBuild.Lib.Entities.Settings.set_DbBuildProjectDir(System.String)}";
            instruction.Value = meth;

            instructionList.Add(instruction);

            // CIL Instruction 42.
            instruction = new CustomInstruction();
            instruction.Offset = 95;
            instruction.OpCode = OpCode.Nop;
            instruction.Value = null;

            instructionList.Add(instruction);

            // CIL Instruction 43.
            instruction = new CustomInstruction();
            instruction.Offset = 96;
            instruction.OpCode = OpCode.Ldloc_S;
            custLocal = new CustomLocal();
            custLocal.Name = "<>g__initLocal2";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 44.
            instruction = new CustomInstruction();
            instruction.Offset = 98;
            instruction.OpCode = OpCode.Stloc_3;
            custLocal = new CustomLocal();
            custLocal.Name = "settings";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 45.
            instruction = new CustomInstruction();
            instruction.Offset = 99;
            instruction.OpCode = OpCode._Try;
            instruction.Value = null;

            instructionList.Add(instruction);

            // CIL Instruction 46.
            instruction = new CustomInstruction();
            instruction.Offset = 99;
            instruction.OpCode = OpCode.Nop;
            instruction.Value = null;

            instructionList.Add(instruction);

            // CIL Instruction 47.
            instruction = new CustomInstruction();
            instruction.Offset = 100;
            instruction.OpCode = OpCode.Ldloc_2;
            custLocal = new CustomLocal();
            custLocal.Name = "path";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 48.
            instruction = new CustomInstruction();
            instruction.Offset = 101;
            instruction.OpCode = OpCode.Call;
            meth = new CustomMethod();
            meth.IsReturnTypeVoid = false;
            meth.IsStatic = true;
            meth.NumberOfParameters = 1;
            meth.Signature = "{System.IO.Directory.Exists(System.String)}";
            instruction.Value = meth;

            instructionList.Add(instruction);

            // CIL Instruction 49.
            instruction = new CustomInstruction();
            instruction.Offset = 106;
            instruction.OpCode = OpCode.Stloc_S;
            custLocal = new CustomLocal();
            custLocal.Name = "CS$4$0001";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 50.
            instruction = new CustomInstruction();
            instruction.Offset = 108;
            instruction.OpCode = OpCode.Ldloc_S;
            custLocal = new CustomLocal();
            custLocal.Name = "CS$4$0001";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 51.
            instruction = new CustomInstruction();
            instruction.Offset = 110;
            instruction.OpCode = OpCode.Brtrue_S;
            instruction.Value = 123;

            instructionList.Add(instruction);

            // CIL Instruction 52.
            instruction = new CustomInstruction();
            instruction.Offset = 112;
            instruction.OpCode = OpCode.Nop;
            instruction.Value = null;

            instructionList.Add(instruction);

            // CIL Instruction 53.
            instruction = new CustomInstruction();
            instruction.Offset = 113;
            instruction.OpCode = OpCode.Ldloc_2;
            custLocal = new CustomLocal();
            custLocal.Name = "path";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 54.
            instruction = new CustomInstruction();
            instruction.Offset = 114;
            instruction.OpCode = OpCode.Call;
            meth = new CustomMethod();
            meth.IsReturnTypeVoid = false;
            meth.IsStatic = true;
            meth.NumberOfParameters = 1;
            meth.Signature = "{System.IO.Directory.CreateDirectory(System.String)}";
            instruction.Value = meth;

            instructionList.Add(instruction);

            // CIL Instruction 55.
            instruction = new CustomInstruction();
            instruction.Offset = 119;
            instruction.OpCode = OpCode.Pop;
            instruction.Value = null;

            instructionList.Add(instruction);

            // CIL Instruction 56.
            instruction = new CustomInstruction();
            instruction.Offset = 120;
            instruction.OpCode = OpCode.Ldc_I4_1;
            instruction.Value = 1;

            instructionList.Add(instruction);

            // CIL Instruction 57.
            instruction = new CustomInstruction();
            instruction.Offset = 121;
            instruction.OpCode = OpCode.Stloc_0;
            custLocal = new CustomLocal();
            custLocal.Name = "bDirectoryCreated";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 58.
            instruction = new CustomInstruction();
            instruction.Offset = 122;
            instruction.OpCode = OpCode.Nop;
            instruction.Value = null;

            instructionList.Add(instruction);

            // CIL Instruction 59.
            instruction = new CustomInstruction();
            instruction.Offset = 123;
            instruction.OpCode = OpCode.Newobj;
            instruction.Value = "{McKesson.TPP.Tools.DBBuild.Lib.OutputManager(Microsoft.FxCop.Sdk.ParameterCollection)}";

            instructionList.Add(instruction);

            // CIL Instruction 60.
            instruction = new CustomInstruction();
            instruction.Offset = 128;
            instruction.OpCode = OpCode.Stloc_S;
            custLocal = new CustomLocal();
            custLocal.Name = "outM";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 61.
            instruction = new CustomInstruction();
            instruction.Offset = 130;
            instruction.OpCode = OpCode.Ldc_I4_0;
            instruction.Value = 0;

            instructionList.Add(instruction);

            // CIL Instruction 62.
            instruction = new CustomInstruction();
            instruction.Offset = 131;
            instruction.OpCode = OpCode.Newarr;
            instruction.Value = "{Microsoft.FxCop.Sdk.ClassNode:System.Object}";

            instructionList.Add(instruction);

            // CIL Instruction 63.
            instruction = new CustomInstruction();
            instruction.Offset = 136;
            instruction.OpCode = OpCode.Call;
            meth = new CustomMethod();
            meth.IsReturnTypeVoid = false;
            meth.IsStatic = true;
            meth.NumberOfParameters = 1;
            meth.Signature = "{Rhino.Mocks.MockRepository.GenerateMock<McKesson.TPP.Tools.DBBuild.Lib.Interfaces.IDbOperations>(System.Object[])}";
            instruction.Value = meth;

            instructionList.Add(instruction);

            // CIL Instruction 64.
            instruction = new CustomInstruction();
            instruction.Offset = 141;
            instruction.OpCode = OpCode.Stloc_S;
            custLocal = new CustomLocal();
            custLocal.Name = "dbMock";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 65.
            instruction = new CustomInstruction();
            instruction.Offset = 143;
            instruction.OpCode = OpCode.Ldloc_S;
            custLocal = new CustomLocal();
            custLocal.Name = "dbMock";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 66.
            instruction = new CustomInstruction();
            instruction.Offset = 145;
            instruction.OpCode = OpCode.Ldloc_S;
            custLocal = new CustomLocal();
            custLocal.Name = "CS$<>9__CachedAnonymousMethodDelegate5";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 67.
            instruction = new CustomInstruction();
            instruction.Offset = 147;
            instruction.OpCode = OpCode.Brtrue_S;
            instruction.Value = 166;

            instructionList.Add(instruction);

            // CIL Instruction 68.
            instruction = new CustomInstruction();
            instruction.Offset = 149;
            instruction.OpCode = OpCode.Ldloc_S;
            custLocal = new CustomLocal();
            custLocal.Name = "CS$<>8__locals7";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 69.
            instruction = new CustomInstruction();
            instruction.Offset = 151;
            instruction.OpCode = OpCode.Ldftn;
            instruction.Value = "{McKesson.TPP.Tools.DBBuild.Test.Console.ArgumentsValidatorTest+<>c__DisplayClass6.<CheckCommandParameterTest>b__4}";

            instructionList.Add(instruction);

            // CIL Instruction 70.
            instruction = new CustomInstruction();
            instruction.Offset = 157;
            instruction.OpCode = OpCode.Newobj;
            instruction.Value = "{Rhino.Mocks.Function<McKesson.TPP.Tools.DBBuild.Lib.Interfaces.IDbOperations,McKesson.TPP.Tools.DBBuild.Lib.Entities.ReturnArgs>(Microsoft.FxCop.Sdk.ParameterCollection)}";

            instructionList.Add(instruction);

            // CIL Instruction 71.
            instruction = new CustomInstruction();
            instruction.Offset = 162;
            instruction.OpCode = OpCode.Stloc_S;
            custLocal = new CustomLocal();
            custLocal.Name = "CS$<>9__CachedAnonymousMethodDelegate5";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 72.
            instruction = new CustomInstruction();
            instruction.Offset = 164;
            instruction.OpCode = OpCode.Br_S;
            instruction.Value = 166;

            instructionList.Add(instruction);

            // CIL Instruction 73.
            instruction = new CustomInstruction();
            instruction.Offset = 166;
            instruction.OpCode = OpCode.Ldloc_S;
            custLocal = new CustomLocal();
            custLocal.Name = "CS$<>9__CachedAnonymousMethodDelegate5";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 74.
            instruction = new CustomInstruction();
            instruction.Offset = 168;
            instruction.OpCode = OpCode.Call;
            meth = new CustomMethod();
            meth.IsReturnTypeVoid = false;
            meth.IsStatic = true;
            meth.NumberOfParameters = 2;
            meth.Signature = "{Rhino.Mocks.RhinoMocksExtensions.Expect<McKesson.TPP.Tools.DBBuild.Lib.Interfaces.IDbOperations,McKesson.TPP.Tools.DBBuild.Lib.Entities.ReturnArgs>(McKesson.TPP.Tools.DBBuild.Lib.Interfaces.IDbOperations,Rhino.Mocks.Function`2<McKesson.TPP.Tools.DBBuild.Lib.Interfaces.IDbOperations,McKesson.TPP.Tools.DBBuild.Lib.Entities.ReturnArgs>)}";
            instruction.Value = meth;

            instructionList.Add(instruction);

            // CIL Instruction 75.
            instruction = new CustomInstruction();
            instruction.Offset = 173;
            instruction.OpCode = OpCode.Newobj;
            instruction.Value = "{McKesson.TPP.Tools.DBBuild.Lib.Entities.ReturnArgs(Microsoft.FxCop.Sdk.ParameterCollection)}";

            instructionList.Add(instruction);

            // CIL Instruction 76.
            instruction = new CustomInstruction();
            instruction.Offset = 178;
            instruction.OpCode = OpCode.Stloc_S;
            custLocal = new CustomLocal();
            custLocal.Name = "<>g__initLocal3";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 77.
            instruction = new CustomInstruction();
            instruction.Offset = 180;
            instruction.OpCode = OpCode.Ldloc_S;
            custLocal = new CustomLocal();
            custLocal.Name = "<>g__initLocal3";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 78.
            instruction = new CustomInstruction();
            instruction.Offset = 182;
            instruction.OpCode = OpCode.Ldc_I4_1;
            instruction.Value = 1;

            instructionList.Add(instruction);

            // CIL Instruction 79.
            instruction = new CustomInstruction();
            instruction.Offset = 183;
            instruction.OpCode = OpCode.Callvirt;
            meth = new CustomMethod();
            meth.IsReturnTypeVoid = true;
            meth.IsStatic = false;
            meth.NumberOfParameters = 1;
            meth.Signature = "{McKesson.TPP.Tools.DBBuild.Lib.Entities.ReturnArgs.set_Success(System.Boolean)}";
            instruction.Value = meth;

            instructionList.Add(instruction);

            // CIL Instruction 80.
            instruction = new CustomInstruction();
            instruction.Offset = 188;
            instruction.OpCode = OpCode.Nop;
            instruction.Value = null;

            instructionList.Add(instruction);

            // CIL Instruction 81.
            instruction = new CustomInstruction();
            instruction.Offset = 189;
            instruction.OpCode = OpCode.Ldloc_S;
            custLocal = new CustomLocal();
            custLocal.Name = "<>g__initLocal3";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 82.
            instruction = new CustomInstruction();
            instruction.Offset = 191;
            instruction.OpCode = OpCode.Callvirt;
            meth = new CustomMethod();
            meth.IsReturnTypeVoid = false;
            meth.IsStatic = false;
            meth.NumberOfParameters = 1;
            meth.Signature = "{Rhino.Mocks.Interfaces.IMethodOptions`1<McKesson.TPP.Tools.DBBuild.Lib.Entities.ReturnArgs>.Return(McKesson.TPP.Tools.DBBuild.Lib.Entities.ReturnArgs)}";
            instruction.Value = meth;

            instructionList.Add(instruction);

            // CIL Instruction 83.
            instruction = new CustomInstruction();
            instruction.Offset = 196;
            instruction.OpCode = OpCode.Pop;
            instruction.Value = null;

            instructionList.Add(instruction);

            // CIL Instruction 84.
            instruction = new CustomInstruction();
            instruction.Offset = 197;
            instruction.OpCode = OpCode.Ldloc_3;
            custLocal = new CustomLocal();
            custLocal.Name = "settings";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 85.
            instruction = new CustomInstruction();
            instruction.Offset = 198;
            instruction.OpCode = OpCode.Ldloc_S;
            custLocal = new CustomLocal();
            custLocal.Name = "CS$<>8__locals7";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 86.
            instruction = new CustomInstruction();
            instruction.Offset = 200;
            instruction.OpCode = OpCode.Ldfld;
            instruction.Value = "{McKesson.TPP.Tools.DBBuild.Test.Console.ArgumentsValidatorTest+<>c__DisplayClass6.args}";

            instructionList.Add(instruction);

            // CIL Instruction 87.
            instruction = new CustomInstruction();
            instruction.Offset = 205;
            instruction.OpCode = OpCode.Ldloc_S;
            custLocal = new CustomLocal();
            custLocal.Name = "outM";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 88.
            instruction = new CustomInstruction();
            instruction.Offset = 207;
            instruction.OpCode = OpCode.Ldloc_S;
            custLocal = new CustomLocal();
            custLocal.Name = "dbMock";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 89.
            instruction = new CustomInstruction();
            instruction.Offset = 209;
            instruction.OpCode = OpCode.Newobj;
            instruction.Value = "{McKesson.TPP.Tools.DbBuild.ArgumentsValidator(Microsoft.FxCop.Sdk.ParameterCollection)}";

            instructionList.Add(instruction);

            // CIL Instruction 90.
            instruction = new CustomInstruction();
            instruction.Offset = 214;
            instruction.OpCode = OpCode.Stloc_S;
            custLocal = new CustomLocal();
            custLocal.Name = "validator";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 91.
            instruction = new CustomInstruction();
            instruction.Offset = 216;
            instruction.OpCode = OpCode.Ldloc_S;
            custLocal = new CustomLocal();
            custLocal.Name = "validator";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 92.
            instruction = new CustomInstruction();
            instruction.Offset = 218;
            instruction.OpCode = OpCode.Callvirt;
            meth = new CustomMethod();
            meth.IsReturnTypeVoid = false;
            meth.IsStatic = false;
            meth.NumberOfParameters = 0;
            meth.Signature = "{McKesson.TPP.Tools.DbBuild.ArgumentsValidator.CheckParametersFromArgList}";
            instruction.Value = meth;

            instructionList.Add(instruction);

            // CIL Instruction 93.
            instruction = new CustomInstruction();
            instruction.Offset = 223;
            instruction.OpCode = OpCode.Stloc_S;
            custLocal = new CustomLocal();
            custLocal.Name = "ra";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 94.
            instruction = new CustomInstruction();
            instruction.Offset = 225;
            instruction.OpCode = OpCode.Ldloc_S;
            custLocal = new CustomLocal();
            custLocal.Name = "dbMock";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 95.
            instruction = new CustomInstruction();
            instruction.Offset = 227;
            instruction.OpCode = OpCode.Call;
            meth = new CustomMethod();
            meth.IsReturnTypeVoid = true;
            meth.IsStatic = true;
            meth.NumberOfParameters = 1;
            meth.Signature = "{Rhino.Mocks.RhinoMocksExtensions.VerifyAllExpectations(System.Object)}";
            instruction.Value = meth;

            instructionList.Add(instruction);

            // CIL Instruction 96.
            instruction = new CustomInstruction();
            instruction.Offset = 232;
            instruction.OpCode = OpCode.Nop;
            instruction.Value = null;

            instructionList.Add(instruction);

            // CIL Instruction 97.
            instruction = new CustomInstruction();
            instruction.Offset = 233;
            instruction.OpCode = OpCode.Ldloc_S;
            custLocal = new CustomLocal();
            custLocal.Name = "ra";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 98.
            instruction = new CustomInstruction();
            instruction.Offset = 235;
            instruction.OpCode = OpCode.Callvirt;
            meth = new CustomMethod();
            meth.IsReturnTypeVoid = false;
            meth.IsStatic = false;
            meth.NumberOfParameters = 0;
            meth.Signature = "{McKesson.TPP.Tools.DBBuild.Lib.Entities.ReturnArgs.get_Success}";
            instruction.Value = meth;

            instructionList.Add(instruction);

            // CIL Instruction 99.
            instruction = new CustomInstruction();
            instruction.Offset = 240;
            instruction.OpCode = OpCode.Box;
            instruction.Value = "{Microsoft.FxCop.Sdk.Struct:System.Boolean}";

            instructionList.Add(instruction);

            // CIL Instruction 100.
            instruction = new CustomInstruction();
            instruction.Offset = 245;
            instruction.OpCode = OpCode.Ldc_I4_0;
            instruction.Value = 0;

            instructionList.Add(instruction);

            // CIL Instruction 101.
            instruction = new CustomInstruction();
            instruction.Offset = 246;
            instruction.OpCode = OpCode.Box;
            instruction.Value = "{Microsoft.FxCop.Sdk.Struct:System.Boolean}";

            instructionList.Add(instruction);

            // CIL Instruction 102.
            instruction = new CustomInstruction();
            instruction.Offset = 251;
            instruction.OpCode = OpCode.Call;
            meth = new CustomMethod();
            meth.IsReturnTypeVoid = false;
            meth.IsStatic = true;
            meth.NumberOfParameters = 1;
            meth.Signature = "{NUnit.Framework.Is.EqualTo(System.Object)}";
            instruction.Value = meth;

            instructionList.Add(instruction);

            // CIL Instruction 103.
            instruction = new CustomInstruction();
            instruction.Offset = 256;
            instruction.OpCode = OpCode.Call;
            meth = new CustomMethod();
            meth.IsReturnTypeVoid = true;
            meth.IsStatic = true;
            meth.NumberOfParameters = 2;
            meth.Signature = "{NUnit.Framework.Assert.That(System.Object,NUnit.Framework.Constraints.IResolveConstraint)}";
            instruction.Value = meth;

            instructionList.Add(instruction);

            // CIL Instruction 104.
            instruction = new CustomInstruction();
            instruction.Offset = 261;
            instruction.OpCode = OpCode.Nop;
            instruction.Value = null;

            instructionList.Add(instruction);

            // CIL Instruction 105.
            instruction = new CustomInstruction();
            instruction.Offset = 262;
            instruction.OpCode = OpCode.Ldloc_S;
            custLocal = new CustomLocal();
            custLocal.Name = "ra";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 106.
            instruction = new CustomInstruction();
            instruction.Offset = 264;
            instruction.OpCode = OpCode.Callvirt;
            meth = new CustomMethod();
            meth.IsReturnTypeVoid = false;
            meth.IsStatic = false;
            meth.NumberOfParameters = 0;
            meth.Signature = "{McKesson.TPP.Tools.DBBuild.Lib.Entities.ReturnArgs.get_Message}";
            instruction.Value = meth;

            instructionList.Add(instruction);

            // CIL Instruction 107.
            instruction = new CustomInstruction();
            instruction.Offset = 269;
            instruction.OpCode = OpCode.Ldloc_S;
            custLocal = new CustomLocal();
            custLocal.Name = "outM";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 108.
            instruction = new CustomInstruction();
            instruction.Offset = 271;
            instruction.OpCode = OpCode.Ldstr;
            instruction.Value = "{ArgumentsError_Command}";

            instructionList.Add(instruction);

            // CIL Instruction 109.
            instruction = new CustomInstruction();
            instruction.Offset = 276;
            instruction.OpCode = OpCode.Callvirt;
            meth = new CustomMethod();
            meth.IsReturnTypeVoid = false;
            meth.IsStatic = false;
            meth.NumberOfParameters = 1;
            meth.Signature = "{McKesson.TPP.Tools.DBBuild.Lib.OutputManager.GetResourceString(System.String)}";
            instruction.Value = meth;

            instructionList.Add(instruction);

            // CIL Instruction 110.
            instruction = new CustomInstruction();
            instruction.Offset = 281;
            instruction.OpCode = OpCode.Ldloc_S;
            custLocal = new CustomLocal();
            custLocal.Name = "CS$<>8__locals7";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 111.
            instruction = new CustomInstruction();
            instruction.Offset = 283;
            instruction.OpCode = OpCode.Ldfld;
            instruction.Value = "{McKesson.TPP.Tools.DBBuild.Test.Console.ArgumentsValidatorTest+<>c__DisplayClass6.args}";

            instructionList.Add(instruction);

            // CIL Instruction 112.
            instruction = new CustomInstruction();
            instruction.Offset = 288;
            instruction.OpCode = OpCode.Ldc_I4_2;
            instruction.Value = 2;

            instructionList.Add(instruction);

            // CIL Instruction 113.
            instruction = new CustomInstruction();
            instruction.Offset = 289;
            instruction.OpCode = OpCode.Ldelem_Ref;
            instruction.Value = null;

            instructionList.Add(instruction);

            // CIL Instruction 114.
            instruction = new CustomInstruction();
            instruction.Offset = 290;
            instruction.OpCode = OpCode.Call;
            meth = new CustomMethod();
            meth.IsReturnTypeVoid = false;
            meth.IsStatic = true;
            meth.NumberOfParameters = 2;
            meth.Signature = "{System.String.Format(System.String,System.Object)}";
            instruction.Value = meth;

            instructionList.Add(instruction);

            // CIL Instruction 115.
            instruction = new CustomInstruction();
            instruction.Offset = 295;
            instruction.OpCode = OpCode.Call;
            meth = new CustomMethod();
            meth.IsReturnTypeVoid = false;
            meth.IsStatic = true;
            meth.NumberOfParameters = 1;
            meth.Signature = "{NUnit.Framework.Is.EqualTo(System.Object)}";
            instruction.Value = meth;

            instructionList.Add(instruction);

            // CIL Instruction 116.
            instruction = new CustomInstruction();
            instruction.Offset = 300;
            instruction.OpCode = OpCode.Call;
            meth = new CustomMethod();
            meth.IsReturnTypeVoid = true;
            meth.IsStatic = true;
            meth.NumberOfParameters = 2;
            meth.Signature = "{NUnit.Framework.Assert.That(System.Object,NUnit.Framework.Constraints.IResolveConstraint)}";
            instruction.Value = meth;

            instructionList.Add(instruction);

            // CIL Instruction 117.
            instruction = new CustomInstruction();
            instruction.Offset = 305;
            instruction.OpCode = OpCode.Nop;
            instruction.Value = null;

            instructionList.Add(instruction);

            // CIL Instruction 118.
            instruction = new CustomInstruction();
            instruction.Offset = 306;
            instruction.OpCode = OpCode.Nop;
            instruction.Value = null;

            instructionList.Add(instruction);

            // CIL Instruction 119.
            instruction = new CustomInstruction();
            instruction.Offset = 307;
            instruction.OpCode = OpCode.Leave_S;
            instruction.Value = 329;

            instructionList.Add(instruction);

            // CIL Instruction 120.
            instruction = new CustomInstruction();
            instruction.Offset = 309;
            instruction.OpCode = OpCode._EndTry;
            instruction.Value = "{Instruction OpCode=_Try}";

            instructionList.Add(instruction);

            // CIL Instruction 121.
            instruction = new CustomInstruction();
            instruction.Offset = 309;
            instruction.OpCode = OpCode._Finally;
            instruction.Value = null;

            instructionList.Add(instruction);

            // CIL Instruction 122.
            instruction = new CustomInstruction();
            instruction.Offset = 309;
            instruction.OpCode = OpCode.Nop;
            instruction.Value = null;

            instructionList.Add(instruction);

            // CIL Instruction 123.
            instruction = new CustomInstruction();
            instruction.Offset = 310;
            instruction.OpCode = OpCode.Ldloc_0;
            custLocal = new CustomLocal();
            custLocal.Name = "bDirectoryCreated";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 124.
            instruction = new CustomInstruction();
            instruction.Offset = 311;
            instruction.OpCode = OpCode.Ldc_I4_0;
            instruction.Value = 0;

            instructionList.Add(instruction);

            // CIL Instruction 125.
            instruction = new CustomInstruction();
            instruction.Offset = 312;
            instruction.OpCode = OpCode.Ceq;
            instruction.Value = null;

            instructionList.Add(instruction);

            // CIL Instruction 126.
            instruction = new CustomInstruction();
            instruction.Offset = 314;
            instruction.OpCode = OpCode.Stloc_S;
            custLocal = new CustomLocal();
            custLocal.Name = "CS$4$0001";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 127.
            instruction = new CustomInstruction();
            instruction.Offset = 316;
            instruction.OpCode = OpCode.Ldloc_S;
            custLocal = new CustomLocal();
            custLocal.Name = "CS$4$0001";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 128.
            instruction = new CustomInstruction();
            instruction.Offset = 318;
            instruction.OpCode = OpCode.Brtrue_S;
            instruction.Value = 327;

            instructionList.Add(instruction);

            // CIL Instruction 129.
            instruction = new CustomInstruction();
            instruction.Offset = 320;
            instruction.OpCode = OpCode.Ldloc_2;
            custLocal = new CustomLocal();
            custLocal.Name = "path";
            instruction.Value = custLocal;

            instructionList.Add(instruction);

            // CIL Instruction 130.
            instruction = new CustomInstruction();
            instruction.Offset = 321;
            instruction.OpCode = OpCode.Call;
            meth = new CustomMethod();
            meth.IsReturnTypeVoid = true;
            meth.IsStatic = true;
            meth.NumberOfParameters = 1;
            meth.Signature = "{System.IO.Directory.Delete(System.String)}";
            instruction.Value = meth;

            instructionList.Add(instruction);

            // CIL Instruction 131.
            instruction = new CustomInstruction();
            instruction.Offset = 326;
            instruction.OpCode = OpCode.Nop;
            instruction.Value = null;

            instructionList.Add(instruction);

            // CIL Instruction 132.
            instruction = new CustomInstruction();
            instruction.Offset = 327;
            instruction.OpCode = OpCode.Nop;
            instruction.Value = null;

            instructionList.Add(instruction);

            // CIL Instruction 133.
            instruction = new CustomInstruction();
            instruction.Offset = 328;
            instruction.OpCode = OpCode.Endfinally;
            instruction.Value = null;

            instructionList.Add(instruction);

            // CIL Instruction 134.
            instruction = new CustomInstruction();
            instruction.Offset = 329;
            instruction.OpCode = OpCode._EndHandler;
            instruction.Value = "{Instruction OpCode=_Finally}";

            instructionList.Add(instruction);

            // CIL Instruction 135.
            instruction = new CustomInstruction();
            instruction.Offset = 329;
            instruction.OpCode = OpCode.Nop;
            instruction.Value = null;

            instructionList.Add(instruction);

            // CIL Instruction 136.
            instruction = new CustomInstruction();
            instruction.Offset = 330;
            instruction.OpCode = OpCode.Nop;
            instruction.Value = null;

            instructionList.Add(instruction);

            // CIL Instruction 137.
            instruction = new CustomInstruction();
            instruction.Offset = 331;
            instruction.OpCode = OpCode.Ret;
            instruction.Value = null;

            instructionList.Add(instruction);

            return instructionList;
        }
    }
}
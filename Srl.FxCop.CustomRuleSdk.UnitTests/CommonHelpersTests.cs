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
                .GetInstructionThatLoadsTheTargetOfAnExtensionMethodWithLamda(
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
        public void CanThrowArgumentNullExceptionInGetVariableNameFromInstructionValueWhenInstructionValueIsNull()
        {
            // Arrange
            CustomInstruction instruction = new CustomInstruction();
            instruction.Value = null;

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => CommonHelpers.GetVariableNameFromInstructionValue(null));
        }


        [Test]
        public void CanReturnNullWhenInstructionForGetVariableNameFromInstructionValueWhenOpcodeValueIsNotAField()
        {
                
        }


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

        #endregion
    }
}
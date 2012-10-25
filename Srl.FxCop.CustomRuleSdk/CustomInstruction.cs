//
// CustomInstruction.cs
//
// Product:
//
// Component: Srl.FxCop.CustomRuleSdk
//
// Description: Represents a custom instruction SDK version of the FxCop SDK Instruction class.
//
// Author: Scott Lurowist
//




#region Using Directives

using System;
using Microsoft.FxCop.Sdk;

#endregion




namespace Srl.FxCop.CustomRuleSdk
{
    /// <summary>
    /// Represents a custom rule SDK version of the FxCop SDK Instruction class.
    /// </summary>
    public class CustomInstruction
    {
        /// <summary>
        /// An enumeration that represents the opcode of the instruction.
        /// </summary>
        public OpCode OpCode { get; set; }

        /// <summary>
        /// The difference in the number of bytes from the current location of an
        /// opcode to the beginning of the method.
        /// </summary>
        public int Offset { get; set; }

        /// <summary>
        /// The operand of the instruction.
        /// </summary>
        public object Value { get; set; }




        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString()
        {
            return string.Format("Opcode = {0, -10} Offset = {1, -5} Value = {2, -100}",
                OpCode, Convert.ToString(Offset), (Value == null) ? "null" : "{" + Value.ToString() + "}");
        }
    }  
}
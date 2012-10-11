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

using Microsoft.FxCop.Sdk;

#endregion




namespace Srl.FxCop.CustomRuleSdk
{
    /// <summary>
    /// Represents a custom rule SDK version of the FxCop SDK Instruction class.
    /// </summary>
    public class CustomInstruction
    {
        public OpCode OpCode { get; set; }
        public int Offset { get; set; }
        public object Value { get; set; }
    }  
}
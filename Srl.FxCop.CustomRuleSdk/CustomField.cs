//
// CustomField.cs
//
// Product:
//
// Component: Srl.FxCop.CustomRuleSdk
//
// Description: Represents a custom Field SDK version of the FxCop SDK Field class.
//
// Author: Scott Lurowist
//




#region Using Directives

using Microsoft.FxCop.Sdk;

#endregion




namespace Srl.FxCop.CustomRuleSdk
{
    /// <summary>
    /// Represents a custom Field SDK version of the FxCop SDK Field class.
    /// </summary>
    public class CustomField
    {
        public Literal DefaultValue { get; internal set; }
        public FieldFlags Flags { get; internal set; }
        public int Offset { get; internal set; }
        public bool IsVolatile { get; internal set; }
        public TypeNode Type { get; internal set; }
        public MarshallingInformation MarshallingInformation { get; internal set; }
        public byte[] InitialData { get; internal set; }
        public PESection Section { get; set; }
        public string FullName { get; set; }
        public virtual bool IsLiteral { get; set; }
        public bool IsAssembly { get; set; }
        public bool IsCompilerControlled { get; set; }
        public bool IsFamily { get; set; }
        public bool IsFamilyAndAssembly { get; set; }
        public bool IsFamilyOrAssembly { get; set; }
        public virtual bool IsInitOnly { get; set; }
        public bool IsPrivate { get; set; }
        public bool IsPublic { get; set; }
        public bool IsSpecialName { get; set; }
        public bool IsStatic { get; set; }
        public bool IsVisibleOutsideAssembly { get; set; }
        public string ToString()
        {
            return null;
        }
    }
}
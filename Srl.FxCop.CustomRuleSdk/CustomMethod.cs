//
// CustomMethod.cs
//
// Product:
//
// Component: Srl.FxCop.CustomRuleSdk
//
// Description: Represents a custom method SDK version of the FxCop SDK Method class.
//
// Author: Scott Lurowist
//




#region Using Directives

using Microsoft.FxCop.Sdk;

#endregion




namespace Srl.FxCop.CustomRuleSdk
{
    /// <summary>
    /// Represents a custom method SDK version of the FxCop SDK Method class.
    /// </summary>
    public class CustomMethod
    {
        /// <summary>
        /// Gets or sets a boolean value that is true is the return type is void.
        /// </summary>
        public bool IsReturnTypeVoid { get; set; }

        /// <summary>
        /// Gets or sets a boolean value that is true if the method is static.
        /// </summary>
        public bool IsStatic { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the number of arguments in the method signature.
        /// </summary>
        public int NumberOfParameters { get; set; }

        /// <summary>
        /// Gets or sets the method signature.
        /// </summary>
        public string Signature { get; set; }


        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString()
        {
            return string.Format("Signature = {0} IsReturnTypeVoid = {1} IsStatic = {2} NumberOfParameters = {3}",
                Signature, IsReturnTypeVoid, IsStatic, NumberOfParameters);
        }
    }
}
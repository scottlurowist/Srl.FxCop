//
// CustomParameterCollection.cs
//
// Product:
//
// Component: Srl.FxCop.CustomRuleSdk
//
// Description: Represents a custom parameter collection SDK version of the FxCop SDK CustomParameterCollection class.
//
// Author: Scott Lurowist
//




#region Using Directives

using Microsoft.FxCop.Sdk;

#endregion




namespace Srl.FxCop.CustomRuleSdk
{
    /// <summary>
    /// Represents a custom parameter collection SDK version of the FxCop SDK CustomParameterCollection class.
    /// </summary>
    public class CustomParameterCollection
    {
        /// <summary>
        /// Gets or sets a value indicating the number of arguments in the method signature.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString()
        {
            return string.Format("Count = {0}", Count);
        }
    }
}
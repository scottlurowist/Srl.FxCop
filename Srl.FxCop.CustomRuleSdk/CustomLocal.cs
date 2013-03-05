//
// CustomLocal.cs
//
// Product:
//
// Component: Srl.FxCop.CustomRuleSdk
//
// Description: Represents a custom Local SDK version of the FxCop SDK Local class.
//
// Author: Scott Lurowist
//




namespace Srl.FxCop.CustomRuleSdk
{
    /// <summary>
    /// Represents a custom Local SDK version of the FxCop SDK Local class.
    /// </summary>
    public class CustomLocal
    {
        /// <summary>
        /// The full name of the local variable.
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString()
        {
            return string.Format("Name = {0}", Name);
        }
    }  
}
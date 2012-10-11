//
// DeveloperTestConstants.cs
//
// Product:
//
// Component: Srl.FxCop.CustomDeveloperTestRules
//
// Description: Contains constants used in custom FX Cop rule logic.
//
// Author: Scott Lurowist
//




namespace Srl.FxCop.CustomDeveloperTestRules
{
    internal class DeveloperTestConstants
    {
        /// <summary>
        /// The name of the attribute that siginfies that the attributed method is a unit test method.
        /// </summary>
        internal const string TestAttributeName = "TestAttribute";

        /// <summary>
        /// The name of the attribute that signifies that the attributed method is a setup method for a unit test harness.
        /// </summary>
        internal const string SetupMethodAttributeName = "SetupAttribute";
    }
}
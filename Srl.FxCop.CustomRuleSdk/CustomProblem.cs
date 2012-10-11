//
// CustomProblem.cs
//
// Product:
//
// Component: Srl.FxCop.CustomRuleSdk
//
// Description: Represents a custom Problem SDK version of the FxCop SDK Problem class.
//
// Author: Scott Lurowist
//




namespace Srl.FxCop.CustomRuleSdk
{
    /// <summary>
    /// Represents a custom Problem SDK version of the FxCop SDK Problem class.
    /// </summary>
    public class CustomProblem
    {
        public string ResolutionName { get; set; }

        public string[] ResolutionArguments { get; set; }
    }  
}
//
// DoNotInvokeRhinoMocksVerifyAllExpectationWithoutSettingExpectations.cs.cs
//
// Product:
//
// Component: Srl.FxCop.CustomDeveloperTestRules
//
// Description: Represents an FxCop rule that checks whether RhinoMocks stubs or mocks
//              are invoked with VerifyAllExpectations when no expectations are set.
//
// Author: Scott Lurowist
//




#region Using Directives

using System.Collections.Generic;
using Microsoft.FxCop.Sdk;
using Srl.FxCop.CustomRuleSdk;

#endregion




namespace Srl.FxCop.CustomDeveloperTestRules
{
    /// <summary>
    /// Represents an FxCop rule that checks whether RhinoMocks stubs or mocks
    /// are invoked with VerifyAllExpectations when no expectations are set.
    /// </summary>
    internal sealed class DoNotInvokeRhinoMocksVerifyAllExpectationWithoutSettingExpectations : BaseDeveloperTestFxCopRule
    {
        /// <summary>
        /// Initializes a new instance of DoNotInvokeRhinoMocksVerifyAllExpectationWithoutSettingExpectations.
        /// </summary>
        public DoNotInvokeRhinoMocksVerifyAllExpectationWithoutSettingExpectations()
            : base("DoNotInvokeRhinoMocksVerifyAllExpectationWithoutSettingExpectations", 
                typeof(DoNotConfuseRhinoMocksStubsWithMocks).Assembly)
        {
        }


        /// <summary>
        /// Gets the visibility of targets for this rule.
        /// </summary>
        public override TargetVisibilities TargetVisibility
        {
            get { return TargetVisibilities.All; }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="member">
        /// 
        /// </param>
        /// <returns>
        /// 
        /// </returns>
        public override ProblemCollection Check(Member member)
        {
            var methodCandidate = member as Method;

            // Only check methods that have a test attribute.
            if ((methodCandidate != null) && 
                DoesMethodHaveAnAttribute(methodCandidate, DeveloperTestConstants.TestAttributeName))
            {
                var helper = new Helpers.DoNotInvokeRhinoMocksVerifyAllExpectationWithoutSettingExpectations();

                ProcessFoundProblems(helper.CheckIfRhinoMocksVerifyAllExpectationsIsInvokedAndNoExpecationsAreSet(
                        methodCandidate.Name.Name, 
                        GetCustomInstructionListFromInstructionCollection(methodCandidate.Instructions)));
            }

            return Problems;
        }
    }
}
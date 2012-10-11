//
// BaseDeveloperTestFxCopRule.cs
//
// Product:
//
// Component: Srl.FxCop.CustomDeveloperTestRules
//
// Description: Represents the base class for all custom developer test rules. It loads the
//              test metadata from RulesMetadata.xml and contains common functionality common
//              to testing.
//
// Author: Scott Lurowist
//




#region Using Directives

using System.Reflection;
using Srl.FxCop.CustomRuleSdk;

#endregion




namespace Srl.FxCop.CustomDeveloperTestRules
{
    /// <summary>
    /// Represents the base class for all custom developer test rules. It loads the
    /// test metadata from RulesMetadata.xml and contains common functionality common
    /// to testing.
    /// </summary>
    internal abstract class BaseDeveloperTestFxCopRule : BaseCustomFxCopRule
    {

        #region Protected Constructors

        /// <summary>
        /// Initializes a new instance of BaseDeveloperTestRule with the 
        /// rule metadata 
        /// </summary>
        /// <param name="ruleName">
        /// The name of the rule that a subclass implements.
        /// </param>
        /// <param name="assembly">
        /// The assembly type that implements the current rule.
        /// </param>
        protected BaseDeveloperTestFxCopRule(string ruleName, Assembly assembly)
            : base(ruleName, "Srl.FxCop.CustomDeveloperTestRules.RulesMetadata", assembly)
        {
        }

        #endregion




        //#region Internal Properties

        ///// <summary>
        ///// The identity name of a NodeType that represents a return value of void.
        ///// </summary>
        //internal string VoidReturnTypeName = "Void";

        ///// <summary>
        ///// The name of the signature for Rhino Mock's GenerateMock method.
        ///// </summary>
        //internal string RhinoMocksGenerateMock
        //{
        //    get { return "Rhino.Mocks.MockRepository.GenerateMock"; }
        //}

        ///// <summary>
        ///// The name of the signature for Rhino Mock's GenerateStub method.
        ///// </summary>
        //internal string RhinoMocksGenerateStub
        //{
        //    get { return "Rhino.Mocks.MockRepository.GenerateStub"; }
        //}

        //internal string RhinoMocksStub
        //{
        //    get { return "Rhino.Mocks.MockRepository.Stub"; }
        //}

        ///// <summary>
        ///// The name of the signature for Rhino Mock's VerifyAllExpectations method.
        ///// </summary>
        //internal string RhinoMocksVerifyAllExpectations
        //{
        //    get { return "Rhino.Mocks.RhinoMocksExtensions.VerifyAllExpectations"; }
        //}


        ///// <summary>
        ///// The name of NUnit's TearDown attribute.
        ///// </summary>
        //internal string TearDownAttributeName { get { return "TearDownAttribute"; } }

        //#endregion
    }
}
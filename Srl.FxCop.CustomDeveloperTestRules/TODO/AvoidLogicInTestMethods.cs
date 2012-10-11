////
//// AvoidLogicInTestMethods.cs
////
//// Product: Total Payment Platform
////
//// Component: Srl.DeveloperTestRules
////
//// Description: Represents an FxCop rule that checks for the presence of the
////              logic in test methods.
////
//// Author: Scott Lurowist
////
//// Copyright © 2012 Srl Corporation and/or one of its subsidiaries.  
//// All rights reserved. Use of this software is governed by a license agreement. This 
//// software contains confidential, proprietary and trade secret information of Srl 
//// Corporation and/or one of its subsidiaries and is protected under United States and 
//// international copyright and other intellectual property laws.
////




//#region Using Directives

//using System;
//using Microsoft.FxCop.Sdk;

//#endregion




//namespace DeveloperTestRules
//{
//    /// <summary>
//    /// Represents an FxCop rule that checks for the presence of the
//    /// logic in test methods.
//    /// </summary>
//    internal sealed class AvoidLogicInTestMethods : BaseDeveloperTestRule
//    {
//        #region Private Const Values

//        private const string TestAttributeName = "TestAttribute";

//        #endregion




//        /// <summary>
//        /// Initializes a new instance of AvoidLogicInTestMethods.
//        /// </summary>
//        public AvoidLogicInTestMethods() : base("AvoidLogicInTestMethods") {}


//        /// <summary>
//        /// Gets the visibility of targets for this rule.
//        /// </summary>
//        public override TargetVisibilities TargetVisibility
//        {
//            get { return TargetVisibilities.All; }
//        }


//        /// <summary>
//        /// Checks for methods that have the test attribute.
//        /// </summary>
//        /// <param name="member">
//        /// A possible instance of a member type node.
//        /// </param>
//        /// <returns>
//        /// A collection of introspection rule problems that contain instances
//        /// of test attributes on methods that use the var keyword.
//        /// </returns>
//        public override ProblemCollection Check(Member member)
//        {
//            // We are only checking methods.
//            if (!(member is Method))
//                return Problems;

//            AttributeNodeCollection attributes = member.Attributes;

//            if (attributes.Count > 0)
//                InspectAttributesForTestAttribute(attributes, member as Method);

//            return Problems;
//        }


//        /// <summary>
//        /// Inspects a collection of attributes for the Test attribute and 
//        /// if found it initiates a search for body statements of the test
//        /// method.
//        /// </summary>
//        /// <param name="attributes">
//        /// The collection of attributes to be inspected.
//        /// </param>
//        /// <param name="methodToInspect">
//        /// The test method to inspect for the use of var.
//        /// </param>
//        private void InspectAttributesForTestAttribute(AttributeNodeCollection attributes,
//            Method methodToInspect)
//        {
//            foreach (AttributeNode attributeNode in attributes)
//            {
//                if (attributeNode.Type.ConstructorName.Name == TestAttributeName)
//                {
//                    VisitStatements(methodToInspect.Body.Statements);
//                }
//            }
//        }


//        /// <summary>
//        /// Finds branch statements that are contained within test methods and
//        /// adds them to the problems collection.
//        /// </summary>
//        /// <param name="branch">
//        /// A branch instruction found by FxCop.
//        /// </param>
//        public override void VisitBranch(Branch branch)
//        {
//            AddProblem();
//        }
//    }
//}
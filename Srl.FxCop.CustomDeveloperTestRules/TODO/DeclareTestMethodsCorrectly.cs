////
//// DeclareTestMethodsCorrectly.cs
////
//// Product: Total Payment Platform
////
//// Component: Srl.DeveloperTestRules
////
//// Description: Represents an FxCop rule that checks that test methods
////              have the proper signature.
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




//namespace Srl.DeveloperTestRules
//{
//    /// <summary>
//    /// Represents an FxCop rule that checks that test methods
//    /// have the proper signature.
//    /// </summary>
//    internal sealed class DeclareTestMethodsCorrectly : BaseDeveloperTestRule
//    {
//        #region Private Const Values

//        private const string TestAttributeName = "TestAttribute";

//        #endregion




//        /// <summary>
//        /// Initializes a new instance of DeclareTestMethodsCorrectly.
//        /// </summary>
//        public DeclareTestMethodsCorrectly() 
//            : base("DeclareTestMethodsCorrectly") {}


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
//        /// Inspects a collection of attributes for the Test attribute and if 
//        /// found it checks that the return type of the test method is void.
//        /// If it is not void then a problem is created.s
//        /// </summary>
//        /// <param name="attributes">
//        /// The collection of attributes to be inspected.
//        /// </param>
//        /// <param name="methodToInspect">
//        /// The test method to inspect for the use of var.
//        /// </param>
//        private void InspectAttributesForTestAttribute(AttributeNodeCollection attributes,
//                                                       Method methodToInspect)
//        {
//            foreach (AttributeNode attributeNode in attributes)
//            {
//                if (attributeNode.Type.ConstructorName.Name == TestAttributeName)
//                {
//                    if (methodToInspect.ReturnType.Name.Name != VoidReturnTypeName)
//                    {
//                        AddProblem("void");
//                    }

//                    int testCaseAttributeCount = 0;

//                    foreach (AttributeNode attNode in attributes)
//                    {
//                        if (attNode.Type.ConstructorName.Name == "TestCaseAttribute")
//                        {
//                            testCaseAttributeCount++;
//                        }
//                    }

//                    // Test methods can only have parameters when there are testcases.
//                    if (testCaseAttributeCount == 0 && 
//                        methodToInspect.Parameters.Count > 0)
//                    {
//                        AddProblem("params");
//                    }
//                }
//            }
//        }
//    }
//}
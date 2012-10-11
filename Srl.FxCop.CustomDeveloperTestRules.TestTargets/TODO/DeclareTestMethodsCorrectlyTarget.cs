//
// DeclareTestMethodsCorrectlyTarget.cs
//
// Product: Total Payment Platform
//
// Component: Srl.DeveloperTestRules
//
// Description: Represents a class that has a test method that does not 
//              contain the proper signature for a test method.
//
// Author: Scott Lurowist
//
// Copyright © 2012 Srl Corporation and/or one of its subsidiaries.  
// All rights reserved. Use of this software is governed by a license agreement. This 
// software contains confidential, proprietary and trade secret information of Srl 
// Corporation and/or one of its subsidiaries and is protected under United States and 
// international copyright and other intellectual property laws.
//




#region Using Directives

using System;
using NUnit.Framework;
using Rhino.Mocks;

#endregion






//namespace Srl.DeveloperTestRules.TestTarget
//{
//    /// <summary>
//    /// Represents a class that has a test method that does not 
//    /// contain the proper signature for a test method.
//    /// </summary>
//    [TestFixture]
//    public class DeclareTestMethodsCorrectlyTarget
//    {
//        /// <summary>
//        /// This method should not be flagged by the rule.
//        /// </summary>
//        [Test]
//        public void TestMethodWithProperSignature()
//        {
            
//        }


//        /// <summary>
//        /// This method returns bool and it should be flagged by the rule.
//        /// </summary>
//        [Test]
//        public bool TestMethodThatReturnsABoolean()
//        {
//            return true;
//        }


//        /// <summary>
//        /// This method does not have test cases but has a parameter and so it
//        /// should be flagged by the rule.
//        /// </summary>
//        [Test]
//        public void TestMethodThatWithoutTestCasesThatHaveParameters(int x)
//        {
//        }


//        //[TestCase("Foo", 1)]
//    }
//}
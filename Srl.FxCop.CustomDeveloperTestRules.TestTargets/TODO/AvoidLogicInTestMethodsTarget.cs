//
// AvoidLogicInTestMethodsTarget.cs
//
// Product: Total Payment Platform
//
// Component: Srl.DeveloperTestRules
//
// Description: Represents a class that has test methods that have
//              logic in them to test the AvoidLogicInTestMethods rule.
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

#endregion






//namespace Srl.DeveloperTestRules.TestTarget
//{
//    /// <summary>
//    /// Represents a class that has test methods that have
//    /// logic in them to test the AvoidLogicInTestMethods rule.
//    /// </summary>
//    [TestFixture]
//    public class AvoidLogicInTestMethodsTarget
//    {
//        /// <summary>
//        /// This method should not be flagged by the rule.
//        /// </summary>
//        [Test]
//        public void TestMethodWithNoLogic()
//        {
            
//        }


//        /// <summary>
//        /// This method should not be flagged by the rule.
//        /// </summary>
//        [Test]
//        public void TestMethodWithNoLogicThatCallsAHelperMethod()
//        {
//            PrivateHelperMethod();
//        }


//        /// <summary>
//        /// This method has logic and should be flagged by the rule.
//        /// </summary>
//        [Test]
//        public void TestMethodThatHasAForLoop()
//        {
//            for (int i = 0; i < 10; i++)
//            {
//                int x = 4;
//            }
//        }

        
//        /// <summary>
//        /// This method should not get flagged by the rule.
//        /// </summary>
//        public void NonTestMethodThatHasAForLoop()
//        {
//            for (int i = 0; i < 10; i++)
//            {
//                int x = 4;
//            }         
//        }


//        /// <summary>
//        /// This method has logic and should be flagged by the rule.
//        /// </summary>
//        [Test]
//        public void TestMethodThatHasASwitchStatement()
//        {
//            int switchValue = 1;
//            int result = 0;


//            switch (switchValue)
//            {
//                case 0:
//                case 1:
//                    result = 100;
//                    break;
//                default:
//                    result = 1000;
//                    break;
//            }
//        }


//        /// <summary>
//        /// This method has logic and should be flagged by the rule.
//        /// </summary>
//        [Test]
//        public void TestMethodThatHasATryCatchStatement()
//        {
//            try
//            {
//                throw new Exception();    
//            }
//            catch (Exception excp )
//            {
//                int x = 4;
//            }
//        }


//        /// <summary>
//        /// This method has logic and should be flagged by the rule.
//        /// </summary>
//        [Test]
//        public void TestMethodThatHasADoWhileLoop()
//        {
//            int x = 0;

//            do
//            {
//                x++;
//            } while (x < 10);
//        }



//        /// <summary>
//        /// This is an empty helper method to make sure that FxCop does not
//        /// detect a method call as logic.
//        /// </summary>
//        private void PrivateHelperMethod()
//        {
//        }
//    }
//}

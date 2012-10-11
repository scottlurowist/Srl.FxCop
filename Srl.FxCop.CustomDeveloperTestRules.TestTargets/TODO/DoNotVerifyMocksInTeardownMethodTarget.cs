//
// DoNotVerifyMocksInTeardownMethodTarget.cs
//
// Product: Total Payment Platform
//
// Component: Srl.DeveloperTestRules
//
// Description: Represents a class that has mocks verifying expectations to
//              test the DoNotVerifyMocksInTeardownMethod rule.
//
// Author: Scott Lurowist
//
// Copyright © 2012 Srl Corporation and/or one of its subsidiaries.  
// All rights reserved. Use of this software is governed by a license agreement. This 
// software contains confidential, proprietary and trade secret information of Srl 
// Corporation and/or one of its subsidiaries and is protected under United States and 
// international copyright and other intellectual property laws.
//




//#region Using Directives

//using Srl.FxCop.CustomDeveloperTestRules.TestTargets;
//using NUnit.Framework;
//using Rhino.Mocks;

//#endregion




//namespace Srl.DeveloperTestRules.TestTarget
//{
//    /// <summary>
//    /// Represents a class that has mocks verifying expectations to
//    /// test the DoNotVerifyMocksInTeardownMethod rule.
//    /// </summary>
//    [TestFixture]
//    public class TestFixtureThatVerifiesMockInTeardown
//    {
//        private IBar _firstBarMock;
//        private IBar _secondBarMock;


//        [SetUp]
//        public void Setup()
//        {
//            _firstBarMock = MockRepository.GenerateMock<IBar>();
//            _secondBarMock = MockRepository.GenerateMock<IBar>();
//        }


//        [TearDown]
//        public void TearDown()
//        {
//            _firstBarMock.VerifyAllExpectations();  
//            _secondBarMock.VerifyAllExpectations();
//        }
//    }


//    [TestFixture]
//    public class TestFixtureThatDoesNotVerifyMockInTeardown
//    {
//        [SetUp]
//        public void Setup()
//        {
//        }


//        [TearDown]
//        public void TearDown()
//        {
//        }
//    }
//}
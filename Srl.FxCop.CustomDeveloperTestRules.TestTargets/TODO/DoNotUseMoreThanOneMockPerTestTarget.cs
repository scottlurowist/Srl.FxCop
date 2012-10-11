//
// DoNotUseMoreThanOneMockPerTestTarget.cs
//
// Product: Total Payment Platform
//
// Component: Srl.FxCop.CustomDeveloperTestRules.TestTargets
//
// Description: Represents a class that has multiple mocks per test.
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

using NUnit.Framework;
using Rhino.Mocks;

#endregion




//namespace Srl.FxCop.CustomDeveloperTestRules.TestTargets
//{
//    /// <summary>
//    /// Represents a class that has mocks verifying expectations to
//    /// test the DoNotVerifyMocksInTeardownMethod rule.
//    /// </summary>
//    [TestFixture]
//    public class DoNotUseMoreThanOneMockPerTestTarget
//    {
//        private IFoo _fooMock;
//        private IBar _barMock;


//        [SetUp]
//        public void Setup()
//        {
//            _fooMock = MockRepository.GenerateMock<IFoo>();
//            _barMock = MockRepository.GenerateMock<IBar>();
//        }


//        [Test]
//        public void TestThatHasALocalMockAndAMockFromSetup()
//        {
//            // This test will be flagged because it uses more than one mock.
//            // One mock is created in setup.
//            IBar bar = MockRepository.GenerateMock<IBar>();

//            _barMock.VerifyAllExpectations();
//        }


//        [Test]
//        public void TestThatHasOnlyOneLocalMock()
//        {
//            // This test will be flagged because it uses more than one mock.
//            // One mock is created in setup.
//            IBar bar = MockRepository.GenerateMock<IBar>();

//            bar.VerifyAllExpectations();
//        }


//        [Test]
//        public void TestThatHasTwoMocksFromSetup()
//        {
//            // This test will be flagged because it uses more than one mock
//            // and they are created in setup.
//            _fooMock.AssertWasCalled(x => x.DoSomethingFooRelated());
//            _barMock.VerifyAllExpectations();
//        }


//        [Test]
//        public void TestThatHasTwoLocalMocks()
//        {
//            // This test will be flagged because it uses more than one mock.
//            // Both are local.
//            IFoo foo = MockRepository.GenerateMock<IFoo>();

//            IBar bar = MockRepository.GenerateMock<IBar>();
//        }
//    }
//}
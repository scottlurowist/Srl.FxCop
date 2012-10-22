//
// DoNotConfuseRhinoMocksStubsWithMocksTarget.cs
//
// Product:
//
// Component: Srl.FxCop.CustomDeveloperTestRules.TestTargets
//
// Description: Represents a class that has is used to test when RhinoMocks stubs
//              are confused with mocks.
//
// Author: Scott Lurowist
//




#region Using Directives

using NUnit.Framework;
using Rhino.Mocks;

#endregion




namespace Srl.FxCop.CustomDeveloperTestRules.TestTargets
{
    /// <summary>
    /// Represents a class that has mocks being confused with stubs.
    /// </summary>
    [TestFixture]
    public class DoNotConfuseRhinoMocksStubsWithMocksTarget
    {
        private IBar _barStub;
        private IBar _barMock;
        private IBar _barStubTwo;
        private IBar _barMockTwo;


        [SetUp]
        public void Setup()
        {
            _barStub = MockRepository.GenerateStub<IBar>();
            _barMock = MockRepository.GenerateMock<IBar>();

            _barStubTwo = MockRepository.GenerateStub<IBar>();
            _barMockTwo = MockRepository.GenerateMock<IBar>();
        }


        //[Test]
        public void TestMethodWhereAFieldStubIsInvokedWithVerifyAllExpectations()
        {
            _barStub.VerifyAllExpectations();
        }


        //[Test]
        public void TestMethodWhereTwoFieldStubsAreInvokedWithVerifyAllExpectations()
        {
            _barStub.VerifyAllExpectations();
            _barStubTwo.VerifyAllExpectations();
        }


        //[Test]
        public void TestMethodWhereALocalStubIsInvokedWithVerifyAllExpectations()
        {
            IBar localStub = MockRepository.GenerateStub<IBar>();
            localStub.VerifyAllExpectations();
        }


        [Test]
        public void TestMethodWhereAFieldStubIsInvokedWithExpect()
        {
            _barStub.Expect(x => x.DoSomethingBarRelated());
        }


        //[Test]
        public void TestMethodWhereAMockIsInvokedWithStub()
        {
            _barMock.Stub(x => x.DoSomethingBarRelated()).Return(1);

            // We want to see how the CIL is generated when there are two stubs.
            _barStub.Stub(x => x.DoSomethingBarRelated()).Return(2);
        }


        //[Test]
        public void TestMethodWithALocalStubUsedAsAStub()
        {
            // We need the locals to generate the various stfld instructions.
            int x = 4;
            int y = 5;
            int z = 6;
            string someString = "foo";

            IFoo fooStub = MockRepository.GenerateStub<IFoo>();

            fooStub.Stub(s => s.DoSomethingFooRelated()).Return(1);
        }


        //[Test]
        public void TestMethodWithALocalStubUsedAsAMock()
        {
            // We need the locals to generate the various stfld instructions.
            int x = 4;
            int y = 5;
            int z = 6;
            string someString = "foo";

            IFoo fooStub = MockRepository.GenerateStub<IFoo>();

            fooStub.Expect(s => s.DoSomethingFooRelated());
        }
    }
}
﻿//
// DoNotInvokeRhinoMocksVerifyAllExpectationWithoutSettingExpectations.cs
//
// Product:
//
// Component: Srl.FxCop.CustomDeveloperTestRules.TestTargets
//
// Description: Represents a class that has is used to test when RhinoMocks VerifyAllExpectations are
//              invoked on a stub or mock and no expectations have been set.
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
    /// Represents a class that has is used to test when RhinoMocks VerifyAllExpectations are
    /// invoked on a stub or mock and no expectations have been set.
    /// </summary>
    [TestFixture]
    public class DoNotInvokeRhinoMocksVerifyAllExpectationWithoutSettingExpectations
    {
        private IBar _barMock = MockRepository.GenerateMock<IBar>();
        [Test]
        public void TestMethodWhereVerifyAllExpectationsOnAMockAndNoExectationsAreSet()
        {
            _barMock.Expect(x => x.DoSomethingBarRelated());

            _barMock.VerifyAllExpectations();
        }
    }
}
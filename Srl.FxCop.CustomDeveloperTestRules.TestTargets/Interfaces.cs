//
// Interfaces.cs
//
// Product:
//
// Component: Srl.FxCop.CustomDeveloperTestRules.TestTargets
//
// Description: Represents interfaces that can be mocked and stubbed.
//
// Author: Scott Lurowist
//




namespace Srl.FxCop.CustomDeveloperTestRules.TestTargets
{
    /// <summary>
    /// A simple interface for the purpose of creating mocks.
    /// </summary>
    public interface IFoo
    {
        void DoSomethingFooRelated();
    }


    /// <summary>
    /// A simple interface for the purpose of creating mocks.
    /// </summary>
    public interface IBar
    {
        void DoSomethingBarRelated();
    }
}
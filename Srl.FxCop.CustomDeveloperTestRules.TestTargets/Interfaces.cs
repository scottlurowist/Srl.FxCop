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
    /// A simple interface for the purpose of creating stubs and mocks.
    /// </summary>
    public interface IFoo
    {
        void DoSomethingFooRelated();
    }


    /// <summary>
    /// A simple interface for the purpose of creating stubs mocks.
    /// </summary>
    public interface IBar
    {
        void DoSomethingBarRelated();
    }


    /// <summary>
    /// A simple interface for the purpose of creating stubs mocks.
    /// </summary>
    public interface ISomethingWithAProperty
    {
        System.Object SomeProperty { get; set; }
    }
}
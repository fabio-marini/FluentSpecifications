namespace FluentSpecifications
{
    using System;

    public interface IGivenClause
    {
        IGivenClause And(string label, Action<IServiceProvider> givenAction);
        IWhenClause When(string label, Action<IServiceProvider> whenAction);
        IThenClause Then(string label, Action<IServiceProvider> thenAction);
    }
}

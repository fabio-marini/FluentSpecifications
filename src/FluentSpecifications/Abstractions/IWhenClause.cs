namespace FluentSpecifications
{
    using System;

    public interface IWhenClause
    {
        IWhenClause And(string label, Action<IServiceProvider> whenAction);
        IThenClause Then(string label, Action<IServiceProvider> thenAction);
    }
}

namespace FluentSpecifications
{
    using Microsoft.Extensions.DependencyInjection;
    using System;

    public interface IGivenClause
    {
        IGivenClause And(string label, Action<IServiceCollection> givenAction);
        IWhenClause When(string label, Action<IServiceProvider> whenAction);
        IThenClause Then(string label, Action<IServiceProvider> thenAction);
    }
}

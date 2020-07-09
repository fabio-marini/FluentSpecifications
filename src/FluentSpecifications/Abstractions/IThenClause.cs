namespace FluentSpecifications
{
    using System;

    public interface IThenClause
    {
        IThenClause And(string label, Action<IServiceProvider> thenAction);
    }
}

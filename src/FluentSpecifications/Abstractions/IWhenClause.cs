namespace FluentSpecifications
{
    using System;

    public interface IWhenClause
    {
        IWhenClause And(string label, Action whenAction);
        IThenClause Then(string label, Action thenAction);
    }
}

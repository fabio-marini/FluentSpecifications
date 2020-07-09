namespace FluentSpecifications
{
    using System;

    public interface IGivenClause
    {
        //IGivenClause And(string label, Action givenAction);
        IGivenClause And(string label, Action<IServiceProvider> givenAction);
        IWhenClause When(string label, Action whenAction);
        IThenClause Then(string label, Action thenAction);
    }
}

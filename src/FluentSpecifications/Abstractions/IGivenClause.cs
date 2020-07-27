namespace FluentSpecifications
{
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents the 'GIVEN' clause of a fluent specification
    /// </summary>
    public interface IGivenClause
    {
        /// <summary>
        /// Represents the 'AND (GIVEN)' clause of a fluent specification
        /// </summary>
        /// <param name="label">The free-text label to describe this clause</param>
        /// <param name="givenAction">The action to execute for this clause</param>
        /// <returns>The 'AND (GIVEN(' clause of a fluent specification</returns>
        IGivenClause And(string label, Action givenAction);
        IGivenClause And(string label, Func<Task> givenFunc);

        /// <summary>
        /// Represents the 'WHEN' clause of a fluent specification
        /// </summary>
        /// <param name="label">The free-text label to describe this clause</param>
        /// <param name="whenAction">The action to execute for this clause</param>
        /// <returns>The 'WHEN' clause of a fluent specification</returns>
        IWhenClause When(string label, Action whenAction);
        IWhenClause When(string label, Func<Task> whenFunc);

        /// <summary>
        /// Represents the 'THEN' clause of a fluent specification
        /// </summary>
        /// <param name="label">The free-text label to describe this clause</param>
        /// <param name="thenAction">The action to execute for this clause</param>
        /// <returns>The 'THEN' clause of a fluent specification</returns>
        IThenClause Then(string label, Action thenAction);
        IThenClause Then(string label, Func<Task> thenFunc);
    }
}

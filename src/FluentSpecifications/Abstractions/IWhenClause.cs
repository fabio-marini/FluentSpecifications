namespace FluentSpecifications
{
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents the 'WHEN' clause of a fluent specification
    /// </summary>
    public interface IWhenClause
    {
        /// <summary>
        /// Represents the 'AND (WHEN)' clause of a fluent specification
        /// </summary>
        /// <param name="label">The free-text label to describe this clause</param>
        /// <param name="whenAction">The action to execute for this clause</param>
        /// <returns>The 'AND (WHEN)' clause of a fluent specification</returns>
        IWhenClause And(string label, Action whenAction);
        IWhenClause And(string label, Func<Task> whenFunc);

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

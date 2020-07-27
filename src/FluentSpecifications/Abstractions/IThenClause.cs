namespace FluentSpecifications
{
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents the 'THEN' clause of a fluent specification
    /// </summary>
    public interface IThenClause
    {
        /// <summary>
        /// Represents the 'AND (THEN)' clause of a fluent specification
        /// </summary>
        /// <param name="label">The free-text label to describe this clause</param>
        /// <param name="thenAction">The action to execute for this clause</param>
        /// <returns>The 'AND (THEN)' clause of a fluent specification</returns>
        IThenClause And(string label, Action thenAction);
        IThenClause And(string label, Func<Task> thenFunc);
    }
}

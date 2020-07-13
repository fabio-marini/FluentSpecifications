namespace FluentSpecifications
{
    using System;

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

        /// <summary>
        /// Represents the 'THEN' clause of a fluent specification
        /// </summary>
        /// <param name="label">The free-text label to describe this clause</param>
        /// <param name="thenAction">The action to execute for this clause</param>
        /// <returns>The 'THEN' clause of a fluent specification</returns>
        IThenClause Then(string label, Action thenAction);
    }
}

namespace FluentSpecifications
{
    using System;

    /// <summary>
    /// Represents the 'THEN' clause of a fluent specification
    /// </summary>
    public class ThenClause : IThenClause
    {
        /// <summary>
        /// Represents the 'AND (THEN)' clause of a fluent specification
        /// </summary>
        /// <param name="label">The free-text label to describe this clause</param>
        /// <param name="thenAction">The action to execute for this clause</param>
        /// <returns>The 'AND (THEN)' clause of a fluent specification</returns>
        public IThenClause And(string label, Action thenAction)
        {
            Console.WriteLine($"  AND {label}");

            if (thenAction == null)
            {
                throw new ArgumentNullException(nameof(thenAction), "Cannot invoke a null action");
            }

            thenAction();

            return new ThenClause();
        }
    }
}

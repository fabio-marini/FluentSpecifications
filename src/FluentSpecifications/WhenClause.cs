namespace FluentSpecifications
{
    using System;

    /// <summary>
    /// Represents the 'WHEN' clause of a fluent specification
    /// </summary>
    public class WhenClause : IWhenClause
    {
        /// <summary>
        /// Represents the 'AND (WHEN)' clause of a fluent specification
        /// </summary>
        /// <param name="label">The free-text label to describe this clause</param>
        /// <param name="whenAction">The action to execute for this clause</param>
        /// <returns>The 'AND (WHEN)' clause of a fluent specification</returns>
        public IWhenClause And(string label, Action whenAction)
        {
            Console.WriteLine($"  AND {label}");

            if (whenAction == null)
            {
                throw new ArgumentNullException(nameof(whenAction), "Cannot invoke a null action");
            }

            whenAction();

            return new WhenClause();
        }

        /// <summary>
        /// Represents the 'THEN' clause of a fluent specification
        /// </summary>
        /// <param name="label">The free-text label to describe this clause</param>
        /// <param name="thenAction">The action to execute for this clause</param>
        /// <returns>The 'THEN' clause of a fluent specification</returns>
        public IThenClause Then(string label, Action thenAction)
        {
            Console.WriteLine($" THEN {label}");

            if (thenAction == null)
            {
                throw new ArgumentNullException(nameof(thenAction), "Cannot invoke a null action");
            }

            thenAction();

            return new ThenClause();
        }
    }
}

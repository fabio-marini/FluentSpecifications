namespace FluentSpecifications
{
    using System;
    using System.Threading.Tasks;

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

        /// <summary>
        /// Represents the 'AND (THEN)' clause of a fluent specification (async)
        /// </summary>
        /// <param name="label">The free-text label to describe this clause</param>
        /// <param name="thenFunc">The function to execute for this clause</param>
        /// <returns>The 'AND (THEN)' clause of a fluent specification</returns>
        public IThenClause And(string label, Func<Task> thenFunc)
        {
            Console.WriteLine($"  AND {label}");

            if (thenFunc == null)
            {
                throw new ArgumentNullException(nameof(thenFunc), "Cannot invoke a null function");
            }

            var thenTask = thenFunc().ConfigureAwait(false);

            return new ThenClause();
        }
    }
}

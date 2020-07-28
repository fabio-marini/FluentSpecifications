namespace FluentSpecifications
{
    using System;
    using System.Threading.Tasks;

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
        /// Represents the 'AND (WHEN)' clause of a fluent specification (async)
        /// </summary>
        /// <param name="label">The free-text label to describe this clause</param>
        /// <param name="whenFunc">The function to execute for this clause</param>
        /// <returns>The 'AND (WHEN)' clause of a fluent specification</returns>
        public IWhenClause And(string label, Func<Task> whenFunc)
        {
            Console.WriteLine($"  AND {label}");

            if (whenFunc == null)
            {
                throw new ArgumentNullException(nameof(whenFunc), "Cannot invoke a null function");
            }

            var whenTask = whenFunc().ConfigureAwait(false);

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

        /// <summary>
        /// Represents the 'THEN' clause of a fluent specification (async)
        /// </summary>
        /// <param name="label">The free-text label to describe this clause</param>
        /// <param name="thenFunc">The function to execute for this clause</param>
        /// <returns>The 'THEN' clause of a fluent specification</returns>
        public IThenClause Then(string label, Func<Task> thenFunc)
        {
            Console.WriteLine($" THEN {label}");

            if (thenFunc == null)
            {
                throw new ArgumentNullException(nameof(thenFunc), "Cannot invoke a null function");
            }

            var thenTask = thenFunc().ConfigureAwait(false);

            return new ThenClause();
        }
    }
}

namespace FluentSpecifications
{
    using System;
    using System.IO;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents the 'THEN' clause of a fluent specification
    /// </summary>
    internal class ThenClause : IThenClause
    {
        private readonly TextWriter specWriter;

        /// <summary>
        /// Creates an instance of the fluent specification builder
        /// </summary>
        /// <param name="specWriter">The <see cref="TextWriter"/> to write the output to</param>
        public ThenClause(TextWriter specWriter)
        {
            this.specWriter = specWriter;
        }

        /// <summary>
        /// Represents the 'AND (THEN)' clause of a fluent specification
        /// </summary>
        /// <param name="label">The free-text label to describe this clause</param>
        /// <param name="thenAction">The action to execute for this clause</param>
        /// <returns>The 'AND (THEN)' clause of a fluent specification</returns>
        public IThenClause And(string label, Action thenAction)
        {
            if (thenAction == null)
            {
                throw new ArgumentNullException(nameof(thenAction), "Cannot invoke a null action");
            }

            thenAction();

            specWriter.WriteLine($"  AND {label}");

            return new ThenClause(specWriter);
        }

        /// <summary>
        /// Represents the 'AND (THEN)' clause of a fluent specification (async)
        /// </summary>
        /// <param name="label">The free-text label to describe this clause</param>
        /// <param name="thenFunc">The function to execute for this clause</param>
        /// <returns>The 'AND (THEN)' clause of a fluent specification</returns>
        public IThenClause And(string label, Func<Task> thenFunc)
        {
            if (thenFunc == null)
            {
                throw new ArgumentNullException(nameof(thenFunc), "Cannot invoke a null function");
            }

            thenFunc().ContinueWith(t => specWriter.WriteLine($"  AND {label}"), TaskContinuationOptions.ExecuteSynchronously).ConfigureAwait(false);

            return new ThenClause(specWriter);
        }
    }
}

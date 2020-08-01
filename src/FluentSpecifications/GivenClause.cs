namespace FluentSpecifications
{
    using System;
    using System.IO;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents the 'GIVEN' clause of a fluent specification
    /// </summary>
    internal class GivenClause : IGivenClause
    {
        private readonly TextWriter specWriter;

        /// <summary>
        /// Creates an instance of the 'GIVEN' clause
        /// </summary>
        /// <param name="specWriter">The <see cref="TextWriter"/> to write the output to</param>
        public GivenClause(TextWriter specWriter)
        {
            this.specWriter = specWriter;
        }

        /// <summary>
        /// Represents the 'AND (GIVEN)' clause of a fluent specification
        /// </summary>
        /// <param name="label">The free-text label to describe this clause</param>
        /// <param name="givenAction">The action to execute for this clause</param>
        /// <returns>The 'AND (GIVEN)' clause of a fluent specification</returns>
        public IGivenClause And(string label, Action givenAction)
        {
            if (givenAction == null)
            {
                throw new ArgumentNullException(nameof(givenAction), "Cannot invoke a null action");
            }

            givenAction();

            specWriter.WriteLine($"  AND {label}");

            return new GivenClause(specWriter);
        }

        /// <summary>
        /// Represents the 'AND (GIVEN)' clause of a fluent specification (async)
        /// </summary>
        /// <param name="label">The free-text label to describe this clause</param>
        /// <param name="givenFunc">The function to execute for this clause</param>
        /// <returns>The 'AND (GIVEN)' clause of a fluent specification</returns>
        public IGivenClause And(string label, Func<Task> givenFunc)
        {
            if (givenFunc == null)
            {
                throw new ArgumentNullException(nameof(givenFunc), "Cannot invoke a null function");
            }

            givenFunc().GetAwaiter().GetResult();

            specWriter.WriteLine($"  AND {label}");

            return new GivenClause(specWriter);
        }

        /// <summary>
        /// Represents the 'THEN' clause of a fluent specification
        /// </summary>
        /// <param name="label">The free-text label to describe this clause</param>
        /// <param name="thenAction">The action to execute for this clause</param>
        /// <returns>The 'THEN' clause of a fluent specification</returns>
        public IThenClause Then(string label, Action thenAction)
        {
            if (thenAction == null)
            {
                throw new ArgumentNullException(nameof(thenAction), "Cannot invoke a null action");
            }

            thenAction();

            specWriter.WriteLine($" THEN {label}");

            return new ThenClause(specWriter);
        }

        /// <summary>
        /// Represents the 'THEN' clause of a fluent specification (async)
        /// </summary>
        /// <param name="label">The free-text label to describe this clause</param>
        /// <param name="thenFunc">The function to execute for this clause</param>
        /// <returns>The 'THEN' clause of a fluent specification</returns>
        public IThenClause Then(string label, Func<Task> thenFunc)
        {
            if (thenFunc == null)
            {
                throw new ArgumentNullException(nameof(thenFunc), "Cannot invoke a null function");
            }

            thenFunc().GetAwaiter().GetResult();

            specWriter.WriteLine($" THEN {label}");

            return new ThenClause(specWriter);
        }

        /// <summary>
        /// Represents the 'WHEN' clause of a fluent specification
        /// </summary>
        /// <param name="label">The free-text label to describe this clause</param>
        /// <param name="whenAction">The action to execute for this clause</param>
        /// <returns>The 'WHEN' clause of a fluent specification</returns>
        public IWhenClause When(string label, Action whenAction)
        {
            if (whenAction == null)
            {
                throw new ArgumentNullException(nameof(whenAction), "Cannot invoke a null action");
            }

            whenAction();

            specWriter.WriteLine($" WHEN {label}");

            return new WhenClause(specWriter);
        }

        /// <summary>
        /// Represents the 'WHEN' clause of a fluent specification (async)
        /// </summary>
        /// <param name="label">The free-text label to describe this clause</param>
        /// <param name="whenFunc">The function to execute for this clause</param>
        /// <returns>The 'WHEN' clause of a fluent specification</returns>
        public IWhenClause When(string label, Func<Task> whenFunc)
        {
            if (whenFunc == null)
            {
                throw new ArgumentNullException(nameof(whenFunc), "Cannot invoke a null function");
            }

            whenFunc().GetAwaiter().GetResult();

            specWriter.WriteLine($" WHEN {label}");

            return new WhenClause(specWriter);
        }
    }
}

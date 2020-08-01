[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("FluentSpecifications.Tests")]
namespace FluentSpecifications
{
    using System;
    using System.IO;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents the entry point of a fluent specification
    /// </summary>
    public class FluentSpecBuilder : IFluentSpecBuilder
    {
        private readonly TextWriter specWriter;

        /// <summary>
        /// Creates an instance of the fluent specification builder
        /// </summary>
        /// <param name="specWriter">The <see cref="TextWriter"/> to write the output to</param>
        public FluentSpecBuilder(TextWriter specWriter = null)
        {
            this.specWriter = specWriter ?? new StringWriter();
        }

        /// <summary>
        /// Represents the 'GIVEN' clause of a fluent specification (sync)
        /// </summary>
        /// <param name="label">The free-text label to describe this clause</param>
        /// <param name="givenAction">The action to execute for this clause</param>
        /// <returns>The 'GIVEN' clause of a fluent specification</returns>
        public IGivenClause Given(string label, Action givenAction)
        {
            if (givenAction == null)
            {
                throw new ArgumentNullException(nameof(givenAction), "Cannot invoke a null action");
            }

            givenAction();

            specWriter.WriteLine($"GIVEN {label}");

            return new GivenClause(specWriter);
        }

        /// <summary>
        /// Represents the 'GIVEN' clause of a fluent specification (async)
        /// </summary>
        /// <param name="label">The free-text label to describe this clause</param>
        /// <param name="givenFunc">The function to execute for this clause</param>
        /// <returns>The 'GIVEN' clause of a fluent specification</returns>
        public IGivenClause Given(string label, Func<Task> givenFunc)
        {
            if (givenFunc == null)
            {
                throw new ArgumentNullException(nameof(givenFunc), "Cannot invoke a null function");
            }

            givenFunc().GetAwaiter().GetResult();

            specWriter.WriteLine($"GIVEN {label}");
            
            return new GivenClause(specWriter);
        }

        /// <summary>
        /// Represents the 'WHEN' clause of a fluent specification (sync)
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

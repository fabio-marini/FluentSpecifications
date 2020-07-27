namespace FluentSpecifications
{
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents the entry point of a fluent specification
    /// </summary>
    public class FluentSpecBuilder : IFluentSpecBuilder
    {
        /// <summary>
        /// Represents the 'GIVEN' clause of a fluent specification
        /// </summary>
        /// <param name="label">The free-text label to describe this clause</param>
        /// <param name="givenAction">The action to execute for this clause</param>
        /// <returns>The 'GIVEN' clause of a fluent specification</returns>
        public IGivenClause Given(string label, Action givenAction)
        {
            Console.WriteLine($"GIVEN {label}");

            if (givenAction == null)
            {
                throw new ArgumentNullException(nameof(givenAction), "Cannot invoke a null action");
            }

            givenAction();

            return new GivenClause();
        }

        public IGivenClause Given(string label, Func<Task> givenFunc)
        {
            Console.WriteLine($"GIVEN {label}");

            if (givenFunc == null)
            {
                throw new ArgumentNullException(nameof(givenFunc), "Cannot invoke a null function");
            }

            var givenTask = givenFunc();

            return new GivenClause();
        }

        /// <summary>
        /// Represents the 'WHEN' clause of a fluent specification
        /// </summary>
        /// <param name="label">The free-text label to describe this clause</param>
        /// <param name="whenAction">The action to execute for this clause</param>
        /// <returns>The 'WHEN' clause of a fluent specification</returns>
        public IWhenClause When(string label, Action whenAction)
        {
            Console.WriteLine($" WHEN {label}");

            if (whenAction == null)
            {
                throw new ArgumentNullException(nameof(whenAction), "Cannot invoke a null action");
            }

            whenAction();

            return new WhenClause();
        }

        public IWhenClause When(string label, Func<Task> whenFunc)
        {
            Console.WriteLine($" WHEN {label}");

            if (whenFunc == null)
            {
                throw new ArgumentNullException(nameof(whenFunc), "Cannot invoke a null function");
            }

            var whenTask = whenFunc();

            return new WhenClause();
        }
    }
}

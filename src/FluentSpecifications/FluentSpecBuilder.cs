namespace FluentSpecifications
{
    using System;

    public class FluentSpecBuilder
    {
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
    }
}

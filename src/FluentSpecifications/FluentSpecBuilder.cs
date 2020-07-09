namespace FluentSpecifications
{
    using System;

    public class FluentSpecBuilder
    {
        private readonly IServiceProvider serviceProvider;

        public FluentSpecBuilder(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IGivenClause Given(string label, Action<IServiceProvider> givenAction)
        {
            Console.WriteLine($"GIVEN {label}");

            if (givenAction == null)
            {
                throw new ArgumentNullException(nameof(givenAction), "Cannot invoke a null action");
            }

            givenAction(serviceProvider);

            return new GivenClause(serviceProvider);
        }

        public IWhenClause When(string label, Action<IServiceProvider> whenAction)
        {
            Console.WriteLine($" WHEN {label}");

            if (whenAction == null)
            {
                throw new ArgumentNullException(nameof(whenAction), "Cannot invoke a null action");
            }

            whenAction(serviceProvider);

            return new WhenClause(serviceProvider);
        }
    }
}

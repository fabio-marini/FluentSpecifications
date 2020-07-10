namespace FluentSpecifications
{
    using Microsoft.Extensions.DependencyInjection;
    using System;

    public class FluentSpecBuilder
    {
        private readonly IServiceCollection serviceCollection;

        public FluentSpecBuilder(IServiceCollection serviceCollection = null)
        {
            this.serviceCollection = serviceCollection ?? new ServiceCollection();
        }

        public IGivenClause Given(string label, Action<IServiceCollection> givenAction)
        {
            Console.WriteLine($"GIVEN {label}");

            if (givenAction == null)
            {
                throw new ArgumentNullException(nameof(givenAction), "Cannot invoke a null action");
            }

            givenAction(serviceCollection);

            return new GivenClause(serviceCollection);
        }

        public IWhenClause When(string label, Action<IServiceProvider> whenAction)
        {
            Console.WriteLine($" WHEN {label}");

            if (whenAction == null)
            {
                throw new ArgumentNullException(nameof(whenAction), "Cannot invoke a null action");
            }

            var serviceProvider = serviceCollection.BuildServiceProvider();

            whenAction(serviceProvider);

            return new WhenClause(serviceProvider);
        }
    }
}

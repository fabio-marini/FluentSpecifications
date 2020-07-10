namespace FluentSpecifications
{
    using Microsoft.Extensions.DependencyInjection;
    using System;

    public class GivenClause : IGivenClause
    {
        private readonly IServiceCollection serviceCollection;

        public GivenClause(IServiceCollection serviceCollection)
        {
            this.serviceCollection = serviceCollection ?? new ServiceCollection();
        }

        public IGivenClause And(string label, Action<IServiceCollection> givenAction)
        {
            Console.WriteLine($"  AND {label}");

            if (givenAction == null)
            {
                throw new ArgumentNullException(nameof(givenAction), "Cannot invoke a null action");
            }

            givenAction(serviceCollection);

            return new GivenClause(serviceCollection);
        }

        public IThenClause Then(string label, Action<IServiceProvider> thenAction)
        {
            Console.WriteLine($" THEN {label}");

            if (thenAction == null)
            {
                throw new ArgumentNullException(nameof(thenAction), "Cannot invoke a null action");
            }

            var serviceProvider = serviceCollection.BuildServiceProvider();

            thenAction(serviceProvider);

            return new ThenClause(serviceProvider);
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

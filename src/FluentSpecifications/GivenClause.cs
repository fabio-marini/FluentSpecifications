namespace FluentSpecifications
{
    using System;

    public class GivenClause : IGivenClause
    {
        private readonly IServiceProvider serviceProvider;

        public GivenClause(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IGivenClause And(string label, Action<IServiceProvider> givenAction)
        {
            Console.WriteLine($"  AND {label}");

            if (givenAction == null)
            {
                throw new ArgumentNullException(nameof(givenAction), "Cannot invoke a null action");
            }

            givenAction(serviceProvider);

            return new GivenClause(serviceProvider);
        }

        public IThenClause Then(string label, Action<IServiceProvider> thenAction)
        {
            Console.WriteLine($" THEN {label}");

            if (thenAction == null)
            {
                throw new ArgumentNullException(nameof(thenAction), "Cannot invoke a null action");
            }

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

            whenAction(serviceProvider);

            return new WhenClause(serviceProvider);
        }
    }
}

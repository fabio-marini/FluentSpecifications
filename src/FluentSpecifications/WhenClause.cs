namespace FluentSpecifications
{
    using System;

    public class WhenClause : IWhenClause
    {
        private readonly IServiceProvider serviceProvider;

        public WhenClause(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IWhenClause And(string label, Action<IServiceProvider> whenAction)
        {
            Console.WriteLine($"  AND {label}");

            if (whenAction == null)
            {
                throw new ArgumentNullException(nameof(whenAction), "Cannot invoke a null action");
            }

            whenAction(serviceProvider);

            return new WhenClause(serviceProvider);
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
    }
}

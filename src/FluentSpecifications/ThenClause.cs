namespace FluentSpecifications
{
    using System;

    public class ThenClause : IThenClause
    {
        private readonly IServiceProvider serviceProvider;

        public ThenClause(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IThenClause And(string label, Action<IServiceProvider> thenAction)
        {
            Console.WriteLine($"  AND {label}");

            if (thenAction == null)
            {
                throw new ArgumentNullException(nameof(thenAction), "Cannot invoke a null action");
            }

            thenAction(serviceProvider);

            return new ThenClause(serviceProvider);
        }
    }
}

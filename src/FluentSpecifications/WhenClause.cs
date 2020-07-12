namespace FluentSpecifications
{
    using System;

    public class WhenClause : IWhenClause
    {
        public IWhenClause And(string label, Action whenAction)
        {
            Console.WriteLine($"  AND {label}");

            if (whenAction == null)
            {
                throw new ArgumentNullException(nameof(whenAction), "Cannot invoke a null action");
            }

            whenAction();

            return new WhenClause();
        }

        public IThenClause Then(string label, Action thenAction)
        {
            Console.WriteLine($" THEN {label}");

            if (thenAction == null)
            {
                throw new ArgumentNullException(nameof(thenAction), "Cannot invoke a null action");
            }

            thenAction();

            return new ThenClause();
        }
    }
}

namespace FluentSpecifications
{
    using System;

    public class ThenClause : IThenClause
    {
        public IThenClause And(string label, Action thenAction)
        {
            Console.WriteLine($"  AND {label}");

            if (thenAction == null)
            {
                throw new ArgumentNullException(nameof(thenAction), "Cannot invoke a null action");
            }

            thenAction();

            return new ThenClause();
        }
    }
}

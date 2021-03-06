﻿namespace FluentSpecifications
{
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents the entry point of a fluent specification
    /// </summary>
    public interface IFluentSpecBuilder
    {
        /// <summary>
        /// Represents the 'GIVEN' clause of a fluent specification (sync)
        /// </summary>
        /// <param name="label">The free-text label to describe this clause</param>
        /// <param name="givenAction">The action to execute for this clause</param>
        /// <returns>The 'GIVEN' clause of a fluent specification</returns>
        IGivenClause Given(string label, Action givenAction);

        /// <summary>
        /// Represents the 'GIVEN' clause of a fluent specification (async)
        /// </summary>
        /// <param name="label">The free-text label to describe this clause</param>
        /// <param name="givenFunc">The function to execute for this clause</param>
        /// <returns>The 'GIVEN' clause of a fluent specification</returns>
        IGivenClause Given(string label, Func<Task> givenFunc);

        /// <summary>
        /// Represents the 'WHEN' clause of a fluent specification (sync)
        /// </summary>
        /// <param name="label">The free-text label to describe this clause</param>
        /// <param name="whenAction">The action to execute for this clause</param>
        /// <returns>The 'WHEN' clause of a fluent specification</returns>
        IWhenClause When(string label, Action whenAction);

        /// <summary>
        /// Represents the 'WHEN' clause of a fluent specification (async)
        /// </summary>
        /// <param name="label">The free-text label to describe this clause</param>
        /// <param name="whenFunc">The function to execute for this clause</param>
        /// <returns>The 'WHEN' clause of a fluent specification</returns>
        IWhenClause When(string label, Func<Task> whenFunc);
    }
}

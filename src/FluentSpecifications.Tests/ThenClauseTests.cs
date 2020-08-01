namespace FluentSpecifications.Tests
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Xunit;

    public class ThenClauseTests
    {
        private readonly IThenClause thenClause;
        private readonly StringWriter specWriter;

        public ThenClauseTests()
        {
            specWriter = new StringWriter();
            thenClause = new ThenClause(specWriter);
        }

        #region Sync Methods

        [Fact(DisplayName = "'THEN' And(string, Action) throws if Action is null")]
        public void TestAndActionIsNull()
        {
            try
            {
                thenClause.And("my label", default(Action));

                true.Should().BeFalse();
            }
            catch (Exception ex)
            {
                ex.Should().BeOfType<ArgumentNullException>();
                ex.Message.Should().Be("Cannot invoke a null action (Parameter 'thenAction')");

                specWriter.ToString().Length.Should().Be(0);
            }
        }

        [Fact(DisplayName = "'THEN' And(string, Action) returns if Action is not null")]
        public void TestAndActionNotNull()
        {
            var x = 0;

            thenClause.And("my label", () => x = 1);

            x.Should().Be(1);

            specWriter.ToString().Should().Be("  AND my label\r\n");
        }

        #endregion

        #region Async Methods

        [Fact(DisplayName = "'THEN' And(string, Func<Task>) throws if Func<Task> is null")]
        public void TestAndFunctionIsNull()
        {
            try
            {
                thenClause.And("my label", default(Func<Task>));

                true.Should().BeFalse();
            }
            catch (Exception ex)
            {
                ex.Should().BeOfType<ArgumentNullException>();
                ex.Message.Should().Be("Cannot invoke a null function (Parameter 'thenFunc')");

                specWriter.ToString().Length.Should().Be(0);
            }
        }

        [Fact(DisplayName = "'THEN' And(string, Func<Task>) returns if Func<Task> is not null")]
        public void TestAndFunctionNotNull()
        {
            var x = 0;

            thenClause.And("my label", () =>
            {
                x = 1;

                return Task.CompletedTask;
            });

            x.Should().Be(1);

            specWriter.ToString().Should().Be("  AND my label\r\n");
        }

        #endregion
    }
}

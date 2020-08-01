namespace FluentSpecifications.Tests
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Xunit;

    public class WhenClauseTests
    {
        private readonly IWhenClause whenClause;
        private readonly StringWriter specWriter;

        public WhenClauseTests()
        {
            specWriter = new StringWriter();
            whenClause = new WhenClause(specWriter);
        }

        #region Sync Methods

        [Fact(DisplayName = "'WHEN' And(string, Action) throws if Action is null")]
        public void TestAndActionIsNull()
        {
            try
            {
                whenClause.And("my label", default(Action));

                true.Should().BeFalse();
            }
            catch (Exception ex)
            {
                ex.Should().BeOfType<ArgumentNullException>();
                ex.Message.Should().Be("Cannot invoke a null action (Parameter 'whenAction')");

                specWriter.ToString().Length.Should().Be(0);
            }
        }

        [Fact(DisplayName = "'WHEN' And(string, Action) returns if Action is not null")]
        public void TestAndActionNotNull()
        {
            var x = 0;

            whenClause.And("my label", () => x = 1);

            x.Should().Be(1);

            specWriter.ToString().Should().Be("  AND my label\r\n");
        }

        [Fact(DisplayName = "'WHEN' Then(string, Action) throws if Action is null")]
        public void TestThenActionIsNull()
        {
            try
            {
                whenClause.Then("my label", default(Action));

                true.Should().BeFalse();
            }
            catch (Exception ex)
            {
                ex.Should().BeOfType<ArgumentNullException>();
                ex.Message.Should().Be("Cannot invoke a null action (Parameter 'thenAction')");

                specWriter.ToString().Length.Should().Be(0);
            }
        }

        [Fact(DisplayName = "'WHEN' Then(string, Action) returns if Action is not null")]
        public void TestThenActionNotNull()
        {
            var x = 0;

            whenClause.Then("my label", () => x = 1);

            x.Should().Be(1);

            specWriter.ToString().Should().Be(" THEN my label\r\n");
        }

        #endregion

        #region Sync Methods

        [Fact(DisplayName = "'WHEN' And(string, Func<Task>) throws if Func<Task> is null")]
        public void TestAndFunctionIsNull()
        {
            try
            {
                whenClause.And("my label", default(Func<Task>));

                true.Should().BeFalse();
            }
            catch (Exception ex)
            {
                ex.Should().BeOfType<ArgumentNullException>();
                ex.Message.Should().Be("Cannot invoke a null function (Parameter 'whenFunc')");

                specWriter.ToString().Length.Should().Be(0);
            }
        }

        [Fact(DisplayName = "'WHEN' And(string, Func<Task>) returns if Func<Task> is not null")]
        public void TestAndFunctionNotNull()
        {
            var x = 0;

            whenClause.And("my label", () =>
            {
                x = 1;

                return Task.CompletedTask;
            });

            x.Should().Be(1);

            specWriter.ToString().Should().Be("  AND my label\r\n");
        }

        [Fact(DisplayName = "'WHEN' Then(string, Func<Task>) throws if Func<Task> is null")]
        public void TestThenFunctionIsNull()
        {
            try
            {
                whenClause.Then("my label", default(Func<Task>));

                true.Should().BeFalse();
            }
            catch (Exception ex)
            {
                ex.Should().BeOfType<ArgumentNullException>();
                ex.Message.Should().Be("Cannot invoke a null function (Parameter 'thenFunc')");

                specWriter.ToString().Length.Should().Be(0);
            }
        }

        [Fact(DisplayName = "'WHEN' Then(string, Func<Task>) returns if Func<Task> is not null")]
        public void TestThenFunctionNotNull()
        {
            var x = 0;

            whenClause.Then("my label", () =>
            {
                x = 1;

                return Task.CompletedTask;
            });

            x.Should().Be(1);

            specWriter.ToString().Should().Be(" THEN my label\r\n");
        }

        #endregion
    }
}

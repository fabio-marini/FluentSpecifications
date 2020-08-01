namespace FluentSpecifications.Tests
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Xunit;

    public class GivenClauseTests
    {
        private readonly IGivenClause givenClause;
        private readonly StringWriter specWriter;

        public GivenClauseTests()
        {
            specWriter = new StringWriter();
            givenClause = new GivenClause(specWriter);
        }

        #region Sync Methods

        [Fact(DisplayName = "'GIVEN' And(string, Action) throws if Action is null")]
        public void TestAndActionIsNull()
        {
            try
            {
                givenClause.And("my label", default(Action));

                true.Should().BeFalse();
            }
            catch (Exception ex)
            {
                ex.Should().BeOfType<ArgumentNullException>();
                ex.Message.Should().Be("Cannot invoke a null action (Parameter 'givenAction')");

                specWriter.ToString().Length.Should().Be(0);
            }
        }

        [Fact(DisplayName = "'GIVEN' And(string, Action) returns if Action is not null")]
        public void TestAndActionNotNull()
        {
            var x = 0;

            givenClause.And("my label", () => x = 1);

            x.Should().Be(1);

            specWriter.ToString().Should().Be("  AND my label\r\n");
        }

        [Fact(DisplayName = "'GIVEN' When(string, Action) throws if Action is null")]
        public void TestWhenActionIsNull()
        {
            try
            {
                givenClause.When("my label", default(Action));

                true.Should().BeFalse();
            }
            catch (Exception ex)
            {
                ex.Should().BeOfType<ArgumentNullException>();
                ex.Message.Should().Be("Cannot invoke a null action (Parameter 'whenAction')");

                specWriter.ToString().Length.Should().Be(0);
            }
        }

        [Fact(DisplayName = "'GIVEN' When(string, Action) returns if Action is not null")]
        public void TestWhenActionNotNull()
        {
            var x = 0;

            givenClause.When("my label", () => x = 1);

            x.Should().Be(1);

            specWriter.ToString().Should().Be(" WHEN my label\r\n");
        }

        [Fact(DisplayName = "'GIVEN' Then(string, Action) throws if Action is null")]
        public void TestThenActionIsNull()
        {
            try
            {
                givenClause.Then("my label", default(Action));

                true.Should().BeFalse();
            }
            catch (Exception ex)
            {
                ex.Should().BeOfType<ArgumentNullException>();
                ex.Message.Should().Be("Cannot invoke a null action (Parameter 'thenAction')");

                specWriter.ToString().Length.Should().Be(0);
            }
        }

        [Fact(DisplayName = "'GIVEN' Then(string, Action) returns if Action is not null")]
        public void TestThenActionNotNull()
        {
            var x = 0;

            givenClause.Then("my label", () => x = 1);

            x.Should().Be(1);

            specWriter.ToString().Should().Be(" THEN my label\r\n");
        }

        #endregion

        #region Async Methods

        [Fact(DisplayName = "'GIVEN' And(string, Func<Task>) throws if Func<Task> is null")]
        public void TestAndFunctionIsNull()
        {
            try
            {
                givenClause.And("my label", default(Func<Task>));

                true.Should().BeFalse();
            }
            catch (Exception ex)
            {
                ex.Should().BeOfType<ArgumentNullException>();
                ex.Message.Should().Be("Cannot invoke a null function (Parameter 'givenFunc')");

                specWriter.ToString().Length.Should().Be(0);
            }
        }

        [Fact(DisplayName = "'GIVEN' And(string, Func<Task>) returns if Func<Task> is not null")]
        public void TestAndFunctionNotNull()
        {
            var x = 0;

            givenClause.And("my label", () =>
            {
                x = 1;

                return Task.CompletedTask;
            });

            x.Should().Be(1);


            specWriter.ToString().Should().Be("  AND my label\r\n");
        }

        [Fact(DisplayName = "'GIVEN' When(string, Func<Task>) throws if Func<Task> is null")]
        public void TestWhenFunctionIsNull()
        {
            try
            {
                givenClause.When("my label", default(Func<Task>));

                true.Should().BeFalse();
            }
            catch (Exception ex)
            {
                ex.Should().BeOfType<ArgumentNullException>();
                ex.Message.Should().Be("Cannot invoke a null function (Parameter 'whenFunc')");

                specWriter.ToString().Length.Should().Be(0);
            }
        }

        [Fact(DisplayName = "'GIVEN' When(string, Func<Task>) returns if Func<Task> is not null")]
        public void TestWhenFunctionNotNull()
        {
            var x = 0;

            givenClause.When("my label", () =>
            {
                x = 1;

                return Task.CompletedTask;
            });

            x.Should().Be(1);

            specWriter.ToString().Should().Be(" WHEN my label\r\n");
        }

        [Fact(DisplayName = "'GIVEN' Then(string, Func<Task>) throws if Func<Task> is null")]
        public void TestThenFunctionIsNull()
        {
            try
            {
                givenClause.Then("my label", default(Func<Task>));

                true.Should().BeFalse();
            }
            catch (Exception ex)
            {
                ex.Should().BeOfType<ArgumentNullException>();
                ex.Message.Should().Be("Cannot invoke a null function (Parameter 'thenFunc')");

                specWriter.ToString().Length.Should().Be(0);
            }
        }

        [Fact(DisplayName = "'GIVEN' Then(string, Func<Task>) returns if Func<Task> is not null")]
        public void TestThenFunctionNotNull()
        {
            var x = 0;

            givenClause.Then("my label", () =>
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

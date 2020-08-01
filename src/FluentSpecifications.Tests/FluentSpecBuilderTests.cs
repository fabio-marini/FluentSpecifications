namespace FluentSpecifications.Tests
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Xunit;

    public class FluentSpecBuilderTests
    {
        private readonly FluentSpecBuilder specBuilder;
        private readonly StringWriter specWriter;

        public FluentSpecBuilderTests()
        {
            specWriter = new StringWriter();
            specBuilder = new FluentSpecBuilder(specWriter);
        }

        #region Sync Methods

        [Fact(DisplayName = "Builder Given(string, Action) throws if Action is null")]
        public void TestGivenActionIsNull()
        {
            try
            {
                specBuilder.Given("my label", default(Action));

                true.Should().BeFalse();
            }
            catch (Exception ex)
            {
                ex.Should().BeOfType<ArgumentNullException>();
                ex.Message.Should().Be("Cannot invoke a null action (Parameter 'givenAction')");

                specWriter.ToString().Length.Should().Be(0);
            }
        }

        [Fact(DisplayName = "Builder Given(string, Action) returns if Action is not null")]
        public void TestGivenActionNotNull()
        {
            var x = 0;

            specBuilder.Given("my label", () => x = 1);

            x.Should().Be(1);

            specWriter.ToString().Should().Be("GIVEN my label\r\n");
        }

        [Fact(DisplayName = "Builder When(string, Action) throws if Action is null")]
        public void TestWhenActionIsNull()
        {
            try
            {
                specBuilder.When("my label", default(Action));

                true.Should().BeFalse();
            }
            catch (Exception ex)
            {
                ex.Should().BeOfType<ArgumentNullException>();
                ex.Message.Should().Be("Cannot invoke a null action (Parameter 'whenAction')");

                specWriter.ToString().Length.Should().Be(0);
            }
        }

        [Fact(DisplayName = "Builder When(string, Action) returns if Action is not null")]
        public void TestWhenActionNotNull()
        {
            var x = 0;

            specBuilder.When("my label", () => x = 1);

            x.Should().Be(1);

            specWriter.ToString().Should().Be(" WHEN my label\r\n");
        }

        #endregion

        #region Async Methods

        [Fact(DisplayName = "Builder Given(string, Func<Task>) throws if Func<Task> is null")]
        public void TestGivenFunctionIsNull()
        {
            try
            {
                specBuilder.Given("my label", default(Func<Task>));

                true.Should().BeFalse();
            }
            catch (Exception ex)
            {
                ex.Should().BeOfType<ArgumentNullException>();
                ex.Message.Should().Be("Cannot invoke a null function (Parameter 'givenFunc')");

                specWriter.ToString().Length.Should().Be(0);
            }
        }

        [Fact(DisplayName = "Builder Given(string, Func<Task>) returns if Func<Task> is not null")]
        public void TestGivenFunctionNotNull()
        {
            var x = 0;

            specBuilder.Given("my label", () =>
            {
                x = 1;

                return Task.CompletedTask;
            });

            x.Should().Be(1);

            specWriter.ToString().Should().Be("GIVEN my label\r\n");
        }

        [Fact(DisplayName = "Builder When(string, Func<Task>) throws if Func<Task> is null")]
        public void TestWhenFunctionIsNull()
        {
            try
            {
                specBuilder.When("my label", default(Func<Task>));

                true.Should().BeFalse();
            }
            catch (Exception ex)
            {
                ex.Should().BeOfType<ArgumentNullException>();
                ex.Message.Should().Be("Cannot invoke a null function (Parameter 'whenFunc')");

                specWriter.ToString().Length.Should().Be(0);
            }
        }

        [Fact(DisplayName = "Builder When(string, Func<Task>) returns if Func<Task> is not null")]
        public void TestWhenFunctionNotNull()
        {
            var x = 0;

            specBuilder.When("my label", () =>
            {
                x = 1;

                return Task.CompletedTask;
            });

            x.Should().Be(1);

            specWriter.ToString().Should().Be(" WHEN my label\r\n");
        }

        #endregion
    }
}

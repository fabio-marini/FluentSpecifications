namespace FluentSpecifications.Tests
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Threading.Tasks;

    [TestClass]
    public class FluentSpecBuilderTests
    {
        private readonly FluentSpecBuilder fluentSpecBuilder = new FluentSpecBuilder();

        #region Sync Methods

        [TestMethod]
        public void TestGivenActionIsNull()
        {
            try
            {
                fluentSpecBuilder.Given("my label", default(Action));

                true.Should().BeFalse();
            }
            catch (Exception ex)
            {
                ex.Should().BeOfType<ArgumentNullException>();
                ex.Message.Should().Be("Cannot invoke a null action (Parameter 'givenAction')");
            }
        }

        [TestMethod]
        public void TestGivenActionNotNull()
        {
            var x = 0;

            fluentSpecBuilder.Given("my label", () => x = 1);

            x.Should().Be(1);
        }

        [TestMethod]
        public void TestWhenActionIsNull()
        {
            try
            {
                fluentSpecBuilder.When("my label", default(Action));

                true.Should().BeFalse();
            }
            catch (Exception ex)
            {
                ex.Should().BeOfType<ArgumentNullException>();
                ex.Message.Should().Be("Cannot invoke a null action (Parameter 'whenAction')");
            }
        }

        [TestMethod]
        public void TestWhenActionNotNull()
        {
            var x = 0;

            fluentSpecBuilder.When("my label", () => x = 1);

            x.Should().Be(1);
        }

        #endregion

        #region Async Methods

        [TestMethod]
        public void TestGivenFunctionIsNull()
        {
            try
            {
                fluentSpecBuilder.Given("my label", default(Func<Task>));

                true.Should().BeFalse();
            }
            catch (Exception ex)
            {
                ex.Should().BeOfType<ArgumentNullException>();
                ex.Message.Should().Be("Cannot invoke a null function (Parameter 'givenFunc')");
            }
        }

        [TestMethod]
        public void TestGivenFunctionNotNull()
        {
            var x = 0;

            fluentSpecBuilder.Given("my label", () =>
            {
                x = 1;

                return Task.CompletedTask;
            });

            x.Should().Be(1);
        }

        [TestMethod]
        public void TestWhenFunctionIsNull()
        {
            try
            {
                fluentSpecBuilder.When("my label", default(Func<Task>));

                true.Should().BeFalse();
            }
            catch (Exception ex)
            {
                ex.Should().BeOfType<ArgumentNullException>();
                ex.Message.Should().Be("Cannot invoke a null function (Parameter 'whenFunc')");
            }
        }

        [TestMethod]
        public void TestWhenFunctionNotNull()
        {
            var x = 0;

            fluentSpecBuilder.When("my label", () =>
            {
                x = 1;

                return Task.CompletedTask;
            });

            x.Should().Be(1);
        }

        #endregion
    }
}

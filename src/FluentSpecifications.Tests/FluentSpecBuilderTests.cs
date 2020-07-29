namespace FluentSpecifications.Tests
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.IO;
    using System.Threading.Tasks;

    [TestClass]
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

        [TestMethod]
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

        [TestMethod]
        public void TestGivenActionNotNull()
        {
            var x = 0;

            specBuilder.Given("my label", () => x = 1);

            x.Should().Be(1);

            specWriter.ToString().Should().Be("GIVEN my label\r\n");
        }

        [TestMethod]
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

        [TestMethod]
        public void TestWhenActionNotNull()
        {
            var x = 0;

            specBuilder.When("my label", () => x = 1);

            x.Should().Be(1);

            specWriter.ToString().Should().Be(" WHEN my label\r\n");
        }

        #endregion

        #region Async Methods

        [TestMethod]
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

        [TestMethod]
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

        [TestMethod]
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

        [TestMethod]
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

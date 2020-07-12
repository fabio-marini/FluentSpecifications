namespace FluentSpecifications.Tests
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    [TestClass]
    public class FluentSpecBuilderTests
    {
        private readonly FluentSpecBuilder fluentSpecBuilder = new FluentSpecBuilder();

        [TestMethod]
        public void TestGivenActionIsNull()
        {
            try
            {
                fluentSpecBuilder.Given("my label", null);

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
                fluentSpecBuilder.When("my label", null);

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

    }
}

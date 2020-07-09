using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FluentSpecifications.Tests
{
    [TestClass]
    public class FluentSpecBuilderTests
    {
        FluentSpecBuilder builder = new FluentSpecBuilder();

        [TestMethod]
        public void TestGivenActionIsNull()
        {
            try
            {
                builder.Given("my label", null);

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

            builder.Given("my label", () => x = 1);

            x.Should().Be(1);
        }

        [TestMethod]
        public void TestWhenActionIsNull()
        {
            try
            {
                builder.When("my label", null);

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

            builder.When("my label", () => x = 1);

            x.Should().Be(1);
        }
    }
}

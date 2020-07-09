using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FluentSpecifications.Tests
{
    [TestClass]
    public class WhenClauseTests
    {
        WhenClause when = new WhenClause();

        [TestMethod]
        public void TestWhenActionIsNull()
        {
            try
            {
                when.And("my label", null);

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

            when.And("my label", () => x = 1);

            x.Should().Be(1);
        }

        [TestMethod]
        public void TestThenActionIsNull()
        {
            try
            {
                when.Then("my label", null);

                true.Should().BeFalse();
            }
            catch (Exception ex)
            {
                ex.Should().BeOfType<ArgumentNullException>();
                ex.Message.Should().Be("Cannot invoke a null action (Parameter 'thenAction')");
            }
        }

        [TestMethod]
        public void TestThenActionNotNull()
        {
            var x = 0;

            when.Then("my label", () => x = 1);

            x.Should().Be(1);
        }
    }
}

using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FluentSpecifications.Tests
{
    [TestClass]
    public class ThenClauseTests
    {
        ThenClause then = new ThenClause();

        [TestMethod]
        public void TestThenActionIsNull()
        {
            try
            {
                then.And("my label", null);

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

            then.And("my label", () => x = 1);

            x.Should().Be(1);
        }
    }
}

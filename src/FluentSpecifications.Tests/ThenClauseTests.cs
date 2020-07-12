namespace FluentSpecifications.Tests
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    [TestClass]
    public class ThenClauseTests
    {
        private readonly IThenClause thenClause = new ThenClause();

        [TestMethod]
        public void TestThenActionIsNull()
        {
            try
            {
                thenClause.And("my label", null);

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

            thenClause.And("my label", () => x = 1);

            x.Should().Be(1);
        }
    }
}

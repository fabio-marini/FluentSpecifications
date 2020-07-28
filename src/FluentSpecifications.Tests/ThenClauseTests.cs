namespace FluentSpecifications.Tests
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Threading.Tasks;

    [TestClass]
    public class ThenClauseTests
    {
        private readonly IThenClause thenClause = new ThenClause();

        #region Sync Methods

        [TestMethod]
        public void TestThenActionIsNull()
        {
            try
            {
                thenClause.And("my label", default(Action));

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

        #endregion

        #region Async Methods

        [TestMethod]
        public void TestThenFunctionIsNull()
        {
            try
            {
                thenClause.And("my label", default(Func<Task>));

                true.Should().BeFalse();
            }
            catch (Exception ex)
            {
                ex.Should().BeOfType<ArgumentNullException>();
                ex.Message.Should().Be("Cannot invoke a null function (Parameter 'thenFunc')");
            }
        }

        [TestMethod]
        public void TestThenFunctionNotNull()
        {
            var x = 0;

            thenClause.And("my label", () =>
            {
                x = 1;

                return Task.CompletedTask;
            });

            x.Should().Be(1);
        }

        #endregion
    }
}

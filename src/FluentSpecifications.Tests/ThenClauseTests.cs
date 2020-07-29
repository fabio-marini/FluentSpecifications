namespace FluentSpecifications.Tests
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.IO;
    using System.Threading.Tasks;

    [TestClass]
    public class ThenClauseTests
    {
        private readonly IThenClause thenClause;
        private readonly StringWriter specWriter;

        public ThenClauseTests()
        {
            specWriter = new StringWriter();
            thenClause = new ThenClause(specWriter);
        }


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

                specWriter.ToString().Length.Should().Be(0);
            }
        }

        [TestMethod]
        public void TestThenActionNotNull()
        {
            var x = 0;

            thenClause.And("my label", () => x = 1);

            x.Should().Be(1);

            specWriter.ToString().Should().Be("  AND my label\r\n");
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

                specWriter.ToString().Length.Should().Be(0);
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

            specWriter.ToString().Should().Be("  AND my label\r\n");
        }

        #endregion
    }
}

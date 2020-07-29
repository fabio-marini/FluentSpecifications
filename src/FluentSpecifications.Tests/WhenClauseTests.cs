namespace FluentSpecifications.Tests
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.IO;
    using System.Threading.Tasks;

    [TestClass]
    public class WhenClauseTests
    {
        private readonly IWhenClause whenClause;
        private readonly StringWriter specWriter;

        public WhenClauseTests()
        {
            specWriter = new StringWriter();
            whenClause = new WhenClause(specWriter);
        }


        #region Sync Methods

        [TestMethod]
        public void TestWhenActionIsNull()
        {
            try
            {
                whenClause.And("my label", default(Action));

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

            whenClause.And("my label", () => x = 1);

            x.Should().Be(1);

            specWriter.ToString().Should().Be("  AND my label\r\n");
        }

        [TestMethod]
        public void TestThenActionIsNull()
        {
            try
            {
                whenClause.Then("my label", default(Action));

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

            whenClause.Then("my label", () => x = 1);

            x.Should().Be(1);

            specWriter.ToString().Should().Be(" THEN my label\r\n");
        }

        #endregion

        #region Sync Methods

        [TestMethod]
        public void TestWhenFunctionIsNull()
        {
            try
            {
                whenClause.And("my label", default(Func<Task>));

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

            whenClause.And("my label", () =>
            {
                x = 1;

                return Task.CompletedTask;
            });

            x.Should().Be(1);

            specWriter.ToString().Should().Be("  AND my label\r\n");
        }

        [TestMethod]
        public void TestThenFunctionIsNull()
        {
            try
            {
                whenClause.Then("my label", default(Func<Task>));

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

            whenClause.Then("my label", () =>
            {
                x = 1;

                return Task.CompletedTask;
            });

            x.Should().Be(1);

            specWriter.ToString().Should().Be(" THEN my label\r\n");
        }

        #endregion
    }
}

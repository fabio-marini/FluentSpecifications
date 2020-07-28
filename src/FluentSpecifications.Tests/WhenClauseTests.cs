namespace FluentSpecifications.Tests
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Threading.Tasks;

    [TestClass]
    public class WhenClauseTests
    {
        private readonly IWhenClause whenClause = new WhenClause();

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
            }
        }

        [TestMethod]
        public void TestWhenActionNotNull()
        {
            var x = 0;

            whenClause.And("my label", () => x = 1);

            x.Should().Be(1);
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
            }
        }

        [TestMethod]
        public void TestThenActionNotNull()
        {
            var x = 0;

            whenClause.Then("my label", () => x = 1);

            x.Should().Be(1);
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
        }

        #endregion
    }
}

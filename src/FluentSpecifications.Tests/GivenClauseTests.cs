namespace FluentSpecifications.Tests
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Threading.Tasks;

    [TestClass]
    public class GivenClauseTests
    {
        private readonly IGivenClause givenClause = new GivenClause();

        #region Sync Methods

        [TestMethod]
        public void TestGivenActionIsNull()
        {
            try
            {
                givenClause.And("my label", default(Action));

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

            givenClause.And("my label", () => x = 1);

            x.Should().Be(1);
        }

        [TestMethod]
        public void TestWhenActionIsNull()
        {
            try
            {
                givenClause.When("my label", default(Action));

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

            givenClause.When("my label", () => x = 1);

            x.Should().Be(1);
        }

        [TestMethod]
        public void TestThenActionIsNull()
        {
            try
            {
                givenClause.Then("my label", default(Action));

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

            givenClause.Then("my label", () => x = 1);

            x.Should().Be(1);
        }

        #endregion

        #region Async Methods

        [TestMethod]
        public void TestGivenFunctionIsNull()
        {
            try
            {
                givenClause.And("my label", default(Func<Task>));

                true.Should().BeFalse();
            }
            catch (Exception ex)
            {
                ex.Should().BeOfType<ArgumentNullException>();
                ex.Message.Should().Be("Cannot invoke a null function (Parameter 'givenFunc')");
            }
        }

        [TestMethod]
        public void TestGivenFunctionNotNull()
        {
            var x = 0;

            givenClause.And("my label", () =>
            {
                x = 1;

                return Task.CompletedTask;
            });

            x.Should().Be(1);
        }

        [TestMethod]
        public void TestWhenFunctionIsNull()
        {
            try
            {
                givenClause.When("my label", default(Func<Task>));

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

            givenClause.When("my label", () =>
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
                givenClause.Then("my label", default(Func<Task>));

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

            givenClause.Then("my label", () =>
            {
                x = 1;

                return Task.CompletedTask;
            });

            x.Should().Be(1);
        }

        #endregion
    }
}

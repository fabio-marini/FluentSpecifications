namespace FluentSpecifications.Tests
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.IO;
    using System.Threading.Tasks;

    [TestClass]
    public class GivenClauseTests
    {
        private readonly IGivenClause givenClause;
        private readonly StringWriter specWriter;

        public GivenClauseTests()
        {
            specWriter = new StringWriter();
            givenClause = new GivenClause(specWriter);
        }

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

                specWriter.ToString().Length.Should().Be(0);
            }
        }

        [TestMethod]
        public void TestGivenActionNotNull()
        {
            var x = 0;

            givenClause.And("my label", () => x = 1);

            x.Should().Be(1);

            specWriter.ToString().Should().Be("  AND my label\r\n");
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

                specWriter.ToString().Length.Should().Be(0);
            }
        }

        [TestMethod]
        public void TestWhenActionNotNull()
        {
            var x = 0;

            givenClause.When("my label", () => x = 1);

            x.Should().Be(1);

            specWriter.ToString().Should().Be(" WHEN my label\r\n");
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

                specWriter.ToString().Length.Should().Be(0);
            }
        }

        [TestMethod]
        public void TestThenActionNotNull()
        {
            var x = 0;

            givenClause.Then("my label", () => x = 1);

            x.Should().Be(1);

            specWriter.ToString().Should().Be(" THEN my label\r\n");
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

                specWriter.ToString().Length.Should().Be(0);
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


            specWriter.ToString().Should().Be("  AND my label\r\n");
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

                specWriter.ToString().Length.Should().Be(0);
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

            specWriter.ToString().Should().Be(" WHEN my label\r\n");
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

                specWriter.ToString().Length.Should().Be(0);
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

            specWriter.ToString().Should().Be(" THEN my label\r\n");
        }

        #endregion
    }
}

using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FluentSpecifications.Tests
{
    [TestClass]
    public class GivenClauseTests
    {
        IGivenClause given = new GivenClause();

        [TestMethod]
        public void TestGivenActionIsNull()
        {
            var nullAction = default(Action<IServiceProvider>);

            try
            {
                given.And("my label", nullAction);

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

            given.And("my label", _ => x = 1);

            x.Should().Be(1);
        }

        [TestMethod]
        public void TestGivenActionWithServiceProviderIsNull()
        {
            var nullAction = default(Action<IServiceProvider>);

            try
            {
                given.And("my label", nullAction);

                true.Should().BeFalse();
            }
            catch (Exception ex)
            {
                ex.Should().BeOfType<ArgumentNullException>();
                ex.Message.Should().Be("Cannot invoke a null action (Parameter 'givenAction')");
            }
        }

        [TestMethod]
        public void TestGivenActionWithServiceProviderNotNull()
        {
            var svc = new ServiceCollection().AddTransient<string>(svc => "123").BuildServiceProvider();

            var x = "0";

            given = new GivenClause(svc);
            given.And("my label", (svc) => x = svc.GetService<string>());

            x.Should().Be("123");
        }

        [TestMethod]
        public void TestWhenActionIsNull()
        {
            try
            {
                given.When("my label", null);

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

            given.When("my label", () => x = 1);

            x.Should().Be(1);
        }

        [TestMethod]
        public void TestThenActionIsNull()
        {
            try
            {
                given.Then("my label", null);

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

            given.Then("my label", () => x = 1);

            x.Should().Be(1);
        }

    }
}

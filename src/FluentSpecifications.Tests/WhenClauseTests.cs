namespace FluentSpecifications.Tests
{
    using FluentAssertions;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    [TestClass]
    public class WhenClauseTests
    {
        private readonly IWhenClause whenClause;
        private readonly IServiceProvider serviceProvider;

        public WhenClauseTests()
        {
            serviceProvider = new ServiceCollection().AddSingleton<string>("Hello world!").BuildServiceProvider();

            whenClause = new WhenClause(serviceProvider);
        }

        [TestMethod]
        public void TestWhenActionIsNull()
        {
            try
            {
                whenClause.And("my label", null);

                true.Should().BeFalse();
            }
            catch (Exception ex)
            {
                ex.Should().BeOfType<ArgumentNullException>();
                ex.Message.Should().Be("Cannot invoke a null action (Parameter 'whenAction')");
            }
        }

        [TestMethod]
        public void TestWhenActionNoServiceProvider()
        {
            var x = 0;

            whenClause.And("my label", _ => x = 1);

            x.Should().Be(1);
        }

        [TestMethod]
        public void TestWhenActionAndServiceProvider()
        {
            var x = "0";

            whenClause.And("my label", svc => x = svc.GetService<string>());

            x.Should().Be("Hello world!");
        }

        [TestMethod]
        public void TestThenActionIsNull()
        {
            try
            {
                whenClause.Then("my label", null);

                true.Should().BeFalse();
            }
            catch (Exception ex)
            {
                ex.Should().BeOfType<ArgumentNullException>();
                ex.Message.Should().Be("Cannot invoke a null action (Parameter 'thenAction')");
            }
        }

        [TestMethod]
        public void TestThenActionNoServiceProvider()
        {
            var x = 0;

            whenClause.Then("my label", _ => x = 1);

            x.Should().Be(1);
        }

        [TestMethod]
        public void TestThenActionAndServiceProvider()
        {
            var x = "0";

            whenClause.Then("my label", svc => x = svc.GetService<string>());

            x.Should().Be("Hello world!");
        }
    }
}

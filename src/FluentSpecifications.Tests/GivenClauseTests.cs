namespace FluentSpecifications.Tests
{
    using FluentAssertions;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    [TestClass]
    public class GivenClauseTests
    {
        private readonly IGivenClause givenClause;
        private readonly IServiceCollection serviceCollection;

        public GivenClauseTests()
        {
            serviceCollection = new ServiceCollection().AddSingleton<string>("Hello world!");

            givenClause = new GivenClause(serviceCollection);
        }


        [TestMethod]
        public void TestGivenActionIsNull()
        {
            try
            {
                givenClause.And("my label", null);

                true.Should().BeFalse();
            }
            catch (Exception ex)
            {
                ex.Should().BeOfType<ArgumentNullException>();
                ex.Message.Should().Be("Cannot invoke a null action (Parameter 'givenAction')");
            }
        }

        [TestMethod]
        public void TestGivenActionNoServiceCollection()
        {
            var x = 0;

            givenClause.And("my label", _ => x = 1);

            x.Should().Be(1);
        }

        [TestMethod]
        public void TestGivenActionAndServiceCollection()
        {
            var x = 0;

            givenClause.And("my label", svc =>
            {
                svc.AddSingleton<string>("Another");
            });

            x.Should().Be(0);

            var svc = serviceCollection.BuildServiceProvider();

            var strings = svc.GetServices<string>();
            strings.Should().HaveCount(2);
        }

        [TestMethod]
        public void TestWhenActionIsNull()
        {
            try
            {
                givenClause.When("my label", null);

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

            givenClause.When("my label", _ => x = 1);

            x.Should().Be(1);
        }

        [TestMethod]
        public void TestWhenActionAndServiceProvider()
        {
            var x = "0";

            givenClause.When("my label", svc => x = svc.GetService<string>());

            x.Should().Be("Hello world!");
        }

        [TestMethod]
        public void TestThenActionIsNull()
        {
            try
            {
                givenClause.Then("my label", null);

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

            givenClause.Then("my label", _ => x = 1);

            x.Should().Be(1);
        }

        [TestMethod]
        public void TestThenActionAndServiceProvider()
        {
            var x = "0";

            givenClause.Then("my label", svc => x = svc.GetService<string>());

            x.Should().Be("Hello world!");
        }
    }
}

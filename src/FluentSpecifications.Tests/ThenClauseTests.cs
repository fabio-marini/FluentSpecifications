namespace FluentSpecifications.Tests
{
    using FluentAssertions;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    [TestClass]
    public class ThenClauseTests
    {
        private readonly IThenClause thenClause;
        private readonly IServiceProvider serviceProvider;

        public ThenClauseTests()
        {
            serviceProvider = new ServiceCollection().AddSingleton<string>("Hello world!").BuildServiceProvider();

            thenClause = new ThenClause(serviceProvider);
        }

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
        public void TestThenActionNoServiceProvider()
        {
            var x = 0;

            thenClause.And("my label", _ => x = 1);

            x.Should().Be(1);
        }

        [TestMethod]
        public void TestThenActionAndServiceProvider()
        {
            var x = "0";

            thenClause.And("my label", svc => x = svc.GetService<string>());

            x.Should().Be("Hello world!");
        }
    }
}

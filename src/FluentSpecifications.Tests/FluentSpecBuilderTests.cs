namespace FluentSpecifications.Tests
{
    using FluentAssertions;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    [TestClass]
    public class FluentSpecBuilderTests
    {
        private readonly FluentSpecBuilder fluentSpecBuilder;
        private readonly IServiceProvider serviceProvider;

        public FluentSpecBuilderTests()
        {
            serviceProvider = new ServiceCollection().AddSingleton<string>("Hello world!").BuildServiceProvider();

            fluentSpecBuilder = new FluentSpecBuilder(serviceProvider);
        }

        [TestMethod]
        public void TestGivenActionIsNull()
        {
            try
            {
                fluentSpecBuilder.Given("my label", null);

                true.Should().BeFalse();
            }
            catch (Exception ex)
            {
                ex.Should().BeOfType<ArgumentNullException>();
                ex.Message.Should().Be("Cannot invoke a null action (Parameter 'givenAction')");
            }
        }

        [TestMethod]
        public void TestGivenActionNoServiceProvider()
        {
            var x = 0;

            fluentSpecBuilder.Given("my label", _ => x = 1);

            x.Should().Be(1);
        }

        [TestMethod]
        public void TestGivenActionAndServiceProvider()
        {
            var x = "0";

            fluentSpecBuilder.Given("my label", svc => x = svc.GetService<string>());

            x.Should().Be("Hello world!");
        }

        [TestMethod]
        public void TestWhenActionIsNull()
        {
            try
            {
                fluentSpecBuilder.When("my label", null);

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

            fluentSpecBuilder.When("my label", _ => x = 1);

            x.Should().Be(1);
        }

        [TestMethod]
        public void TestWhenActionAndServiceProvider()
        {
            var x = "0";

            fluentSpecBuilder.When("my label", svc => x = svc.GetService<string>());

            x.Should().Be("Hello world!");
        }
    }
}

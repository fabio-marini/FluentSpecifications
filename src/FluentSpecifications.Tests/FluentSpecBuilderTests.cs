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
        private readonly IServiceCollection serviceCollection;

        public FluentSpecBuilderTests()
        {
            serviceCollection = new ServiceCollection().AddSingleton<string>("Hello world!");

            fluentSpecBuilder = new FluentSpecBuilder(serviceCollection);
        }

        [TestMethod]
        public void TestServiceCollectionIsNull()
        {
            var simpleSpecBuilder = new FluentSpecBuilder(default);

            var x = 0;

            simpleSpecBuilder.Given("my label", _ => x = 1).When("another", _ => x = 2);

            x.Should().Be(2);

            simpleSpecBuilder.Given("my label", _ => x = 1).When("another", svc => x = 3);

            x.Should().Be(3);

            simpleSpecBuilder.Given("my label", _ => x = 1).When("another", svc =>
            {
                var s = svc.GetService<string>();

                s.Should().BeNull();
            });
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
        public void TestGivenActionNoServiceCollection()
        {
            var x = 0;

            fluentSpecBuilder.Given("my label", _ => x = 1);

            x.Should().Be(1);
        }

        [TestMethod]
        public void TestGivenActionAndServiceCollection()
        {
            var x = 0;

            fluentSpecBuilder.Given("my label", svc =>
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

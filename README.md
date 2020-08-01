# FluentSpecifications
A simple fluent API for writing tests in the given/when/then format.

Access the API using the `FluentSpecBuilder` class and use the `Given`, `When` and `Then` methods to define your tests.

Each method accepts a free-text label description and an `Action` delegate, which represents the code that will be executed.

Each method has a corresponding overload that accepts a free-text label description and a `Func<Task>` delegate. These are used when the delegates are called asynchronously.

You can download the NuGet package from [NuGet.org](https://www.nuget.org/packages/FluentSpecifications/)

## Examples
```c#
int x = default, y = default, result = default;

new FluentSpecBuilder()

    .Given("The initial value of x is 1", () => x = 1)
      .And("The initial value of y is 3", () => y = 3)
     .When("I add x and y together", () => result = x + y)
     .Then("The result will be 4", () => result.Should().Be(4));
```
The same as above, but using async delegates:
```c#
int x = default, y = default, result = default;

new FluentSpecBuilder()

    .Given("The initial value of x is 1", async () => await Task.Run(() => x = 1))
      .And("The initial value of y is 3", async () => await Task.Run(() => y = 3))
     .When("I add x and y together", async () => await Task.Run(() => result = x + y))
     .Then("The result will be 4", async () => await Task.Run(() => result.Should().Be(4)));
```

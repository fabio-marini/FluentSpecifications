# FluentSpecifications
A simple fluent API for writing tests in the given/when/then format.

Access the API using the `FluentSpecBuilder` class and use the `Given`, `When` and `Then` methods to define a fluent specification.

Each method accepts a free-text label description and an `Action` delegate, which represents the code executed by the method.

## Example
```c#
int x = default, y = default, result = default;

new FluentSpecBuilder()

    .Given("The initial value of x is 1", () => x = 1)
      .And("The initial value of y is 3", () => y = 3)
     .When("I add x and y together", () => result = x + y)
     .Then("The result will be 4", () => result.Should().Be(4));
```

## Introduction

In this exercise you will be building error handling for a simple integer calculator. 

## The Challenge

The goal is to have a working calculator that can perform addition, subtraction, multiplication and division on integers.

The calculator will be implemented as a static method `Calculate` on the class `SimpleCalculator`. 

The `Calculate` method can take three parameters - the first number, second number, and a `char` specifying which arithmetic operation to perform.

The output will be a string with the following pattern: `{first number} {operator} {second number} = {result}

```

SimpleCalculator.Calculate(16, 51, "+"); // => returns "16 + 51 = 67"

SimpleCalculator.Calculate(16, 51, "-"); // => returns "16 - 51 = -39"

SimpleCalculator.Calculate(32, 6, "*"); // => returns "32 * 6 = 192"

SimpleCalculator.Calculate(512, 4, "/"); // => returns "512 / 4 = 128"

```

Note that for division the result should be the integer quotient.

There are three tasks

### Implement the calculator operations

The main method for implementation in this task will be the (static) `SimpleCalculator.Calculate()` method. It implements four operations.

* addition using the `+` character
* addition using the `-` character
* multiplication using the `*` character
* division using the `/` character

You can demonstrate your success by creating a console application that accepts three arguments (first number, second number and operator)
and then invokes `SimpleCalculator.Calculate()`. The result is then printed to the console.

### Handle illegal operations

Any other operation symbol should throw the `ArgumentOutOfRangeException` exception. If the operation argument is an empty string, then the method should throw the `ArgumentException` exception. When null is provided as an operation argument, then the method should throw the `ArgumentNullException` exception.

```
SimpleCalculator.Calculate(100, 10, "-"); // => throws ArgumentOutOfRangeException

SimpleCalculator.Calculate(8, 2, ""); // => throws ArgumentException

SimpleCalculator.Calculate(58, 6, null); // => throws ArgumentNullException
```

If an exception is thrown then print its type to the console.

### Handle errors when dividing by zero

When attempting to divide by `0`, the calculator should return a string with the content `Division by zero is not allowed`. Any other exception should not be handled by the `SimpleCalculator.Calculate()` method.

```
SimpleCalculator.Calculate(512, 0, "/"); // => returns "Division by zero is not allowed."
```

## Useful Links

[Exceptions and Exception Handling](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/exceptions/)

[Best practices for exceptions](https://learn.microsoft.com/en-us/dotnet/standard/exceptions/best-practices-for-exceptions)

[Object.GetType Method](https://learn.microsoft.com/en-us/dotnet/api/system.object.gettype?view=net-8.0)
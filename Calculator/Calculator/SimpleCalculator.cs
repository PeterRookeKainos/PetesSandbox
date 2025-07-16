namespace Calculator;

public static class SimpleCalculator
{
    // create a static method called Calculate that takes two integers and a char as parameters
    // the method should return an integer
    // the char can be '+', '-', '*', or '/'
    public static int Calculate(int a, int b, char operation)
    {
        return operation switch
        {
            '+' => a + b,
            '-' => a - b,
            '*' => a * b,
            '/' => b != 0 ? a / b : throw new DivideByZeroException("Cannot divide by zero."),
            _ => throw new InvalidOperationException("Invalid operation.")
        };
    }
}


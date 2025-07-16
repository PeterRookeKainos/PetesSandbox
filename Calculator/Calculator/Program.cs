// See https://aka.ms/new-console-template for more information

using Calculator;

int add = SimpleCalculator.Calculate(16, 51, '+'); // Output: 67
Console.WriteLine(add);

int subtract = SimpleCalculator.Calculate(16, 51, '-'); // Output: -35
Console.WriteLine(subtract);

int multiply = SimpleCalculator.Calculate(32, 6, '*'); // Output: 192
Console.WriteLine(multiply);

int divide = SimpleCalculator.Calculate(512, 4, '/'); // Output: 128
Console.WriteLine(divide);


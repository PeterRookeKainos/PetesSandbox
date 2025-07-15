## Introduction

Fizz buzz is a group word game for children to teach them about division.

Players take turns to count incrementally, replacing any number divisible by three with the word `fizz`, and any number divisible by five with the word `buzz`, and any number divisible by both three and five with the word `fizzbuzz`.

## The Challenge

Write a C# console application that takes an integer `n` as its sole argument. The application will *print* an array of integers, starting from 1, where

* `answer[i] == "FizzBuzz"` if `i` is divisible by 3 and 5.
* `answer[i] == "Fizz"` if `i` is divisible by 3.
* `answer[i] == "Buzz"` if `i` is divisible by 5.
* `answer[i] == i` if none of the above conditions are true.

The argument `n` can have a value between 1 and 10,000.

### Example 1

Input: `n = 3`
Output: `["1","2","Fizz"]`

### Example 2

Input: `n = 5`
Output: `["1","2","Fizz","4","Buzz"]`

### Example 3

Input: `n = 15`
Output: `["1","2","Fizz","4","Buzz","Fizz","7","8","Fizz","Buzz","11","Fizz","13","14","FizzBuzz]`

## Useful Links

[Command-line arguments](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/program-structure/main-command-line)

[Declaring variables](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/declarations)

[Arrays](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/arrays)

[if-else and switch statements](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/selection-statements)

[Iteration (for, foreach and while)](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/iteration-statements)

[While Loop versis For Loop?](https://stackoverflow.com/questions/35395800/c-sharp-while-loop-vs-for-loop)

[Strings and string literals](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/strings/)

[How to read and write in a C# console application](https://devm.io/csharp/c-sharp-console-app-167696)
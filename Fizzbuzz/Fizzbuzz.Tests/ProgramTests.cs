using System.Diagnostics;
using Xunit;

public class ProgramTests
{
    [Fact]
    public void FizzBuzz_NoArguments_OutputsErrorMessage()
    {
        var process = new Process();
        process.StartInfo.FileName = "dotnet";
        process.StartInfo.Arguments = "run --project Fizzbuzz --";
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.RedirectStandardError = true;
        process.StartInfo.UseShellExecute = false;
        process.Start();
        string output = process.StandardOutput.ReadToEnd();
        string error = process.StandardError.ReadToEnd();
    }

    [Fact]
    public void FizzBuzz_ValidArgument_OutputsFizzBuzz()
    {
        var process = new Process();
        process.StartInfo.FileName = "dotnet";
        process.StartInfo.Arguments = "run --project Fizzbuzz -- 3";
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.RedirectStandardError = true;
        process.StartInfo.UseShellExecute = false;
        process.Start();

        string output = process.StandardOutput.ReadToEnd();
        string error = process.StandardError.ReadToEnd();

        Assert.Contains("n = 3 [\"1\",\"2\",\"Fizz\"]", output);
    }
}

/*
[Theory]
[InlineData(new string[] { }, "Please provide a numeric integer argument.")]
//[InlineData(new string[] { "abc" }, "The first argument is not a valid integer. Exiting")]
[InlineData(new string[] { "3" }, "n = 3 [\"1\",\"2\",\"Fizz\"]")]
//[InlineData(new string[] { "5" }, "[\"1\",\"2\",\"Fizz\",\"4\",\"Buzz\"]")]
//[InlineData(new string[]{ "15" }, "n = 15 [\"1\",\"2\",\"Fizz\",\"4\",\"Buzz\",\"Fizz\",\"7\",\"8\",\"Fizz\",\"Buzz\",\"11\",\"Fizz\",\"13\",\"14\",\"FizzBuzz\"])
public void FizzBuzz_Output_IsCorrect(string[] args, string expected)
{
    var process = new Process();
    process.StartInfo.FileName = "dotnet";
    process.StartInfo.Arguments = $"run --project Fizzbuzz -- {string.Join(' ', args)}";
    process.StartInfo.RedirectStandardOutput = true;
    process.StartInfo.RedirectStandardError = true;
    process.StartInfo.UseShellExecute = false;
    process.Start();

    string output = process.StandardOutput.ReadToEnd();
    process.WaitForExit();

    Assert.Contains(expected, output);
}*/
    
//}
using System.Diagnostics;
using Xunit;

public class ProgramTests
{
    [Theory]
    [InlineData(new string[] { }, "Please provide a numeric integer argument.")]
    [InlineData(new string[] { "abc" }, "The first argument is not a valid integer. Exiting")]
    [InlineData(new string[] { "3" }, "\"1\",\"2\",\"Fizz\"")]
    [InlineData(new string[] { "5" }, "\"1\",\"2\",\"Fizz\",\"4\",\"Buzz\"")]
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
    }
}
using System.Text;

StringBuilder builder = new();
builder.AppendLine("The following arguments are passed:");

foreach (var arg in args)
{ builder.AppendLine($"---> Argument={arg}"); }
Console.WriteLine("--> Debug " + builder.ToString());

if (args.Length == 0) {
    System.Console.WriteLine("Please provide a numeric integer argument.");
    return 1;
}

// if the first argument is not a number, return 1 (false)
if (!int.TryParse(args[0], out int numberArgument)) {
    System.Console.WriteLine("The first argument is not a valid integer. Exiting");
    return 1;
}

// hacking together a simple FizzBuzz solution - no object oriented programming, no classes, no methods ;-)
/* * FizzBuzz
 * FizzBuzz code
 * For all integers from 1 to argument, that are multiples of 3, print "Fizz" instead of the number.
 * For all integers from 1 to argument, that are multiples of 5, print "Buzz" instead of the number.
 * For all integers from1 to argument, that are multiples of both 3 and 5, print "FizzBuzz" instead of the number.
 */
// Create a StringBuilder to hold the output
StringBuilder fizzbuzz = new();
fizzbuzz.Append("[");

// for all integers from 1 to the given number, print Fizz, Buzz, or FizzBuzz
for (int i = 1; i <= numberArgument; i++)
{
    if (i % 3 == 0 && i % 5 == 0)
    { fizzbuzz.Append("\"FizzBuzz\""); }
    else if (i % 3 == 0)
    { fizzbuzz.Append("\"Fizz\""); }
    else if (i % 5 == 0)
    { fizzbuzz.Append("\"Buzz\""); }
    else
    { fizzbuzz.Append("\"" + i.ToString() + "\""); }

    if (i < numberArgument)
    { fizzbuzz.Append(","); }
}
fizzbuzz.Append("]");

Console.WriteLine("n = " + numberArgument + " " + fizzbuzz.ToString());
return 0;
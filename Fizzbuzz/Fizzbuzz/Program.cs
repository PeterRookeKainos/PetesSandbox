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

// hacking together a simple FizzBuzz solution - no object oriented programming, no classes, no methods ;-)
/* * FizzBuzz
 * FizzBuzz code
 * For all integers that are multiples of 3, print "Fizz" instead of the number.
 * For all integers that are multiples of 5, print "Buzz" instead of the number.
 * For all integers that are multiples of both 3 and 5, print "FizzBuzz" instead of the number.
 */
StringBuilder fizzbuzz = new();

// if the first argument is not a number, return 1 (false)
if (!int.TryParse(args[1], out int number)) {
    System.Console.WriteLine("The first argument is not a valid integer. Exiting");
    return 1;
}
var i = int.Parse(args[1]);

if (i % 3 == 0 && i % 5 == 0) { fizzbuzz.AppendLine("FizzBuzz"); }
else if (i % 3 == 0) { fizzbuzz.AppendLine("Fizz"); }
else if (i % 5 == 0) { fizzbuzz.AppendLine("Buzz"); }
else {   fizzbuzz.AppendLine(i.ToString()); }

Console.WriteLine(fizzbuzz.ToString());

return 0;
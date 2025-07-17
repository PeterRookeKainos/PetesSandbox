namespace Asynchronous;

/*
 * Code to demonstrate how to make breakfast in a synchronous way.
 * An example of how to write synchronous code.
 */

// Code lifted from the microsoft docs (https://learn.microsoft.com/en-us/dotnet/csharp/asynchronous-programming/) 
// with some modifications ;-) 

using System;
using System.Threading.Tasks;

internal class HashBrown { }
internal class Coffee { }
internal class Egg { }
internal class Juice { }
internal class Toast { }

public class Breakfast
{
    public void MakeBreakfast() 
    {
        Coffee cup = PourCoffee();
        Console.WriteLine("7--> Coffee is ready");

        Egg eggs = FryEggs(2);
        Console.WriteLine("6--> eggs are ready");

        HashBrown hashBrown = FryHashBrowns(3);
        Console.WriteLine("5--> hash browns are ready");

        Toast toast = ToastBread(2);
        ApplyButter(toast);
        ApplyJam(toast);
        Console.WriteLine("4--> toast is ready");

        Juice oj = PourOJ();
        Console.WriteLine("1--> oj is ready");
        Console.WriteLine("*--> Breakfast is ready!");
    }
    
    private static Juice PourOJ()
    {
        Console.WriteLine("1--> Pouring orange juice");
        return new Juice();
    }

    private static void ApplyJam(Toast toast) =>
        Console.WriteLine("2--> Putting jam on the toast");

    private static void ApplyButter(Toast toast) =>
        Console.WriteLine("3--> Putting butter on the toast");

    private static Toast ToastBread(int slices)
    {
        for (int slice = 0; slice < slices; slice++)
        {
            Console.WriteLine("4--> Putting a slice of bread in the toaster");
        }
        Console.WriteLine("4.1--> Start toasting...");
        Task.Delay(1000).Wait();
        Console.WriteLine("4.2--> Remove toast from toaster");

        return new Toast();
    }

    private static HashBrown FryHashBrowns(int patties)
    {
        Console.WriteLine($"5--> Putting {patties} hash brown patties in the pan");
        Console.WriteLine("5.1--> Cooking first side of hash browns...");
        Task.Delay(1000).Wait();
        for (int patty = 0; patty < patties; patty++)
        {
            Console.WriteLine("5.2--> Flipping a hash brown patty");
        }
        Console.WriteLine("5.3--> Cooking the second side of hash browns...");
        Task.Delay(3000).Wait();
        Console.WriteLine("5.4--> Put hash browns on plate");

        return new HashBrown();
    }

    private static Egg FryEggs(int howMany)
    {
        Console.WriteLine("6--> Warming the egg pan...");
        Task.Delay(1000).Wait();
        Console.WriteLine($"6.1--> Cracking {howMany} eggs");
        Console.WriteLine("6.2--> Cooking the eggs ...");
        Task.Delay(1000).Wait();
        Console.WriteLine("6.3--> Put eggs on plate");

        return new Egg();
    }

    private static Coffee PourCoffee()
    {
        Console.WriteLine("7--> Pouring coffee");
        return new Coffee();
    }
}
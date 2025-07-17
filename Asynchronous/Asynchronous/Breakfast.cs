namespace Asynchronous;

/*
 * Code to demonstrate how to make breakfast in a synchronous way.
 * An example of how to write synchronous code.
 */

/* Code lifted from the Microsoft docs (https://learn.microsoft.com/en-us/dotnet/csharp/asynchronous-programming/)
   with some modifications ;-)
*/ 

using System;
using System.Threading.Tasks;

public class Breakfast
{
    const int DELAY = 2000; 
    
    public void MakeBreakfast() 
    {
        Coffee cup = PourCoffee();
        Console.WriteLine("1--> Coffee is ready");

        Egg eggs = FryEggs(2);
        Console.WriteLine("2--> Eggs are ready");

        HashBrown hashBrown = FryHashBrowns(3);
        Console.WriteLine("3--> Hash browns are ready");

        Toast toast = ToastBread(2);
        ApplyButter(toast);
        ApplyJam(toast);
        Console.WriteLine("4--> Toast is ready");

        Juice oj = PourOJ();
        Console.WriteLine("5--> Orange juice is ready");
        Console.WriteLine("*--> Breakfast is ready!");
    }
    
    private static Juice PourOJ()
    {
        Console.WriteLine("5.1--> Pouring orange juice");
        return new Juice();
    }

    private static void ApplyJam(Toast toast) =>
        Console.WriteLine("4.5--> Putting jam on the toast");

    private static void ApplyButter(Toast toast) =>
        Console.WriteLine("4.4--> Putting butter on the toast");

    private static Toast ToastBread(int slices)
    {
        for (int slice = 0; slice < slices; slice++)
        {
            Console.WriteLine("4.1--> Putting a slice of bread in the toaster");
        }
        Console.WriteLine("4.2--> Start toasting...");
        Task.Delay(DELAY).Wait();
        Console.WriteLine("4.3--> Remove toast from toaster");

        return new Toast();
    }

    private static HashBrown FryHashBrowns(int patties)
    {
        Console.WriteLine($"3.1--> Putting {patties} hash brown patties in the pan");
        Console.WriteLine("3.2--> Cooking first side of hash browns...");
        Task.Delay(DELAY).Wait();
        for (int patty = 0; patty < patties; patty++)
        {
            Console.WriteLine("3.3--> Flipping a hash brown patty");
        }
        Console.WriteLine("3.4--> Cooking the second side of hash browns...");
        Task.Delay(DELAY).Wait();
        Console.WriteLine("3.5--> Put hash browns on plate");

        return new HashBrown();
    }

    private static Egg FryEggs(int howMany)
    {
        Console.WriteLine("2.1--> Warming the egg pan...");
        Task.Delay(DELAY).Wait();
        Console.WriteLine($"2.2--> Cracking {howMany} eggs");
        Console.WriteLine("2.3--> Cooking the eggs ...");
        Task.Delay(DELAY).Wait();
        Console.WriteLine("2.4--> Put eggs on plate");

        return new Egg();
    }

    private static Coffee PourCoffee()
    {
        Console.WriteLine("1.1--> Pouring coffee");
        return new Coffee();
    }
}
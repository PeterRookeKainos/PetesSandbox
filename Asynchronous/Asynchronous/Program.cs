using AsyncBreakfast;
using Asynchronous;

internal class HashBrown { }
internal class Coffee { }
internal class Egg { }
internal class Juice { }
internal class Toast { }

public class Program
{
    public static void Main(string[] args)
    {
        const String NORMAL = "\x1b[0m";
        const String BOLD_ON = "\x1b[1m";
        const String UNDERLINE_ON = "\x1b[4m";
        
        Console.WriteLine("----------------------------------");
        Console.WriteLine($"->{BOLD_ON} Breakfast Cooked Synchronously{NORMAL}");
        Console.WriteLine("----------------------------------");
        Breakfast breakfast = new Breakfast();
        DateTime startTime = DateTime.Now;
        breakfast.MakeBreakfast();
        DateTime endTime = DateTime.Now;
        
        TimeSpan totalTime = endTime - startTime;
        Console.WriteLine($"{UNDERLINE_ON} > Total time taken: {totalTime.TotalSeconds} seconds{NORMAL}");
        
        Console.WriteLine();
        Console.WriteLine("----------------------------------");
        Console.WriteLine($"->{BOLD_ON} Breakfast Cooked Asynchronously{NORMAL}");
        Console.WriteLine("----------------------------------");
        BreakfastAsync breakfastAsync = new BreakfastAsync();
        startTime = DateTime.Now;
        Task.Run(() => breakfastAsync.MakeBreakfast()).GetAwaiter().GetResult();
        endTime = DateTime.Now;
        
        totalTime = endTime - startTime;
        Console.WriteLine($"->{UNDERLINE_ON} Total time taken: {totalTime.TotalSeconds} seconds{NORMAL}");
    }
}




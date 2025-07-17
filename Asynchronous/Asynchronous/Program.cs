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
        Breakfast breakfast = new Breakfast();
        breakfast.MakeBreakfast();
        
        BreakfastAsync breakfastAsync = new BreakfastAsync();
        Task.Run(() => breakfastAsync.MakeBreakfast()).GetAwaiter().GetResult();
    }
}




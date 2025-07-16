// 
using Twitcher;

Console.WriteLine("Last week's birds: " + Bird.LastWeek().ToString());

//ugly ???
Console.Write("Last week's birds: ");
foreach (var bird in Bird.LastWeek()) { Console.Write(bird + ","); }

Console.WriteLine("\nToday birds: " + Bird.Today());

Bird.IncrementToday();
Console.WriteLine("Today birds after increment: " + Bird.Today());

Console.WriteLine("Has any day without birds: " + Bird.HasDayWithoutBirds());

Console.WriteLine("Number of birds up to day 3: " + Bird.CountOfBirdsUpToday(3));
Console.WriteLine("Number of birds up to day 6: " + Bird.CountOfBirdsUpToday(6));

Console.WriteLine("Number of busy days: " + Bird.BusyDays(Bird.LastWeek()));










 
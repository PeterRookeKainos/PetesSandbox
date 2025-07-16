namespace Twitcher;

// Bird static class - has overloaded methods (as I didn't realise what was to be done at first)
// - methods that work on the internal array _birds
// - methods that take an int[] array as an argument (what was asked for!)

public static class Bird
{
    static int[] _birds = [0, 2, 5, 3, 7, 8, 4];
    static Bird() { }
    
    public static int[] Birds => _birds;

    public static int[] LastWeek() => _birds;
    public static int Today() => _birds[^1];
   
    // increment the last bird count
    public static void IncrementToday() 
    { _birds[^1]++; }
    
    public static int[] IncrementToday(int[] birds)
    {
        if (birds == null || birds.Length == 0)
            throw new ArgumentException("Birds array cannot be null or empty.", nameof(birds));
        
        birds[^1]++;
        return birds;
    }   
    
    public static bool HasDayWithoutBirds() 
    { return _birds.Any(b => b == 0); }

    public static bool HasDayWithoutBirds(int[] birds)
    {
        if (birds == null || birds.Length == 0)
            throw new ArgumentException("Birds array cannot be null or empty.", nameof(birds));
        
        return birds.Any(b => b == 0);
    }
    
    public static int CountOfBirdsUpToday(int day)
    {
        if (day < 0 || day >= _birds.Length)
            throw new ArgumentOutOfRangeException(nameof(day), "Day must be within the range of recorded days.");
        
        return _birds.Take(day).Sum();
    }
    
    public static int CountOfBirdsUpToday(int day, int[] birds)
    {
        if (day < 0 || day >= birds.Length)
            throw new ArgumentOutOfRangeException(nameof(day), "Day must be within the range of recorded days.");
        
        return birds.Take(day).Sum();
    }
    
    public static int BusyDays()
    {
        //return _birds.Count(b => b > 0);
        var busyDaysQuery = from bird in _birds
            where bird > 5
            select bird;
        return busyDaysQuery.Count();
        
    }
    public static int BusyDays(int[] birds)
    {
        if (birds == null || birds.Length == 0)
            throw new ArgumentException("Birds array cannot be null or empty.", nameof(birds));
        
        //return birds.Count(b => b > 0);
        var busyDaysQuery = from bird in birds
                            where bird > 5
                            select bird;
        return busyDaysQuery.Count();
    }
}
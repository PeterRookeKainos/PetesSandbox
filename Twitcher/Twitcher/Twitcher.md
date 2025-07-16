## Introduction

You're an avid bird watcher that keeps track of how many birds have visited your garden in the last seven days.

## The Challenge

You have six tasks, all dealing with the numbers of birds that visited your garden. 

### 1. Check what the counts were last week

For comparison purposes, you always keep a copy of last week's counts nearby, which were: 0, 2, 5, 3, 7, 8 and 4. Implement the (static) `BirdCount.LastWeek()` method that returns last week's counts:

```
BirdCount.LastWeek();
// => [0, 2, 5, 3, 7, 8, 4]
```

### 2. Check how many birds visited today
 
Implement the `BirdCount.Today()` method to return how many birds visited your garden today. The bird counts are ordered by day, with the first element being the count of the oldest day, and the last element being today's count.

```
int[] birdsPerDay = { 2, 5, 0, 7, 4, 1 };
var birdCount = new BirdCount(birdsPerDay);
birdCount.Today();
// => 1
```

### 3. Increment today's count

Implement the `BirdCount.IncrementTodaysCount()` method to increment today's count:

```
int[] birdsPerDay = { 2, 5, 0, 7, 4, 1 };
var birdCount = new BirdCount(birdsPerDay);
birdCount.IncrementTodaysCount();
birdCount.Today();
// => 2
```

### 4. Check if there was a day with no visiting birds

Implement the `BirdCount.HasDayWithoutBirds()` method that returns `true` if there was a day at which zero birds visited the garden; otherwise, return `false`:

```
int[] birdsPerDay = { 2, 5, 0, 7, 4, 1 };
var birdCount = new BirdCount(birdsPerDay);
birdCount.HasDayWithoutBirds();
// => true
```

Try implementing this with a LINQ query.

### 5. Calculate the number of visiting birds for the first number of days

Implement the `BirdCount.CountForFirstDays()` method that returns the number of birds that have visited your garden from the start of the week, but limit the count to the specified number of days from the start of the week.

```
int[] birdsPerDay = { 2, 5, 0, 7, 4, 1 };
var birdCount = new BirdCount(birdsPerDay);
birdCount.CountForFirstDays(4);
// => 14
```

Try implementing this with a LINQ query.

### 6. Calculate the number of busy days

Some days are busier that others. A busy day is one where five or more birds have visited your garden. Implement the `BirdCount.BusyDays()` method to return the number of busy days:

```
int[] birdsPerDay = { 2, 5, 0, 7, 4, 1 };
var birdCount = new BirdCount(birdsPerDay);
birdCount.BusyDays();
// => 2
```

Try implementing this with a LINQ query.

## Useful Links

[Arrays](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/arrays)

[What is a static method in C#?](https://stackoverflow.com/questions/4124102/whats-a-static-method-in-c)

[Static Classes and Static Class Members](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/static-classes-and-static-class-members)

[Lambda expressions and anonymous functions](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-expressions)

[Introduction to LINQ Queries in C#](https://learn.microsoft.com/en-us/dotnet/csharp/linq/get-started/introduction-to-linq-queries)
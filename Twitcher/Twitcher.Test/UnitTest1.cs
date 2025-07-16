namespace Twitcher.Test;

using System;
using Xunit;
using Twitcher;

public class BirdTests
{
    [Fact]
    public void LastWeek_ReturnsInitialArray()
    {
        var result = Bird.LastWeek();
        Assert.Equal(new[] { 0, 2, 5, 3, 7, 8, 4 }, result);
    }

    [Fact]
    public void Today_ReturnsLastElement()
    {
        Assert.Equal(4, Bird.Today());
    }

    [Fact]
    public void IncrementToday_IncrementsLastElement()
    {
        int before = Bird.Today();
        Bird.IncrementToday();
        Assert.Equal(before + 1, Bird.Today());
    }

    [Fact]
    public void IncrementToday_WithArray_IncrementsLastElement()
    {
        int[] birds = { 1, 2, 3 };
        var result = Bird.IncrementToday(birds);
        Assert.Equal(4, result[^1]);
    }

    [Fact]
    public void HasDayWithoutBirds_ReturnsTrueIfZeroExists()
    {
        Assert.True(Bird.HasDayWithoutBirds());
    }

    [Fact]
    public void HasDayWithoutBirds_WithArray_ReturnsFalseIfNoZero()
    {
        int[] birds = { 1, 2, 3 };
        Assert.False(Bird.HasDayWithoutBirds(birds));
    }

    [Fact]
    public void CountOfBirdsUpToday_ReturnsSumUpToDay()
    {
        Assert.Equal(0 + 2 + 5, Bird.CountOfBirdsUpToday(3));
    }

    [Fact]
    public void CountOfBirdsUpToday_WithArray_ReturnsSumUpToDay()
    {
        int[] birds = { 1, 2, 3, 4 };
        Assert.Equal(1 + 2, Bird.CountOfBirdsUpToday(2, birds));
    }

    [Fact]
    public void BusyDays_ReturnsCountOfDaysWithMoreThanFiveBirds()
    {
        Assert.Equal(2, Bird.BusyDays());
    }

    [Fact]
    public void BusyDays_WithArray_ReturnsCountOfDaysWithMoreThanFiveBirds()
    {
        int[] birds = { 6, 7, 2, 0 };
        Assert.Equal(2, Bird.BusyDays(birds));
    }

    [Fact]
    public void IncrementToday_ThrowsOnNullOrEmpty()
    {
        Assert.Throws<ArgumentException>(() => Bird.IncrementToday(null));
        Assert.Throws<ArgumentException>(() => Bird.IncrementToday(Array.Empty<int>()));
    }

    [Fact]
    public void HasDayWithoutBirds_ThrowsOnNullOrEmpty()
    {
        Assert.Throws<ArgumentException>(() => Bird.HasDayWithoutBirds(null));
        Assert.Throws<ArgumentException>(() => Bird.HasDayWithoutBirds(Array.Empty<int>()));
    }

    [Fact]
    public void CountOfBirdsUpToday_ThrowsOnInvalidDay()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => Bird.CountOfBirdsUpToday(-1));
        Assert.Throws<ArgumentOutOfRangeException>(() => Bird.CountOfBirdsUpToday(100));
    }

    [Fact]
    public void CountOfBirdsUpToday_WithArray_ThrowsOnInvalidDay()
    {
        int[] birds = { 1, 2, 3 };
        Assert.Throws<ArgumentOutOfRangeException>(() => Bird.CountOfBirdsUpToday(-1, birds));
        Assert.Throws<ArgumentOutOfRangeException>(() => Bird.CountOfBirdsUpToday(10, birds));
    }
}
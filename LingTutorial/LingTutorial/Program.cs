using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    // This program generates a standard deck of cards using LINQ.
    // It uses two nested from clauses to create combinations of suits and ranks.

    static IEnumerable<string> Suits()
    {
        yield return "clubs";
        yield return "diamonds";
        yield return "hearts";
        yield return "spades";
    }

    static IEnumerable<string> Ranks()
    {
        yield return "two";
        yield return "three";
        yield return "four";
        yield return "five";
        yield return "six";
        yield return "seven";
        yield return "eight";
        yield return "nine";
        yield return "ten";
        yield return "jack";
        yield return "queen";
        yield return "king";
        yield return "ace";
    }
    
    static void Main(string[] args)
    {
        var startingDeck = 
            from s in Suits()
            from r in Ranks()
            select new { Suit = s, Rank = r };

        // Display each card that we've generated and placed in startingDeck in the console
        foreach (var card in startingDeck)
        {
            Console.WriteLine(card);
        }
    }
}
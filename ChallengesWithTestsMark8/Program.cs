using System;
using System.Collections.Generic;

namespace ChallengesWithTestsMark8;

internal static class Program
{
    private static void Main()
    {
        var challenges = new ChallengesSet06();
        Console.WriteLine("Weekly Challenges | Set 06 modernization");
        Console.WriteLine($"Contains ALPHA (ignore case): {challenges.CollectionContainsWord(new[] { "alpha", "bravo" }, "ALPHA", true)}");
        Console.WriteLine($"100140049 is prime: {challenges.IsPrimeNumber(100140049)}");
        Console.WriteLine($"Last unique index in aabbc: {challenges.IndexOfLastUniqueLetter("aabbc")}");
        Console.WriteLine($"Longest run in [1, 3, 3, 3, 2]: {challenges.MaxConsecutiveCount(new[] { 1, 3, 3, 3, 2 })}");
        Console.WriteLine($"Every third value: {string.Join(", ", challenges.GetEveryNthElement(new List<double> { 1, 2, 3, 4, 5, 6 }, 3))}");
    }
}

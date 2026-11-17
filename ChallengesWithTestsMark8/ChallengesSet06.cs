#nullable enable
using System;
using System.Collections.Generic;

namespace ChallengesWithTestsMark8;

/// <summary>Small algorithms with explicit edge-case and comparison contracts.</summary>
public class ChallengesSet06
{
    /// <summary>Matches whole values ordinally; null sources, targets and entries never match.</summary>
    public bool CollectionContainsWord(IEnumerable<string?>? words, string? word, bool ignoreCase)
    {
        if (words is null || word is null)
            return false;

        var comparison = ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;
        foreach (var candidate in words)
        {
            if (string.Equals(candidate, word, comparison))
                return true;
        }
        return false;
    }

    /// <summary>Tests primality over the entire Int32 range.</summary>
    public bool IsPrimeNumber(int num)
    {
        if (num < 2)
            return false;
        if (num % 2 == 0)
            return num == 2;

        // Division avoids overflowing divisor * divisor near Int32.MaxValue.
        for (int divisor = 3; divisor <= num / divisor; divisor += 2)
        {
            if (num % divisor == 0)
                return false;
        }
        return true;
    }

    /// <summary>Returns the last unique UTF-16 code-unit index, or -1. Case-sensitive.</summary>
    public int IndexOfLastUniqueLetter(string str)
    {
        ArgumentNullException.ThrowIfNull(str);
        var counts = new Dictionary<char, int>();
        foreach (char character in str)
        {
            counts.TryGetValue(character, out int count);
            counts[character] = count + 1;
        }
        for (int index = str.Length - 1; index >= 0; index--)
        {
            if (counts[str[index]] == 1)
                return index;
        }
        return -1;
    }

    /// <summary>Returns the longest adjacent run of equal values; an empty array returns zero.</summary>
    public int MaxConsecutiveCount(int[] numbers)
    {
        ArgumentNullException.ThrowIfNull(numbers);
        if (numbers.Length == 0)
            return 0;

        int longest = 1;
        int current = 1;
        for (int index = 1; index < numbers.Length; index++)
        {
            current = numbers[index] == numbers[index - 1] ? current + 1 : 1;
            longest = Math.Max(longest, current);
        }
        return longest;
    }

    /// <summary>Selects positions n, 2n, ...; null input or nonpositive n returns an empty array.</summary>
    public double[] GetEveryNthElement(List<double>? elements, int n)
    {
        if (elements is null || n < 1)
            return Array.Empty<double>();

        var result = new double[elements.Count / n];
        for (int index = 0; index < result.Length; index++)
            result[index] = elements[(index + 1) * n - 1];
        return result;
    }
}

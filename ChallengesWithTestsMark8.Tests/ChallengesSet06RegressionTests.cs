#nullable enable
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Xunit;

namespace ChallengesWithTestsMark8.Tests;

public class ChallengesSet06RegressionTests
{
    private readonly ChallengesSet06 challenges = new();

    [Theory]
    [InlineData(100140049, false)] // 10007 squared; beyond the original fixed divisor limit.
    [InlineData(int.MaxValue, true)]
    [InlineData(int.MinValue, false)]
    [InlineData(49, false)]
    public void PrimalityHandlesLargeValuesAndSquareBoundaries(int number, bool expected)
        => Assert.Equal(expected, challenges.IsPrimeNumber(number));

    [Fact]
    public void PrimalityAgreesWithTrialDivisionForSmallIntegers()
    {
        for (int number = -10; number <= 500; number++)
        {
            bool expected = number >= 2 && !Enumerable.Range(2, Math.Max(0, number - 2))
                .Any(divisor => number % divisor == 0);
            Assert.Equal(expected, challenges.IsPrimeNumber(number));
        }
    }

    [Theory]
    [InlineData(new int[] { }, 0)]
    [InlineData(new[] { 7 }, 1)]
    [InlineData(new[] { 1, 2, 3 }, 1)]
    [InlineData(new[] { 2, 2, 2 }, 3)]
    [InlineData(new[] { 1, 2, 2, 2 }, 3)]
    public void RunsHandleEmptySingletonAndFinalRuns(int[] numbers, int expected)
        => Assert.Equal(expected, challenges.MaxConsecutiveCount(numbers));

    [Fact]
    public void RunsDoNotCombineSeparatedValuesOrMutateInput()
    {
        int[] values = { 2, 2, 1, 2, 2 };
        int[] original = (int[])values.Clone();
        Assert.Equal(2, challenges.MaxConsecutiveCount(values));
        Assert.Equal(original, values);
    }

    [Fact]
    public void RequiredInputsReportTheirParameterNames()
    {
        Assert.Equal("numbers", Assert.Throws<ArgumentNullException>(() => challenges.MaxConsecutiveCount(null!)).ParamName);
        Assert.Equal("str", Assert.Throws<ArgumentNullException>(() => challenges.IndexOfLastUniqueLetter(null!)).ParamName);
    }

    [Theory]
    [InlineData("aA", 1)]
    [InlineData("a a", 1)]
    [InlineData("ééx", 2)]
    [InlineData("😀a😀", 2)] // Contract is UTF-16 indices, not grapheme indices.
    public void UniqueIndexPreservesCaseAndUtf16Semantics(string value, int expected)
        => Assert.Equal(expected, challenges.IndexOfLastUniqueLetter(value));

    [Fact]
    public void WordSearchIsIndependentOfTurkishCulture()
    {
        var original = CultureInfo.CurrentCulture;
        try
        {
            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("tr-TR");
            Assert.True(challenges.CollectionContainsWord(new[] { "FILE" }, "file", true));
            Assert.False(challenges.CollectionContainsWord(new[] { "FILE" }, "file", false));
        }
        finally
        {
            CultureInfo.CurrentCulture = original;
        }
    }

    [Fact]
    public void WordSearchEnumeratesOnceAndStopsAtTheMatch()
        => Assert.True(challenges.CollectionContainsWord(new SingleUseWords(), "target", false));

    [Fact]
    public void WordSearchExhaustsAnUnmatchedSingleUseSequenceOnce()
    {
        int enumerations = 0;
        IEnumerable<string> Words()
        {
            if (++enumerations > 1)
                throw new InvalidOperationException("Second enumeration");
            yield return "other";
        }
        Assert.False(challenges.CollectionContainsWord(Words(), "target", true));
        Assert.Equal(1, enumerations);
    }

    [Fact]
    public void WordSearchHandlesNullsEmptyStringsAndWholeValueMatching()
    {
        Assert.False(challenges.CollectionContainsWord(null, "word", true));
        Assert.False(challenges.CollectionContainsWord(new string?[] { null, "word" }, null, true));
        Assert.True(challenges.CollectionContainsWord(new string?[] { null, "" }, "", false));
        Assert.False(challenges.CollectionContainsWord(new[] { "words" }, "word", true));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(int.MinValue)]
    [InlineData(int.MaxValue)]
    public void SamplingHandlesInvalidOrOversizedSteps(int step)
        => Assert.Empty(challenges.GetEveryNthElement(new List<double> { 1, 2, 3 }, step));

    [Fact]
    public void SamplingReturnsAnIndependentCopyAndPreservesValues()
    {
        var source = new List<double> { double.NaN, double.PositiveInfinity, -2.5 };
        var result = challenges.GetEveryNthElement(source, 1);
        Assert.Equal(source.ToArray(), result);
        result[0] = 42;
        Assert.True(double.IsNaN(source[0]));
    }

    private sealed class SingleUseWords : IEnumerable<string>
    {
        private bool used;
        public IEnumerator<string> GetEnumerator()
        {
            if (used)
                throw new InvalidOperationException("Second enumeration");
            used = true;
            yield return "target";
            throw new InvalidOperationException("Enumerated past the match");
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

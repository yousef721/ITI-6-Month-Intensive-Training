using System;

namespace Lap05;

public static class EnumerableExtensions
{
    public static IEnumerable<int> GetAboveAverage(this IEnumerable<int> numbers)
    {
        if (numbers == null)
            return [];

        var avg = numbers.Average();

        return numbers.Where(n => n > avg);
    }
}

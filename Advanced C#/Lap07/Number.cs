using System;

namespace Lap07;

public static class Number
{
    public static void Factorial()
    {
        Console.WriteLine("Factorial started...");
        Thread.Sleep(3000);

        int n = 5;
        int result = 1;

        for (int i = 1; i <= n; i++)
        {
            result *= i;
        }

        Console.WriteLine($"Factorial Result = {result}");
    }

    public static void Sum()
    {
        Console.WriteLine("Sum started...");

        int n = 5;
        int sum = 0;

        for (int i = 1; i <= n; i++)
        {
            sum += i;
        }

        Console.WriteLine($"Sum Result = {sum}");
    }
}

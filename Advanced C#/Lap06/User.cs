using System;

namespace Lap06;

public class User
{
    public static int Count;

    static User()
    {
        Count = 0;
        Console.WriteLine("User class initialized");
    }

    public User()
    {
        Count++;
    }

    public static void PrintCount()
    {
        Console.WriteLine($"Users count = {Count}");
    }
}

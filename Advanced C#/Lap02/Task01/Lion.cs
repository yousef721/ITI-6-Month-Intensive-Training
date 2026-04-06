using System;

namespace Lap02;

public class Lion : Animal
{

    public Lion(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public void Roar()
    {
        Console.WriteLine($"{Name} is roaring");
    }
}

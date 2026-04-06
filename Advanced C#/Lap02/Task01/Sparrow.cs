using System;

namespace Lap02;

public class Sparrow : Animal
{
    
    public Sparrow(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }
    public void Fly()
    {
        Console.WriteLine($"{Name} is flying");
    }
}

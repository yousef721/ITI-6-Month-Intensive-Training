using System;

namespace Lap05;

public class Animal
{
    public string Name { get; set; }

    public Animal(string name)
    {
        Name = name;
    }

    public override string ToString()
    {
        return Name;
    }
}
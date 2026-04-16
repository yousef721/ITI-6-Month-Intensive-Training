using System;

namespace Lap06;

[StereoType("Class", "This is Person Class")]
public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public void SayHello()
    {
        Console.WriteLine($"Hello, my name is {Name}");
    }

    public int GetBirthYear()
    {
        return DateTime.Now.Year - Age;
    }

    public bool IsValidAge()
    {
        return Age > 18 && Age < 30;
    }


}

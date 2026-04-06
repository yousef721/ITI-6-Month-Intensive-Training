using System;

namespace Lap02.Bonus;

public class Person
{
    Dictionary<string, int> Persons = new Dictionary<string, int>();

    public void AddPerson(string name, int age)
    {
        if (Persons.ContainsValue(age))
        {
            throw new Exception($"There is already a person with age {age}");
        }

        Persons.Add(name, age);
        Console.WriteLine("Add Successfully");
    }
}

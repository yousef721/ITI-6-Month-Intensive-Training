using System;

namespace Lap02;

public class Cage<T> where T : Animal
{
    public T? AnimalInCage { get; set; }
    public void Arrive(T animal)
    {
        if (animal.Age > 8)
        {
            throw new InvalidAgeException("Age must be less than 8");
        }
        AnimalInCage = animal;
    }
}

using System;
using System.Collections;

namespace Lap05;

public class Zoo : IEnumerable<Animal>
{
    private List<Animal> animals = new List<Animal>();

    public void AddAnimal(Animal animal)
    {
        animals.Add(animal);
    }

    public IEnumerator<Animal> GetEnumerator()
    {
        return animals.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

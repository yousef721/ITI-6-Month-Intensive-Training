namespace Lap09Part_2;

class Program
{
    // Tuple
    static void Main(string[] args)
    {
        Console.WriteLine(GetStudentData().Item1);
        int i  = 1;
        foreach (var item in GetStudentData().Item2)
        {
            Console.WriteLine("subject " + i++ + " Grade: " + item);
        }
        Console.WriteLine(GetStudentData().Item3);
    }
    static (string, int[], double) GetStudentData()
    {
        string name = "Ahmed";
        int[] grads = [8,9,5,7,10];
        double avg = grads.Average();
        return (name,grads, avg);
    }
}

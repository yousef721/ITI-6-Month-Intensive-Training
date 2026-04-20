
namespace Lap07;

class Program
{
    static void Main(string[] args)
    {
        #region Task 1
        // // Try to add the two functions to the same thread.
        // ThreadStart threadStart = Number.Factorial;
        // threadStart += Number.Sum;
        // Thread thread = new Thread(threadStart);
        // thread.Start();

        // // Try to make each one in a separated thread.
        // Thread factorialThread = new Thread(Number.Factorial);
        // Thread sumThread = new Thread(Number.Sum);
        // factorialThread.Start();
        // sumThread.Start();
        #endregion

        #region Task 2
        // string path = Path.Combine(
        //     "/Users/yousefabdullah/Desktop",
        //     "ITI 6 Month",
        //     "Advanced C#",
        //     "Lap07",
        //     "Data",
        //     "students.txt"
        // );

        // path.EnsureFile();

        // bool isExit = false;

        // while (!isExit)
        // {
        //     Console.WriteLine("\nMenu:");
        //     Console.WriteLine("1. Add Student");
        //     Console.WriteLine("2. View Students");
        //     Console.WriteLine("3. Search Student");
        //     Console.WriteLine("4. Exit");

        //     Console.Write("Choose: ");
        //     if (!int.TryParse(Console.ReadLine(), out int choose))
        //     {
        //         Console.WriteLine("Invalid input!");
        //         continue;
        //     }

        //     switch (choose)
        //     {
        //         case 1:
        //             path.AddStudents();
        //             break;

        //         case 2:
        //             path.ViewStudents();
        //             break;

        //         case 3:
        //             path.SearchStudent();
        //             break;

        //         case 4:
        //             isExit = true;
        //             break;

        //         default:
        //             Console.WriteLine("Invalid choice!");
        //             break;
        //     }
        // }
        #endregion
    }
}

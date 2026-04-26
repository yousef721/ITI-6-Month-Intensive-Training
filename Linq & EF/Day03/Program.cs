using Day03.Models;

namespace Day03;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\n===== AUTHORS MENU =====");
            Console.WriteLine("1- Add Author");
            Console.WriteLine("2- Read All Authors");
            Console.WriteLine("3- Update Author");
            Console.WriteLine("4- Delete Author");
            Console.WriteLine("5- Exit");
            Console.Write("Choose: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Helper.AddAuthor();
                    break;

                case "2":
                    Helper.ReadAuthors();
                    break;

                case "3":
                    Helper.UpdateAuthor();
                    break;

                case "4":
                    Helper.DeleteAuthor();
                    break;

                case "5":
                    return;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }


}


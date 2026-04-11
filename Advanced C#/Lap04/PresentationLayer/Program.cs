using BLL;
using DAL.Models;

class Program
{
    static void Main()
    {
        AuthorBLL bll = new AuthorBLL();

        while (true)
        {
            Console.WriteLine("\n==== MENU ====");
            Console.WriteLine("1. View All Authors");
            Console.WriteLine("2. Add Author");
            Console.WriteLine("3. Delete Author");
            Console.WriteLine("4. Exit");

            Console.Write("Choose: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    List<Author> authors = bll.GetAllAuthors();

                    Console.WriteLine("\n--- Authors ---");
                    foreach (Author a in authors)
                    {
                        Console.WriteLine(a);
                    }
                    break;

                case "2":
                    Author author = new Author();

                    Console.Write("ID: ");
                    author.Id = Console.ReadLine()!;

                    Console.Write("First Name: ");
                    author.FName = Console.ReadLine()!;

                    Console.Write("Last Name: ");
                    author.LName = Console.ReadLine()!;

                    Console.Write("Phone: ");
                    author.Phone = Console.ReadLine()!;

                    Console.Write("Address: ");
                    author.Address = Console.ReadLine()!;
 
                    Console.Write("City: ");
                    author.City = Console.ReadLine();

                    Console.Write("State: ");
                    author.State = Console.ReadLine()!;

                    Console.Write("ZipCode: ");
                    author.ZipCode = Console.ReadLine()!;

                    Console.Write("Contract (true/false): ");
                    bool.TryParse(Console.ReadLine(), out bool contract);
                    author.Contract = contract;

                    int added = bll.AddNewAuthor(author);
                    Console.WriteLine(added > 0 ? "1 Row Effected" : "Failed");
                    break;

                case "3":
                    Console.Write("Enter ID: ");
                    string id = Console.ReadLine()!;

                    int deleted = bll.DeleteAuthor(id);
                    Console.WriteLine(deleted > 0 ? "1 Row Effected" : "Not Found");
                    break;

                case "4":
                    return;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }
}
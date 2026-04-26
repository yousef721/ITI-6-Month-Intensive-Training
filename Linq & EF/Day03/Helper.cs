using System;
using Day03.Models;

namespace Day03;

public static class Helper
{
    public static void AddAuthor()
    {
        Author author = new Author();

        Console.Write("First Name: ");
        author.AuFname = Console.ReadLine();

        Console.Write("Last Name: ");
        author.AuLname = Console.ReadLine();

        Console.Write("Phone: ");
        author.Phone = Console.ReadLine();

        Console.Write("City: ");
        author.City = Console.ReadLine();

        Console.Write("State: ");
        author.State = Console.ReadLine();

        Console.Write("Contract (true/false): ");
        author.Contract = bool.Parse(Console.ReadLine());

        author.Add();

        Console.WriteLine("Author Added Successfully");
    }

    public static void ReadAuthors()
    {
        var authors = new Author().Read();

        Console.WriteLine("\n===== AUTHORS LIST =====");

        foreach (var a in authors)
        {
            Console.WriteLine($"{a.AuId} | {a.AuFname} {a.AuLname} | {a.Phone = "Unknown"} | {a.City}");
        }
    }

    public static void UpdateAuthor()
    {
        Console.Write("Enter Author ID: ");
        string id = Console.ReadLine();

        Author author = new Author();

        author.AuId = id;

        Console.Write("New First Name: ");
        author.AuFname = Console.ReadLine();

        Console.Write("New Last Name: ");
        author.AuLname = Console.ReadLine();

        Console.Write("New Phone: ");
        author.Phone = Console.ReadLine();

        Console.Write("New City: ");
        author.City = Console.ReadLine();

        Console.Write("New State: ");
        author.State = Console.ReadLine();

        Console.Write("Contract (true/false): ");
        author.Contract = bool.Parse(Console.ReadLine());

        author.Update();

        Console.WriteLine("Updated Successfully");
    }

    public static void DeleteAuthor()
    {
        Console.Write("Enter Author ID: ");
        string id = Console.ReadLine();

        Author author = new Author
        {
            AuId = id
        };

        author.Delete();

        Console.WriteLine("Deleted Successfully");
    }

    public static string GenerateAuthorId() // 582-14-9032
    {
        Random random = new Random();

        string part1 = random.Next(100, 1000).ToString();   // 3 digits
        string part2 = random.Next(10, 100).ToString();     // 2 digits
        string part3 = random.Next(1000, 10000).ToString(); // 4 digits

        return $"{part1}-{part2}-{part3}";
    }  
}

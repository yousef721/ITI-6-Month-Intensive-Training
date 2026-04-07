namespace Lap03;
class Program
{
    static void Main(string[] args)
    {
        #region Task 1
        // Company company = new Company("ITI", 10000);

        // Employee e1 = new Employee("Ahmed", 2000);
        // Employee e2 = new Employee("Ali", 2500);

        // company.AddEmployee(e1);
        // company.AddEmployee(e2);

        // Console.WriteLine("\nSalary Increase\n");

        // e1.IncreaseSalary(500);
        // Console.WriteLine();
        // e2.IncreaseSalary(300);
        #endregion
    
        #region Task 2
        // Company comp = new Company();

        // comp.AddEmployee(new Employee("Ahmed", 2000));
        // comp.AddEmployee(new Employee("Ali", 4000));
        // comp.AddEmployee(new Employee("Mona", 3500));

        // List<Employee> highSalary = comp.FilterEmployees(emp => emp.Salary > 3000);

        // Console.WriteLine("High Salary Employees:");
        // foreach (var e in highSalary)
        // {
        //     Console.WriteLine($"{e.Name} - {e.Salary}");
        // }

        // Console.WriteLine();

        // var nameStartsWithA = comp.FilterEmployees(emp => emp.Name.StartsWith("A"));

        // Console.WriteLine("Names start with A:");
        // foreach (var e in nameStartsWithA)
        // {
        //     Console.WriteLine(e.Name);
        // }
        #endregion

        #region Task 3
        List<Book> books = new List<Book>()
        {
            new Book("1", "C#", ["Ahmed"], new DateTime(2020,1,1), 100),
            new Book("2", "JS", ["Ali","Yousef"], new DateTime(2021,5,10), 200)
        };
        Console.WriteLine("Display Books:");
        foreach(var book in books)
        {
            Console.WriteLine(book.ToString());
        }

        Console.WriteLine("\na) User Defined Delegate");
        LibraryEngine.ProcessBooks(books, BookFunctions.GetTitle);

        Console.WriteLine("\nb) BCL Delegate (Func)");
        LibraryEngine.ProcessBooksBCL(books, BookFunctions.GetAuthors);

        Console.WriteLine("\nc) Anonymous Method (ISBN)");
        LibraryEngine.ProcessBooks(books, delegate (Book b) { return b.ISBN;});

        Console.WriteLine("\nd) Lambda Expression (Publication Date)");
        LibraryEngine.ProcessBooks(books, b => b.PublicationDate.ToShortDateString());

        #endregion
    }
}

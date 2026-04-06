using System;

namespace Lap01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Task 1
            // PhoneBook phoneBook = new();

            // Console.WriteLine("Data:");

            // Console.WriteLine($"Yousef Number: {phoneBook["Yousef"]}");
            // Console.WriteLine($"1234567 Name: {phoneBook[1234567]}");

            // // Modify Data
            // phoneBook["Yousef"] = 12356;
            // phoneBook[1543278] = "Kareem";

            // Console.WriteLine("\nAfter Modify:");

            // Console.WriteLine($"Yousef Number: {phoneBook["Yousef"]}");
            // Console.WriteLine($"1543278 Name: {phoneBook[1543278]}\n");

            // // Error cases
            // phoneBook["Yousef"] = 0;
            // phoneBook[" "] = 12344;

            // // Set Data
            // phoneBook["Magdy"] = 123123;
            // phoneBook[567567] = "Ahmed";

            // Console.WriteLine("\nAfter Set:");

            // Console.WriteLine(phoneBook["Magdy"]);   // 1234567
            // Console.WriteLine(phoneBook[567567]);   // Ahmed

            // Console.WriteLine("\nFinal");
            #endregion
            
            #region Task 2

            // Person person = new()
            // {
            //     // Set data
            //     FirstName = "Yousef",
            //     LastName = "Abdullah",
            //     Age = 22,
            //     Password = "123456" // write-only
            // };

            // // Display data
            // Console.WriteLine("Person Info:");
            // Console.WriteLine($"Full Name: {person.FullName}"); // read-only
            // Console.WriteLine($"Age: {person.Age}");
            // // Console.WriteLine($"Password: {person.Password}"); // Error

            #endregion
            
            #region Task 3
            // Rectangle rect = new(5, 10);
            // Square square = new(4);
            // Circle circle = new(3);

            // Console.WriteLine("Rectangle:");
            // Console.WriteLine($"Area: {rect.CalculateArea()}");
            // Console.WriteLine($"Perimeter: {rect.CalculatePerimeter()}");
            // Console.WriteLine($"Color: {rect.GetColor()}");

            // Console.WriteLine("\nSquare:");
            // Console.WriteLine($"Area: {square.CalculateArea()}");
            // Console.WriteLine($"Perimeter: {square.CalculatePerimeter()}");
            // Console.WriteLine($"Color: {square.GetColor()}");

            // Console.WriteLine("\nCircle:");
            // Console.WriteLine($"Area: {circle.CalculateArea()}");
            // Console.WriteLine($"Perimeter: {circle.CalculatePerimeter()}");
            // Console.WriteLine($"Color: {circle.GetColor()}");

            #endregion
        }
    }
}
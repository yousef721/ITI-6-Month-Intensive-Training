namespace Lap01
{
    internal class Program
    {
        static void Main()
        {
            //1- vs community setup
            //2- calculate birthdate
                // plz enter birth year  2000
                // plz enter birth month  5
                // plz enter birth day  22
                // you're 26 years, 2months and 13 days

            Console.WriteLine("Enter birth year:");
            int year = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter birth month:");
            int month = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter birth day:");
            int day = int.Parse(Console.ReadLine());

            DateTime today = DateTime.Today;

            int totalDays =
                (today.Year - year) * 365 +
                (today.Month - month) * 30 +
                (today.Day - day);

            int years = totalDays / 365;
            totalDays %= 365;

            int months = totalDays / 30;
            int days = totalDays % 30;

            Console.WriteLine($"Your age is {years} years, {months} months, {days} days");
        }
    }
}

namespace Lap01
{
    internal class Program
    {
        static void Main()
        {
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

using Lap02.Bonus;

namespace Lap02;

class Program
{
    static void Main(string[] args)
    {
        #region Task 1
        // Cage<Lion> lionCage = new Cage<Lion>();

        // Lion lion = new Lion("Simba", 5);
        // lionCage.Arrive(lion);

        // // Lion lion2 = new Lion("Simba2", 9); // Age must be less than 8
        // // lionCage.Arrive(lion2); 

        // // Sparrow sparrow = new Sparrow("bird", 5);
        // // lionCage.Arrive(sparrow); // Error

        // Console.WriteLine($"Name is {lionCage?.AnimalInCage?.Name}, age is {lionCage?.AnimalInCage?.Age}");
        // lionCage?.AnimalInCage?.Roar();
        #endregion

        #region Task 2
            #region Dictionary
            // var students = new Dictionary<string, List<int>>();

            // Helper.AddGrade(students, "Ali", 90);
            // Helper.AddGrade(students, "Ali", 85);
            // Helper.AddGrade(students, "Mona", 95);
            // Helper.AddGrade(students, "Mona", 100);
            // Helper.AddGrade(students, "Sara", 80);

            // Helper.DisplayAverages(students);
            // Helper.DisplayTopStudent(students);
            #endregion

            #region ToDoList
            // Queue<string> tasks = new Queue<string>();

            // Helper.AddTask(tasks, "Study C#");
            // Helper.AddTask(tasks, "Solve problems");
            // Helper.AddTask(tasks, "Go to gym");

            // Helper.DisplayTasks(tasks);

            // Console.WriteLine("\nMark 'Solve problems' as completed...\n");
            // Helper.MarkAsCompleted(tasks, "Solve problems");

            // Helper.DisplayTasks(tasks);

            #endregion

            #region Contact
            // Dictionary<string, string> ContactInfos = new Dictionary<string, string>()
            // {
            //     {"Ahmed", "0123456789"},
            //     {"Yousef", "012398689"},
            //     {"Basel", "0123222789"}
            // };

            // string number = Helper.SearchForContact(ContactInfos, "Ahmed");
            // Console.WriteLine("Number: " + number);

            // string number2 = Helper.SearchForContact(ContactInfos, "Ali");
            // Console.WriteLine("Number: " + number); // Exception Error
            #endregion

            #region Stack
            // Stack<string> history = new();
            
            // Helper.VisitPage(history, "google");
            // Helper.VisitPage(history, "Facebook");
            // Helper.VisitPage(history, "Youtube");

            // Helper.ShowHistory(history);

            // Console.WriteLine("\nGo Back:\n");
            // Helper.GoBack(history);

            // Helper.ShowHistory(history);

            #endregion
        #endregion
   
        #region Bonus
        // Person persons = new();

        // persons.AddPerson("Ali", 24);
        // persons.AddPerson("Ahmed", 24);
        #endregion
   }
}
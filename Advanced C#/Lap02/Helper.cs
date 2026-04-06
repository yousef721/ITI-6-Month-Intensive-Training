using System;
using Lap02.Exceptions;

namespace Lap02;

public class Helper
{
    #region Dictionary
    public static void AddGrade(Dictionary<string, List<int>> students, string name, int grade)
    {
        if (!students.ContainsKey(name))
        {
            students[name] = new List<int>();
        }

        students[name].Add(grade);
    }

    public static void DisplayAverages(Dictionary<string, List<int>> students)
    {
        foreach (var student in students)
        {
            double avg = student.Value.Average();
            Console.WriteLine($"{student.Key} : Average = {avg:F2}");
        }
    }

    public static void DisplayTopStudent(Dictionary<string, List<int>> students)
    {
        string topName = "";
        double maxAvg = 0;

        foreach (var s in students)
        {
            double avg = s.Value.Average();

            if (avg > maxAvg)
            {
                maxAvg = avg;
                topName = s.Key;
            }
        }

        Console.WriteLine($"Top Student: {topName} with Average = {maxAvg:F2}");
    }

    #endregion

    #region ToDo List
    public static void AddTask(Queue<string> tasks, string task)
    {
        tasks.Enqueue(task);
    }

    public static void DisplayTasks(Queue<string> tasks)
    {
        Console.WriteLine($"You have {tasks.Count} tasks:");

        foreach (var task in tasks)
        {
            Console.WriteLine("- " + task);
        }
    }

    public static void MarkAsCompleted(Queue<string> tasks, string task)
    {
        Queue<string> temp = new Queue<string>();

        while (tasks.Count > 0)
        {
            string current = tasks.Dequeue();
            if (current == task)
            {
                current = task + " (Completed)";
            }
            temp.Enqueue(current);
        }

        while (temp.Count > 0)
        {
            tasks.Enqueue(temp.Dequeue());
        }
    }
    #endregion
    
    #region Contact
    public static string SearchForContact(Dictionary<string, string> contactInfos, string contact)
    {
        if (!contactInfos.ContainsKey(contact))
        {
            throw new ContactNotFoundException($"{contact} Not Found");
        }

        return contactInfos[contact];
    }
    #endregion

    #region Stack
    public static void VisitPage(Stack<string> history, string url)
    {
        history.Push(url);
        Console.WriteLine($"Visited: {url}");
    }

    public static void GoBack(Stack<string> history)
    {
        if (history.Count > 0)
        {
            history.Pop();

            if (history.Count > 0)
                Console.WriteLine("Current Page: " + history.Peek());
            else
                Console.WriteLine("No pages left.");
        }
        else
        {
            Console.WriteLine("History is empty.");
        }
    }
    public static void ShowHistory(Stack<string> history)
    {
        Console.WriteLine("History:");
        foreach (var page in history)
        {
            Console.WriteLine("- " + page);
        }
    }

    #endregion

    #region Bonus

    #endregion

}

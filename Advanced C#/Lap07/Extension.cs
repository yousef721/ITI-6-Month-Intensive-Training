using System;

namespace Lap07;

public static class Extension
{
    public static void EnsureFile(this string path)
    {
        string? directory = Path.GetDirectoryName(path);

        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory!);
        }

        if (!File.Exists(path))
        {
            File.Create(path).Close();
        }
    }


    public static void AddStudents(this string path)
    {
        string isContinue;
        do
        {
            Console.Write("Enter Name: ");
            string studentName = Console.ReadLine()!;

            File.AppendAllText(path, studentName + Environment.NewLine);  

            Console.WriteLine("Are you want to continue: (Yes/No)");
            isContinue = Console.ReadLine()!;
        } while(isContinue == "Yes" || isContinue == "yes");
    }


    public static void ViewStudents(this string path)
    {
        string[] students = File.ReadAllLines(path);

        for (int i = 0; i < students.Length; i++)
        {
            Console.WriteLine(students[i]);
        }

    }
    

    public static void SearchStudent(this string path)
    {
        string[] students = File.ReadAllLines(path);
        Console.Write("Search By Name: ");

        string SearchStudentByName = Console.ReadLine()!;

        bool found = false;

        for (int i = 0; i < students.Length; i++)
        {
            if(students[i].Contains(SearchStudentByName, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(students[i]);
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("Student not found!");
        }
    }

}

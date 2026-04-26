using System;
namespace Day01;

class Program
{
    static void Main(string[] args)
    {
        
        // #region Task 1
        // List<int> numbers = new List<int>() {2,4,6,7,1,4,2,9,1};

        // Console.WriteLine("\nQuery 1");
        
        // var ListOrderedAndWithoutRepeat = numbers.OrderBy(num => num).Distinct();
        // foreach(var num in ListOrderedAndWithoutRepeat)
        // {
        //     Console.WriteLine(num);
        // }

        // Console.WriteLine("\nQuery 2");

        // foreach(var num in ListOrderedAndWithoutRepeat)
        // {
        //     Console.WriteLine(new {Numbers = num, Multiply = num * num});
        // }

        // #endregion
        
        #region Task 2
        string[] names = { "Tom", "Dick", "Harry", "MARY", "Jay" }; 

        Console.WriteLine("\nQuery 1 Query Expression");

        var DataWithQueryExpression = from name in names where name.Length == 3 select name;

        foreach (var item in DataWithQueryExpression)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("\nQuery 1 Method Expression");

        var DataWithMethodExpression = names.Where(name => name.Length == 3);

        foreach (var item in DataWithMethodExpression)
        {
            Console.WriteLine(item);
        }


        Console.WriteLine("\nQuery 2");


        var NamesContainsA = names.Where(name => name.ToLower().Contains('a')).OrderBy(name => name.Length);

        foreach (var item in NamesContainsA)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("\nQuery 3");

        var firstTwoName = names.Take(2);

        foreach (var item in firstTwoName)
        {
            Console.WriteLine(item);
        }
        #endregion
    
        // #region Task 3
        // List<Student> students = new List<Student> (){
        //     new Student(){ ID=1, FirstName="Ali",  LastName="Mohammed", subjects = new Subject[]{ new Subject(){ Code = 22,Name = "EF"}, new Subject(){Code = 33,Name = "UML"}} },              
        //     new Student(){ ID=2, FirstName="Mona", LastName="Gala", subjects= new Subject[]{ new Subject(){ Code=22,Name="EF"}, new Subject (){ Code = 34,Name = "XML"},new Subject (){ Code = 25, Name = "JS"}}},             
        //     new Student(){ ID=3, FirstName="Yara", LastName="Yousef", subjects= new Subject []{ new Subject (){ Code=22,Name="EF"}, new Subject (){ Code = 25,Name = "JS"}}},               
        //     new Student(){ ID=1, FirstName="Ali",  LastName="Ali", subjects= new Subject []{  new Subject (){ Code=33,Name="UML"}}},  
        // };

        // Console.WriteLine("\nQuery 1");

        // var data = students.Select(stud => new {FullName = stud.FirstName + stud.LastName, NoOfSubjects = stud.subjects?.Length});

        // foreach (var item in data)
        // {
        //     Console.WriteLine(item);
        // }

        // Console.WriteLine("\nQuery 2");

        // var DescendingByFirstThenAscendingByLast = students.Select(stud => new { FName = stud.FirstName, LName = stud.LastName}).OrderByDescending(name => name.FName).ThenBy(name => name.LName);

        // foreach (var item in DescendingByFirstThenAscendingByLast)
        // {
        //     Console.WriteLine(item.FName + " " + item.LName);
        // }
        
        // Console.WriteLine("\nQuery 3");

        // var eachStudentAndSubject = students.SelectMany(subj => subj.subjects, (std, subj) => new {FullName = std.FirstName + " " + std.LastName, SubjectName = subj.Name} );

        // foreach (var item in eachStudentAndSubject)
        // {
        //     Console.WriteLine(item);
        // }

        // Console.WriteLine("\nBONUS");

        // var BONUS = students.GroupBy(name => name.FirstName + " " + name.LastName);

        // foreach (var item in BONUS)
        // {
        //     Console.WriteLine(item.Key);
        //     foreach (var sub in item.SelectMany(x => x?.subjects))
        //     {
        //         Console.WriteLine("--" + sub.Name);
        //     }
        // }
        // #endregion 
    
    }
}

namespace Lap05;

class Program
{
    static void Main(string[] args)
    {
        #region Task 1
        // static List<Dictionary<string, object>> GetComplexData()
        // {
        //     return new List<Dictionary<string, object>>
        //     {
        //         new Dictionary<string, object>
        //         {
        //             { "Name", "Ahmed" },
        //             { "Age", 25 },
        //         },
        //         new Dictionary<string, object>
        //         {
        //             { "Name", "Ali" },
        //             { "Age", 30 },
        //         }
        //     };
        // }
        
        // var data = GetComplexData();

        // foreach (var item in data)
        // {
        //     foreach (var pair in item)
        //     {
        //         Console.WriteLine($"{pair.Key} : {pair.Value}");
        //     }
        //     Console.WriteLine("------");
        // }
        #endregion
    
        #region Task 2
        // var email = "yousef@gmail.com";
        // Console.WriteLine(email.IsValidEmail());    

        // Console.WriteLine("-----------------------------");    

        // var numbers = new List<int> { 100, 200, 300, 400 };

        // var result = numbers.GetAboveAverage();

        // foreach (var n in result)
        // {
        //     Console.WriteLine(n);
        // }

        // Console.WriteLine("-----------------------------");  

        // Console.WriteLine(DateTime.Today.ToFriendlyDate());        // Today
        // Console.WriteLine(DateTime.Today.AddDays(-1).ToFriendlyDate()); // Yesterday
        // Console.WriteLine(DateTime.Today.AddDays(1).ToFriendlyDate());  // Tomorrow
        // Console.WriteLine(new DateTime(2026, 1, 1).ToFriendlyDate());   // 01/01/2026 

        #endregion
        
        #region Task 3

        // var zoo = new Zoo();

        // zoo.AddAnimal(new Animal("Animal1"));
        // zoo.AddAnimal(new Animal("Animal2"));

        // foreach (var animal in zoo)
        // {
        //     Console.WriteLine(animal);
        // }
        #endregion
    }
}

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
        // var email = "test@gmail.com";
        // Console.WriteLine(email.IsValidEmail());    

        // Console.WriteLine("-----------------------------");    

        // var numbers = new List<int> { 10, 20, 30, 40 };

        // var result = numbers.GetAboveAverage();

        // foreach (var n in result)
        // {
        //     Console.WriteLine(n); // 30, 40
        // }

        // Console.WriteLine("-----------------------------");  

        // Console.WriteLine(DateTime.Today.ToFriendlyDate());        // Today
        // Console.WriteLine(DateTime.Today.AddDays(-1).ToFriendlyDate()); // Yesterday
        // Console.WriteLine(DateTime.Today.AddDays(1).ToFriendlyDate());  // Tomorrow
        // Console.WriteLine(new DateTime(2023, 5, 1).ToFriendlyDate());   // 01/05/2023 

        #endregion
        
        #region Task 3

        // var zoo = new Zoo();

        // zoo.AddAnimal(new Animal("Lion"));
        // zoo.AddAnimal(new Animal("Tiger"));
        // zoo.AddAnimal(new Animal("Elephant"));

        // foreach (var animal in zoo)
        // {
        //     Console.WriteLine(animal);
        // }
        #endregion
    }
}

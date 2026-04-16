using System.Text;
[assembly: CLSCompliant(true)]

namespace Lap06;

public class CLSAttribute
{
    public static uint GetNumber()
    {
        uint x = 10;
        return x;
    }
}
class Program
{
    static void Main(string[] args)
    {
        
        #region Task 1
            #region 1
                // //a.	CLSAttribute.
                // CLSAttribute.GetNumber();

                // //b.	ObsoleteAttribute (in both cases true and false).
                // Method.Add(1,2);
                // // Method.Add(1,2,3); // deprecated

                // //c.	FlagAttribute (with TextStyling Enum).

                // TextStyling style = TextStyling.Bold | TextStyling.Italic;

                // Console.WriteLine(style);
            #endregion
            #region 2
            // // Query this attribute with reflections and display its data.
            // var type = typeof(Person);

            // var attribute = (StereoType)Attribute.GetCustomAttribute(type, typeof(StereoType))!;
            // Console.WriteLine($"Type: {attribute?.Type}");
            // Console.WriteLine($"Description: {attribute?.Description}");
            #endregion
            #region 3
            // var type = typeof(int);
            
            // Console.WriteLine($"Type Name: {type.Name}");
            // Console.WriteLine($"Full Name: {type.FullName}");
            // Console.WriteLine($"Namespace: {type.Namespace}");
            // Console.WriteLine($"Is Primitive: {type.IsPrimitive}");

            // Console.WriteLine("\n--- Methods ---");
            // foreach (var method in type.GetMethods())
            // {
            //     Console.WriteLine(method.Name);
            // }

            // Console.WriteLine("\n--- Properties ---");
            // foreach (var prop in type.GetProperties())
            // {
            //     Console.WriteLine(prop.Name);
            // }
            #endregion
            #region 4
            // Type type = typeof(Person);

            // Console.WriteLine($"Name: {type.Name}");
            // Console.WriteLine($"Full Name: {type.FullName}");
            // Console.WriteLine($"Namespace: {type.Namespace}");


            // Console.WriteLine("\n--- Methods ---");
            // foreach (var method in type.GetMethods())
            // {
            //     Console.WriteLine(method.Name);
            // }

            // Console.WriteLine("\n--- Properties ---");
            // foreach (var prop in type.GetProperties())
            // {
            //     Console.WriteLine($"{prop.PropertyType.Name} {prop.Name}");
            // }

            #endregion
            #region 5
            // Type type = typeof(Student);

            // // 1. Create object at runtime
            // object obj = Activator.CreateInstance(type)!;

            // // 2. Set properties using Reflection
            // type.GetProperty("Name")?.SetValue(obj, "Yousef");
            // type.GetProperty("Age")?.SetValue(obj, 24);
            // type.GetProperty("Grade")?.SetValue(obj, Grade.A);
            // type.GetProperty("Address")?.SetValue(obj, "Cairo");

            // // 3. Print values
            // type.GetMethod("PrintInfo")?.Invoke(obj, null);
            #endregion
        #endregion
        
        #region Task 2
        // StringBuilder stringBuilder = new();

        // stringBuilder.Append("Hello");
        // stringBuilder.AppendLine("Students");
        // stringBuilder.Insert(5, "Amazing ");
        // stringBuilder.Replace("Students", "Yousef");
        // stringBuilder.Remove(0, 5);
        // Console.WriteLine(stringBuilder.ToString());
        #endregion
        
        #region Task 3
        // User.PrintCount();

        // var u1 = new User();
        // var u2 = new User();

        // User.PrintCount();
        #endregion
    }
}

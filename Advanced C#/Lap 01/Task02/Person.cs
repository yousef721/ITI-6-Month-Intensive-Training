using System;

namespace Lap01;

public class Person
{
    public string FirstName { get; set; } // Automatic Property
    public string LastName { get; set; }
    public string FullName => $"{FirstName} {LastName}"; // Readonly Property
    public int Age { get; set; } // Automatic Property

    
    public string Password
    {
        private get => field;
        set
        {
            field = value;
        }
    } // Write-only Property  

}

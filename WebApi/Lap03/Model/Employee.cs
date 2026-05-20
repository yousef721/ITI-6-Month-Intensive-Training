using Microsoft.AspNetCore.Identity;

namespace Lap03.Model;

public class Employee : IdentityUser
{
    public string? FirstName { get; set;}
    public string? LastName { get; set;}
    public int Age { get; set;}
    public int Salary { get; set;}
}

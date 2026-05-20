using System;

namespace Lap03.DTOs;

public class RegisterDto
{
    public string FirstName { get; set; } 

    public string UserName { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public string Role { get; set; }
}

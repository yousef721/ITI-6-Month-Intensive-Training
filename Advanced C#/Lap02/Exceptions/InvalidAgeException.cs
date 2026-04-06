using System;

namespace Lap02;

public class InvalidAgeException : Exception
{
    public InvalidAgeException(string message) : base(message)
    {
        
    }
}

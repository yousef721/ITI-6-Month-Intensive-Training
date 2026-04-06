using System;

namespace Lap02.Exceptions;

public class ContactNotFoundException : Exception
{
    public ContactNotFoundException(string message) : base(message)
    {
        
    }
}

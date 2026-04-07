using System;

namespace Lap02;

public class ContactNotFoundException : Exception
{
    public ContactNotFoundException(string message) : base(message)
    {
        
    }
}

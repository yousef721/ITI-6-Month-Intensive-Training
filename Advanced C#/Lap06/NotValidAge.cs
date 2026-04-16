using System;

namespace Lap06;

public class NotValidAge : Exception
{
    public NotValidAge(string _message) : base(_message){
        
    }
}

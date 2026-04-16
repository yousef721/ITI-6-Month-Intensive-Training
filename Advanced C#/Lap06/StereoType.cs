using System;

namespace Lap06;
[AttributeUsage(AttributeTargets.All)] // class, method, property
public class StereoType : Attribute
{
    public string Type {get; set;}
    public string Description { get; set; }
    public StereoType(string _type, string _Description)
    {
        Type = _type;
        Description = _Description;
    }
}

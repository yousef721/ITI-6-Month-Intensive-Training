namespace DAL.Models;

public class Author
{
    public string Id { get; set; } = default!;
    public string FName { get; set; } = string.Empty;
    public string LName { get; set; } = string.Empty;
    public string FullName => $"{FName} {LName}".Trim();
    public string Phone { get; set; } = string.Empty;
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? ZipCode { get; set; }

    public bool Contract { get; set; }

    public override string ToString()
    {
        return
        $"""
        Author: {FullName}
        ===========================
        Id       : {Id}
        FName    : {FName}
        LName    : {LName}
        Phone    : {Phone}
        Address  : {Address}
        City     : {City}
        State    : {State}
        ZipCode  : {ZipCode}
        Contract : {Contract}
        
        """;
    }
}
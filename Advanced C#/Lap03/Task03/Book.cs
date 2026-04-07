using System;

namespace Lap03;

public class Book 
{ 
    public string ISBN { get; set; } 
    public string Title { get; set; } 
    public string[] Authors { get; set; } 
    public DateTime PublicationDate { get; set; } 
    public decimal Price { get; set; } 
    
    public Book(string _ISBN, string _Title, string[] _Authors, DateTime _PublicationDate, decimal _Price) 
    { 
        ISBN = _ISBN;
        Title = _Title;
        Authors = _Authors;
        PublicationDate = _PublicationDate;
        Price = _Price;
    } 
    
    public override string ToString()
    {
        return $"{ISBN} - {Title} - {BookFunctions.GetAuthors(this)} - {Price}$ - {PublicationDate.ToShortDateString()}";
    }
} 

public class BookFunctions 
{ 
    public static string GetTitle(Book B)
    {
        return B.Title;
    }
    
    public static string GetAuthors(Book B)
    {
        return string.Join(", ", B.Authors);
    }
    
    public static string GetPrice(Book B)
    {
        return B.Price.ToString();
    }
} 
public delegate string BookDelegate(Book B); // User Defined Delegate
public class LibraryEngine 
{ 
    public static void ProcessBooks(List<Book> bList, BookDelegate fPtr) 
    {
        foreach (Book B in bList)
        {
            Console.WriteLine(fPtr(B));
        }
    }
    public static void ProcessBooksBCL(List<Book> bList, Func<Book, string> fPtr) // BCL Delegate : Func, Action, Predicate
    {
        foreach (Book B in bList)
        {
            Console.WriteLine(fPtr(B));
        }
    }
}
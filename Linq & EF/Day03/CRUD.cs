using System;
using Day03.Models;

namespace Day03;

public static class CRUD
{
    public static void Add(this Author author)
    {
        using (var context = new PubsContext())
        {
            if (author == null)
                throw new Exception("Author is null");

            if (string.IsNullOrWhiteSpace(author.AuFname))
                throw new Exception("First Name is required");

            if (string.IsNullOrWhiteSpace(author.AuLname))
                throw new Exception("Last Name is required");


            author.AuId = Helper.GenerateAuthorId();

            context.Authors.Add(author);
            context.SaveChanges();
        }
    }

    public static List<Author> Read(this Author author)
    {
        using (var context = new PubsContext())
        {
            return context.Authors.ToList();
        }
    }

    public static void Update(this Author author)
{
    using (var context = new PubsContext())
    {
        if (author == null)
            throw new Exception("Author is null");

        if (string.IsNullOrWhiteSpace(author.AuFname))
            throw new Exception("First Name is required");

        if (string.IsNullOrWhiteSpace(author.AuLname))
            throw new Exception("Last Name is required");

        var old = context.Authors.Find(author.AuId);

        if (old == null)
            throw new Exception("Author not found");

        old.AuFname = author.AuFname;
        old.AuLname = author.AuLname;
        old.Phone = author.Phone;
        old.Address = author.Address;
        old.City = author.City;
        old.State = author.State;
        old.Zip = author.Zip;
        old.Contract = author.Contract;

        context.SaveChanges();
    }
}

    public static void Delete(this Author author)
    {
        using var context = new PubsContext();

        var old = context.Authors.Find(author.AuId);

        if (old == null)
            throw new Exception("Author not found");

        context.Authors.Remove(old);
        context.SaveChanges();
    }

}

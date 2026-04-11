using System.Data;
using DAL;
using DAL.Models;

namespace BLL;

public class AuthorBLL
{
    AuthorManger authorManger = new();

    public List<Author> GetAllAuthors()
    {
        var table = authorManger.GetAllAuthor();
        return ConvertDataTableToList(table);
    }

    public int AddNewAuthor(Author author)
    {
        return authorManger.InsertAuthor(
            author.Id,
            author.FName,
            author.LName,
            author.Phone,
            author.Address,
            author.City,
            author.State,
            author.ZipCode,
            author.Contract
        );
    }

    public int DeleteAuthor(string id)
    {
        return authorManger.DeleteAuthor(id);
    }

    public List<Author> ConvertDataTableToList(DataTable dt)
    {
        if (dt == null || dt.Rows.Count == 0)
            return new List<Author>();

        List<Author> authors = new();

        foreach (DataRow row in dt.Rows)
            authors.Add(ConvertDataRowToAuthor(row));

        return authors;
    }

    public Author ConvertDataRowToAuthor(DataRow row)
    {
        return new Author()
        {
            Id = row["au_id"].ToString()!,
            FName = row["au_fname"]?.ToString()!,
            LName = row["au_lname"]?.ToString()!,
            Phone = row["phone"]?.ToString()!,
            Address = row["address"] == DBNull.Value ? null : row["address"].ToString(),
            City = row["city"] == DBNull.Value ? null : row["city"].ToString(),
            State = row["state"] == DBNull.Value ? null : row["state"].ToString(),
            ZipCode = row["zip"] == DBNull.Value ? null : row["zip"].ToString(),
            Contract = row["contract"] != DBNull.Value && Convert.ToBoolean(row["contract"])
        };
    }
}
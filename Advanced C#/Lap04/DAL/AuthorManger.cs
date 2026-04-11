using System.Data;
using DAL;

namespace BLL;

public class AuthorManger
{
    DbManger db = new DbManger();

    private readonly string selectQuery = "SELECT * FROM authors";
    private readonly string insertQuery =
        "INSERT INTO authors (au_id, au_fname, au_lname, phone, address, city, state, zip, contract) " +
        "VALUES (@id, @fname, @lname, @phone, @address, @city, @state, @zip, @contract)";
    private readonly string deleteQuery = "DELETE FROM authors WHERE au_id = @id";

    public DataTable GetAllAuthor()
    {
        DataTable table = new DataTable();

        db.Adapter.SelectCommand.CommandText = selectQuery;

        db.Adapter.Fill(table);

        return table;
    }

    public int InsertAuthor(string id, string fname, string lname, string phone,
        string address, string city, string state, string zip, bool contract)
    {
        DataTable table = GetAllAuthor();

        DataRow row = table.NewRow();

        row["au_id"] = id;
        row["au_fname"] = fname;
        row["au_lname"] = lname;
        row["phone"] = phone;
        row["address"] = address ?? (object)DBNull.Value;
        row["city"] = city ?? (object)DBNull.Value;
        row["state"] = state ?? (object)DBNull.Value;
        row["zip"] = zip ?? (object)DBNull.Value;
        row["contract"] = contract;

        table.Rows.Add(row);

        db.Adapter.InsertCommand.CommandText = insertQuery;

        db.Adapter.InsertCommand.Parameters.AddWithValue("@id", id);
        db.Adapter.InsertCommand.Parameters.AddWithValue("@fname", fname);
        db.Adapter.InsertCommand.Parameters.AddWithValue("@lname", lname);
        db.Adapter.InsertCommand.Parameters.AddWithValue("@phone", phone);
        db.Adapter.InsertCommand.Parameters.AddWithValue("@address", (object?)address ?? DBNull.Value);
        db.Adapter.InsertCommand.Parameters.AddWithValue("@city", (object?)city ?? DBNull.Value);
        db.Adapter.InsertCommand.Parameters.AddWithValue("@state", (object?)state ?? DBNull.Value);
        db.Adapter.InsertCommand.Parameters.AddWithValue("@zip", (object?)zip ?? DBNull.Value);
        db.Adapter.InsertCommand.Parameters.AddWithValue("@contract", contract);

        return db.Adapter.Update(table);
    }

    public int DeleteAuthor(string id)
    {
        DataTable table = GetAllAuthor();

        foreach (DataRow row in table.Rows)
        {
            if (row["au_id"].ToString() == id)
            {
                row.Delete();
                break;
            }
        }

        db.Adapter.DeleteCommand.Parameters.Clear();
        db.Adapter.DeleteCommand.CommandText = deleteQuery;
        db.Adapter.DeleteCommand.Parameters.AddWithValue("@id", id);

        return db.Adapter.Update(table);
    }
}
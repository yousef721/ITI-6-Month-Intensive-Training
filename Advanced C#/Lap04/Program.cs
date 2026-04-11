using System.Data;
using Microsoft.Data.SqlClient;

namespace Lap04;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        string connectionString = "Data Source=localhost;User ID=SA;Password=reallyStrong123;Initial Catalog=E-Commerce;TrustServerCertificate=True";
        SqlConnection sqlConnection = new(connectionString);
        sqlConnection.Open();

        SqlCommand sqlCommand = new SqlCommand("INSERT INTO Products(Name) VALUES (@Name)", sqlConnection);

        sqlCommand.Parameters.AddWithValue("@Name", "Android");

        sqlCommand.ExecuteNonQuery();

        sqlConnection.Close();

    }
}

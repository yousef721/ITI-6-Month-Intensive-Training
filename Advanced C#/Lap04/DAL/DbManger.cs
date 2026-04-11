using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DAL;

public class DbManger
{
    public SqlDataAdapter Adapter { get; private set; }
    private SqlConnection Connection { get; set; }

    public DbManger()
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

        string connStr = config.GetConnectionString("ConnectionString")!;

        Connection = new SqlConnection(connStr);

        Adapter = new SqlDataAdapter();
        Adapter.SelectCommand = new SqlCommand("", Connection);
        Adapter.InsertCommand = new SqlCommand("", Connection);
        Adapter.DeleteCommand = new SqlCommand("", Connection);
    }
}
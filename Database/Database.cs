
using Microsoft.Data.SqlClient;
using System.Data.SqlClient;

namespace GroupProject.Database;
public class Database
{
    protected SqlConnection conn;
    protected string connectionString = "Server=(localdb)\\MSSQLLocalDb;Database=GPDB1;Integrated Security=true;";

    public void connect() 
    {
        conn = new SqlConnection(this.connectionString);
    }

    public Database() 
    { 
        connect();
    }

    public Database(string connectionString)
    {
        this.connectionString = connectionString;
        connect();
    }
    
    
}

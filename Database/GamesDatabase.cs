using System.Data;
using System.Security.Cryptography.X509Certificates;
using GroupProject.Models;
using Microsoft.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace GroupProject.Database;

public class GamesDatabase : Database
{
    public GamesDatabase() 
    {
        base.connect();

    }

    public List<Game> GetGames() 
    {

        List<Game> games = new List<Game>();

        base.conn.Open(); // this could throw an exception if the db does not exist

        string query = "Select * from game;";

        SqlCommand sqlCommand = new SqlCommand(query, base.conn);

        SqlDataReader reader = sqlCommand.ExecuteReader();// this will run the cmd on the server

        while (reader.Read())
        {
            Game game = new Game();

            game.id = (int)reader["Id"];
            game.name = (string)reader["name"];
            game.price = Decimal.ToDouble((decimal)reader["price"]);
            game.revenue = Decimal.ToDouble((decimal)reader["revenue"]);
            game.numberOfPlayers = (int)reader["numberOfPlayers"];
            game.platforms = (String)reader["platforms"];
            game.releaseDate = (DateTime)reader["releaseDate"];

            games.Add(game);
            
        }

        return games;
    }
    public bool addGame(Game game) 
    {
        base.conn.Open(); // this could throw an exception if the db does not exist

        string query = "INSERT INTO game (name,price,revenue,numberOfPlayers,platforms,releaseDate) VALUES (@name,@price,@revenue,@numberOfPlayers,@platforms,@releaseDate);";

        SqlCommand sqlCommand = new SqlCommand(null, base.conn);
        sqlCommand.CommandText = query;
       
        SqlParameter nameParam = new SqlParameter("@name", SqlDbType.Text, 50);
        SqlParameter priceParam = new SqlParameter("@price", SqlDbType.Decimal, 10);
        SqlParameter revenueParam = new SqlParameter("@revenue", SqlDbType.Decimal, 10);
        SqlParameter numberOfPlayersParam = new SqlParameter("@numberOfPlayers", SqlDbType.Int, 0);
        SqlParameter platformsParam = new SqlParameter("@platforms", SqlDbType.Text, 500);
        SqlParameter releaseDateParam = new SqlParameter("@releaseDate", SqlDbType.DateTime, 0);

        
        nameParam.Value = game.name;
        priceParam.Value = game.price;
        revenueParam.Value = game.revenue;
        numberOfPlayersParam.Value = game.numberOfPlayers;
        platformsParam.Value = game.platforms;
        releaseDateParam.Value = game.releaseDate;

        
        sqlCommand.Parameters.Add(nameParam);
        sqlCommand.Parameters.Add(priceParam);
        sqlCommand.Parameters.Add(revenueParam);
        sqlCommand.Parameters.Add(numberOfPlayersParam);
        sqlCommand.Parameters.Add(platformsParam);
        sqlCommand.Parameters.Add(releaseDateParam);

        sqlCommand.Parameters["@price"].Precision = 10;
        sqlCommand.Parameters["@price"].Scale = 2;

        sqlCommand.Parameters["@revenue"].Precision = 10;
        sqlCommand.Parameters["@revenue"].Scale = 2;


        try
        {

            sqlCommand.Prepare();
            int i = sqlCommand.ExecuteNonQuery();
            if (i == 0) {
                return false;
            }
            else
            {
                return true;
            }
        }
        catch (Exception e) 
        { 
            Console.WriteLine(e);
            return false;
        }
        
    }

    public bool deleteGame(int index) 
    {
        base.conn.Open(); // this could throw an exception if the db does not exist

        string query = "DELETE FROM game WHERE Id=@Id;";

        SqlCommand sqlCommand = new SqlCommand(null, base.conn);
        sqlCommand.CommandText = query;

        SqlParameter idParam = new SqlParameter("@Id", SqlDbType.Int, 0);

        idParam.Value = index;
        
        sqlCommand.Parameters.Add(idParam);

        try
        {

            sqlCommand.Prepare();
            int i = sqlCommand.ExecuteNonQuery();
            if (i == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }


       
    }

    public bool updateGame(Game game) 
    {
        base.conn.Open(); // this could throw an exception if the db does not exist

        string query = "UPDATE game SET name=@name,price=@price,revenue=@revenue,numberOfPlayers=@numberOfPlayers,platforms=@platforms,releaseDate=@releaseDate WHERE Id=@Id";

        SqlCommand sqlCommand = new SqlCommand(null, base.conn);
        sqlCommand.CommandText = query;

        SqlParameter idParam = new SqlParameter("@Id", SqlDbType.Int, 0);
        SqlParameter nameParam = new SqlParameter("@name", SqlDbType.Text, 50);
        SqlParameter priceParam = new SqlParameter("@price", SqlDbType.Decimal, 10);
        SqlParameter revenueParam = new SqlParameter("@revenue", SqlDbType.Decimal, 10);
        SqlParameter numberOfPlayersParam = new SqlParameter("@numberOfPlayers", SqlDbType.Int, 0);
        SqlParameter platformsParam = new SqlParameter("@platforms", SqlDbType.Text, 500);
        SqlParameter releaseDateParam = new SqlParameter("@releaseDate", SqlDbType.DateTime, 0);

        idParam.Value = game.id;
        nameParam.Value = game.name;
        priceParam.Value = game.price;
        revenueParam.Value = game.revenue;
        numberOfPlayersParam.Value = game.numberOfPlayers;
        platformsParam.Value = game.platforms;
        releaseDateParam.Value = game.releaseDate;

        sqlCommand.Parameters.Add(idParam);
        sqlCommand.Parameters.Add(nameParam);
        sqlCommand.Parameters.Add(priceParam);
        sqlCommand.Parameters.Add(revenueParam);
        sqlCommand.Parameters.Add(numberOfPlayersParam);
        sqlCommand.Parameters.Add(platformsParam);
        sqlCommand.Parameters.Add(releaseDateParam);

        sqlCommand.Parameters["@price"].Precision = 10;
        sqlCommand.Parameters["@price"].Scale = 2;

        sqlCommand.Parameters["@revenue"].Precision = 10;
        sqlCommand.Parameters["@revenue"].Scale = 2;


        try
        {

            sqlCommand.Prepare();
            int i = sqlCommand.ExecuteNonQuery();
            if (i == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
        
    }

}

using GroupProject.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace GroupProject.Database
{
    public class MerchDatabase : Database
    {
        public MerchDatabase()
        {
            base.connect();

        }

        public List<Merch> GetMerches()
        {

            List<Merch> merches = new List<Merch>();

            base.conn.Open(); // this could throw an exception if the db does not exist

            string query = "Select * from merch;";

            SqlCommand sqlCommand = new SqlCommand(query, base.conn);

            SqlDataReader reader = sqlCommand.ExecuteReader();// this will run the cmd on the server

            while (reader.Read())
            {
                Merch merch = new Merch();

                merch.Id = (int)reader["Id"];
                merch.itemName = (string)reader["itemName"];
                merch.itemDescription = (string)reader["itemDescription"];
                merch.itemInStock = (int)reader["itemInStock"];
                merch.itemPrice = Decimal.ToDouble((decimal)reader["itemPrice"]);

                merches.Add(merch);

            }

            return merches;
        }
        public bool addMerch(Merch merch)
        {
            base.conn.Open(); // this could throw an exception if the db does not exist

            string query = "INSERT INTO merch (itemName,itemDescription,itemInStock,itemPrice) VALUES (@itemName,@itemDescription,@itemInStock,@itemPrice);";

            SqlCommand sqlCommand = new SqlCommand(null, base.conn);
            sqlCommand.CommandText = query;

            SqlParameter itemNameParam = new SqlParameter("@itemName", SqlDbType.Text, 50);
            SqlParameter itemDescriptionParam = new SqlParameter("@itemDescription", SqlDbType.Text, 500);
            SqlParameter itemInStockParam = new SqlParameter("@itemInStock", SqlDbType.Int, 0);
            SqlParameter itemPriceParam = new SqlParameter("@itemPrice", SqlDbType.Decimal, 10);



            itemNameParam.Value = merch.itemName;
            itemDescriptionParam.Value = merch.itemDescription;
            itemInStockParam.Value = merch.itemInStock;
            itemPriceParam.Value = merch.itemPrice;



            sqlCommand.Parameters.Add(itemNameParam);
            sqlCommand.Parameters.Add(itemDescriptionParam);
            sqlCommand.Parameters.Add(itemInStockParam);
            sqlCommand.Parameters.Add(itemPriceParam);
            

            sqlCommand.Parameters["@itemPrice"].Precision = 10;
            sqlCommand.Parameters["@itemPrice"].Scale = 2;

            


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

        public bool deleteMerch(int index)
        {
            base.conn.Open(); // this could throw an exception if the db does not exist

            string query = "DELETE FROM merch WHERE Id=@Id;";

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

        public bool updateMerch(Merch merch)
        {
            base.conn.Open(); // this could throw an exception if the db does not exist

            string query = "UPDATE merch SET itemName=@itemName,itemDescription=@itemDescription,itemInStock=@itemInStock,itemPrice=@itemPrice WHERE Id=@Id";

            SqlCommand sqlCommand = new SqlCommand(null, base.conn);
            sqlCommand.CommandText = query;

            SqlParameter idParam = new SqlParameter("@Id", SqlDbType.Int, 0);
            SqlParameter itemNameParam = new SqlParameter("@itemName", SqlDbType.Text, 50);
            SqlParameter itemDescriptionParam = new SqlParameter("@itemDescription", SqlDbType.Text, 500);
            SqlParameter itemInStockParam = new SqlParameter("@itemInStock", SqlDbType.Int, 0);
            SqlParameter itemPriceParam = new SqlParameter("@itemPrice", SqlDbType.Decimal, 10);

            idParam.Value = merch.Id;
            itemNameParam.Value = merch.itemName;
            itemDescriptionParam.Value = merch.itemDescription;
            itemInStockParam.Value = merch.itemInStock;
            itemPriceParam.Value = merch.itemPrice;


            sqlCommand.Parameters.Add(idParam);
            sqlCommand.Parameters.Add(itemNameParam);
            sqlCommand.Parameters.Add(itemDescriptionParam);
            sqlCommand.Parameters.Add(itemInStockParam);
            sqlCommand.Parameters.Add(itemPriceParam);


            sqlCommand.Parameters["@itemPrice"].Precision = 10;
            sqlCommand.Parameters["@itemPrice"].Scale = 2;


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
}

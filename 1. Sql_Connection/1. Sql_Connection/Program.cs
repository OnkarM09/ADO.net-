using Microsoft.Data.SqlClient;  //Data provider for SQL Server
using System.Data;
namespace _1._Sql_Connection 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program.GetConnection();
        }


        public static void GetConnection()
        {
            string connectionString = "Data Source=LAPTOP-01OFR6OL; Initial Catalog=ado_db; Integrated Security=true; Encrypt=false;";

            //SqlConnection connection = new SqlConnection(connectionString);
            SqlConnection? connection = null;
            try
            {

                //Using block (Automatic closse the connection)
                using (connection = new SqlConnection(connectionString))
                { 
                    string query = "spGetEthanHunt";  //Stored Procedure (spGetEthanHunt, spGetEmployees)
                    //SqlCommand cmd = new SqlCommand(query, connection);
                    SqlCommand cmd = new SqlCommand(); //Create a new command object without constructor params
                    cmd.CommandText = query; //Set the command text
                    cmd.Connection = connection; //Set the connection for the command
                    cmd.CommandType = CommandType.StoredProcedure; //Set the command type to StoredProcedure

                    connection.Open(); //Open the connection

                    if (connection.State == ConnectionState.Open)
                    {
                        Console.WriteLine("Connection is open");
                        SqlDataReader dataReader = cmd.ExecuteReader();
                        while (dataReader.Read()) { 
                            Console.WriteLine("ID: " + dataReader["id"] + ", Name: " + dataReader["name"] + ", Gender: " + dataReader["gender"]+ ", City: " + dataReader["city"]);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection?.Close();
                Console.WriteLine("Connection is closed now");
            }


        }
    }
}

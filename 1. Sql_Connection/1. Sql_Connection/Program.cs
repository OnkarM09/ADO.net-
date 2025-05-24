using Microsoft.Data.SqlClient;
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

            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();
            if (connection.State == ConnectionState.Open)
            {
                Console.WriteLine("Connection is open");
            }
            connection.Close();
            Console.WriteLine("Connection is closed now");
        }
    }
}

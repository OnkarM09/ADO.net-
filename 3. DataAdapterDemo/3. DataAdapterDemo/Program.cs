using Microsoft.Data.SqlClient;
using Microsoft.Data;
using System.Data;

namespace _3._DataAdapterDemo
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
           
            string query = "select * from test_employee_table";
           
            SqlDataAdapter sda = new SqlDataAdapter(query, connection);

            DataSet ds = new DataSet();

            //Explaination of below code
            //sda will get all the rows from the table and fill it into the dataset ds using .Fill()
            //Fill method will open connection, get the data, store the data and close the connection
            sda.Fill(ds);

            //DataRow will read all the row one by one from dataset
            foreach(DataRow row in ds.Tables[0].Rows) // ds.Tables["test_employee_table)
            {
                Console.WriteLine($"{row["id"]} {row["name"]} {row["gender"]} {row["city"]}");
            }
        }
    }
}

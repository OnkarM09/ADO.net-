using Microsoft.Data.SqlClient;
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
            //Console.WriteLine("Enter id to get employee details: ");
            //int id = Convert.ToInt32(Console.ReadLine());

            string connectionString = "Data Source=LAPTOP-01OFR6OL; Initial Catalog=ado_db; Integrated Security=true; Encrypt=false;";
            SqlConnection connection = new SqlConnection(connectionString);

            DataTableIntro(connection);

            //string query = "select * from test_employee_table";
            string query = "spGetEthanHunt"; //Stored Procedure

            //SqlDataAdapter sda = new SqlDataAdapter(query, connection);
            //Option method for SqlDataAdapter 
            //SqlDataAdapter sda = new SqlDataAdapter();
            //sda.SelectCommand = new SqlCommand(query, connection); //Set the command to the adapter
            //sda.SelectCommand.CommandType = CommandType.StoredProcedure; //Set command type to Stored Procedure
            //sda.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = id; //Add parameter to the command

            //DataSet ds = new DataSet();

            //Explaination of below code
            //sda will get all the rows from the table and fill it into the dataset ds using .Fill()
            //Fill method will open connection, get the data, store the data and close the connection
            //sda.Fill(ds);

            ////DataRow will read all the row one by one from dataset
            //foreach (DataRow row in ds.Tables[0].Rows) // ds.Tables["test_employee_table)
            //{
            //    Console.WriteLine($"{row["id"]} {row["name"]} {row["gender"]} {row["city"]}");
            //}

            //Console.WriteLine("--------- New Data ---------");

            //Using Data table
            //DataTable dt = new DataTable();
            //sda.Fill(dt);
            //foreach(DataRow row in dt.Rows)
            //{
            //    Console.WriteLine($"{row["id"]} {row["name"]} {row["gender"]} {row["city"]}");
            //}
        }

        public static void DataTableIntro(SqlConnection connection)
        {
            string query = "select * from test_employee_table";
            SqlDataAdapter sda = new SqlDataAdapter(query, connection);
            DataTable employees = new DataTable();
            sda.Fill(employees);

            Console.WriteLine("DataTable Contents:");
            foreach (DataRow row in employees.Rows)
            {
                Console.WriteLine($"{row["id"]} {row["name"]} {row["gender"]} {row["city"]}");
            }
            Console.WriteLine("--------- New Data ---------");
            Console.WriteLine("Copied Data Table Contents:");
            DataTable copiedEmployees = employees.Copy();  // Create a copy of the DataTable
            foreach (DataRow row in copiedEmployees.Rows)
            {
                Console.WriteLine($"{row["id"]} {row["name"]} {row["gender"]} {row["city"]}");
            }

            Console.WriteLine("--------- New Data ---------");
            DataTable clonedTable = employees.Clone(); // Create a clone of the DataTable structure (Not the values);
            Console.WriteLine("Cloned Data Table Structure:", clonedTable);
            foreach (DataColumn column in clonedTable.Columns)
            {
                Console.WriteLine($"{column.ColumnName} {column.DataType}");
            }
            Console.WriteLine("--------- New Data ---------");
            if (clonedTable.Rows.Count > 0) {
                foreach (DataRow row in clonedTable.Rows)
                {
                    Console.WriteLine(row["id"] + " " + row["name"]);
                }
            }
            else
            {
                Console.WriteLine("No rows in cloned table to display.");   
            }
        }
    } 
}

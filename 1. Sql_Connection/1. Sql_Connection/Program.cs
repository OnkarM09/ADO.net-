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
                    //-------------Execute Query------------ 
                    //string query = "spGetEthanHunt";  //Stored Procedure (spGetEthanHunt, spGetEmployees)
                    ////SqlCommand cmd = new SqlCommand(query, connection);
                    //SqlCommand cmd = new SqlCommand(); //Create a new command object without constructor params
                    //cmd.CommandText = query; //Set the command text
                    //cmd.Connection = connection; //Set the connection for the command
                    //cmd.CommandType = CommandType.StoredProcedure; //Set the command type to StoredProcedure

                    //connection.Open(); //Open the connection

                    //if (connection.State == ConnectionState.Open)
                    //{
                    //    Console.WriteLine("Connection is open");
                    //    SqlDataReader dataReader = cmd.ExecuteReader();
                    //    while (dataReader.Read()) { 
                    //        Console.WriteLine("ID: " + dataReader["id"] + ", Name: " + dataReader["name"] + ", Gender: " + dataReader["gender"]+ ", City: " + dataReader["city"]);
                    //    }
                    //}


                    //-------------Execute non query------------ 
                    //string query = "insert into test_employee_table values(@id,@name, @gender, @age, @salary, @city)";
                    //SqlCommand cmd = new SqlCommand(query, connection);

                    //Console.WriteLine("Enter employee id: ");
                    //int id = Convert.ToInt32(Console.ReadLine());
                    //Console.WriteLine("Enter employee name: ");
                    //string? name = Console.ReadLine();
                    //Console.WriteLine("Enter employee gender: ");
                    //string? gender = Console.ReadLine();
                    //Console.WriteLine("Enter employee age: ");
                    //int age = Convert.ToInt32(Console.ReadLine());
                    //Console.WriteLine("Enter employee salary: ");
                    //int salary = Convert.ToInt32(Console.ReadLine());
                    //Console.WriteLine("Enter employee city: ");
                    //string? city = Console.ReadLine();


                    //cmd.Parameters.AddWithValue("@id", id);
                    //cmd.Parameters.AddWithValue("@name", name);
                    //cmd.Parameters.AddWithValue("@gender", gender);
                    //cmd.Parameters.AddWithValue("@age", age);
                    //cmd.Parameters.AddWithValue("@salary", salary);
                    //cmd.Parameters.AddWithValue("@city", city);

                    //Add the db values using common method
                    //SqlCommand cmd  = UdpateTableValues(connection, false); //false for add operation

                    //Update the db values
                    //SqlCommand cmd = UdpateTableValues(connection);

                    //Delete the db values
                    //SqlCommand cmd = DeleteTableRow(connection);


                    //Using aggregate function
                    SqlCommand cmd = GetMaxSalary(connection);


                    connection.Open(); //Open the connection
                    //int rowsAffected = cmd.ExecuteNonQuery();  //Return the number of rows affected

                    int maxSalary = (int)cmd.ExecuteScalar(); //ExecuteScalar returns the first column of the first row in the result set
                    Console.WriteLine("Max Salary: " + maxSalary);
                    //if (rowsAffected > 0)
                    //{
                    //    Console.WriteLine("Data inserted successfully");
                    //}
                    //else
                    //{
                    //    Console.WriteLine("Data insertion failed");
                    //}
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

        public static SqlCommand UdpateTableValues(SqlConnection connection, bool isUpdate = true)
        {
            Console.WriteLine("Enter employee id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter employee name: ");
            string? name = Console.ReadLine();
            Console.WriteLine("Enter employee gender: ");
            string? gender = Console.ReadLine();
            Console.WriteLine("Enter employee age: ");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter employee salary: ");
            int salary = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter employee city: ");
            string? city = Console.ReadLine();

            string addUpdate = isUpdate
                ? "update test_employee_table set name= @name, gender = @gender, age = @age, salary = @salary, city = @city where id = @id"
                : "insert into test_employee_table values(@id,@name, @gender, @age, @salary, @city)";
            string query = addUpdate;
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@gender", gender);
            cmd.Parameters.AddWithValue("@age", age);
            cmd.Parameters.AddWithValue("@salary", salary);
            cmd.Parameters.AddWithValue("@city", city);

            return cmd;
        }

        public static SqlCommand DeleteTableRow(SqlConnection connection) {
            Console.Write("Enter id to delete: ");
            int id = Convert.ToInt32(Console.ReadLine());
            string query = "delete from test_employee_table where id = @id";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@id", id);
            return cmd;
        }

        public static SqlCommand GetMaxSalary(SqlConnection connection) {
            //using max() aggregate function 
            string query = "select max(salary) from test_employee_table";
            SqlCommand cmd = new SqlCommand(query, connection);
            return cmd;
        }

    }
}

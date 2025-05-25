using Microsoft.Data.SqlClient;

namespace SqlDataReaderDemo
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
            SqlConnection? connection = null;
            try
            {
                using (connection = new SqlConnection(connectionString))
                {
                    string query = "select * from test_employee_table";

                    // For multiple result sets, we will add multiple select statements

                    //string query = "select * from test_employee_table; select * from movies_table";
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(query, connection);

                    SqlDataReader dr = cmd.ExecuteReader();

                    //Console.WriteLine(dr.FieldCount); //Column count of the table
                    //Console.WriteLine(dr.HasRows); //If the result has more than 1 or 1 rows
                    //Console.WriteLine(dr.IsClosed); //Is sqldatareader closed

                    while (dr.Read())
                    {
                        //Console.WriteLine($"{dr["id"]} {dr["name"]} {dr["gender"]} {dr["age"]} {dr["salary"]} {dr["city"]}");

                        //Using column index
                        Console.WriteLine($"{dr[0]} {dr[1]} {dr[2]} {dr[3]} {dr[4]} {dr[5]}");
                    }

                    if (dr.NextResult())
                    {

                        Console.WriteLine("----------------next result set-------------------");

                        while (dr.Read())
                        {
                            //Console.WriteLine($"{dr["id"]} {dr["name"]} {dr["gender"]} {dr["age"]} {dr["salary"]} {dr["city"]}");

                            //Using column index
                            Console.WriteLine($"{dr[0]} {dr[1]} {dr[2]}");
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error: ", ex);
            }
            finally
            {
                connection?.Close();
            }
        }
    }
}

using System.Data;

namespace _4._DataTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DataTable employees = new DataTable("employees");

                //DataColumn id = new DataColumn("id");
                //id.Caption = "Emp_Id";   //Changed the name of id column
                //id.DataType = System.Type.GetType("System.Int32");
                //id.AllowDBNull = false;

                //Another way to create DataColumn with properties set
                DataColumn id = new DataColumn("id")
                {
                    Caption = "Emp_Id", // Changed the name of id column
                    DataType = typeof(int),
                    AllowDBNull = false,
                    AutoIncrement = true,
                    AutoIncrementSeed = 1, // Start from 1
                    AutoIncrementStep = 1 // Increment by 1
                };

                DataColumn name = new DataColumn("name");
                name.Caption = "Emp_Name";
                name.DataType = typeof(string);
                name.AllowDBNull = false;
                name.MaxLength = 50; // Set maximum length for the name column
                name.DefaultValue = "Unknown"; // Set a default value for the name column
                name.Unique = true; // Ensure that names are unique

                DataColumn gender = new DataColumn("gender");
                gender.Caption = "Emp_Gender";
                gender.DataType = typeof(string);
                gender.AllowDBNull = false;
                gender.MaxLength = 10;

                employees.Columns.Add(id);
                employees.Columns.Add(name);
                employees.Columns.Add(gender);


                //Inserting rows into the DataTable
                DataRow row1 = employees.NewRow();
                //row1["id"] = 1;
                row1["name"] = "Tony Stark";
                row1["gender"] = "Male";

                employees.Rows.Add(row1);
                //Another way to add a row
                employees.Rows.Add(null, null, "Male");
                employees.Rows.Add(null, "Natasha", "Female");

                employees.PrimaryKey = new DataColumn[] { id };

                foreach (DataRow row in employees.Rows)
                {
                    Console.WriteLine($"{row[0]} {row[1]} {row[2]}");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}

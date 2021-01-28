using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day08SimpleDatabase
{
    class Program
    {
        const string ConnString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Documents\2020-ipd23-dotnet\Day08SimpleDatabase\SimpleDb.mdf;Integrated Security=True;Connect Timeout=30";

        static void Main(string[] args)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConnString);
                conn.Open();  //SQL Exception

                Random random = new Random();

                {  //insert
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO People(Name, Age) VALUES (@Name, @Age)", conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", "Jerry" + random.Next());
                        cmd.Parameters.AddWithValue("@Age", random.Next(1, 100));
                        cmd.ExecuteNonQuery(); //SQLException IO exception
                    }
                }

                { //select
                    using(SqlCommand cmd = new SqlCommand("SELECT * FROM People", conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // int id = (int)reader["Id"];
                            // int id = reader.GetInt32(0);
                            int id = reader.GetInt32(reader.GetOrdinal("Id"));
                            string name = reader.GetString(reader.GetOrdinal("Name"));
                            int age = reader.GetInt32(reader.GetOrdinal("Age"));
                            Console.WriteLine("{0}: {1} is {2} y/o", id, name, age);
                        }
                    }
                }

                { //select specific record
                    int wantId = 3;
                    Console.WriteLine("Looking for record with Id = " + wantId);
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM People WHERE Id = @Id", conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", wantId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // int id = (int)reader["Id"];
                                // int id = reader.GetInt32(0);
                                int id = reader.GetInt32(reader.GetOrdinal("Id"));
                                string name = reader.GetString(reader.GetOrdinal("Name"));
                                int age = reader.GetInt32(reader.GetOrdinal("Age"));
                                Console.WriteLine("{0}: {1} is {2} y/o", id, name, age);
                            }
                            else
                            {
                                Console.WriteLine("Record not found");
                            }
                        }
                    }
                }
            }
            catch(SqlException ex)
            {
                Console.WriteLine("SqlException: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Press any key");
                Console.ReadKey();
            }
        }
    }
}

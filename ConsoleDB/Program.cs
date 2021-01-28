using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDB
{
    public class Database
    {
        /* CONNECTING TO DATABASE */

        // 1. Connection string

        const string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Documents\2020-ipd23-dotnet\ConsoleDB\DogDb.mdf;Integrated Security=True;Connect Timeout=30";

        SqlConnection conn;

        public Database()
        {
            // 2. SqlConnection conn with connString
            conn = new SqlConnection(connString);
            // 3. Open connection
            conn.Open(); //sql Exception
        }

        /* GET ALL RECORDS FROM DATABASE */
        public List<Dog> GetAllDogs() // ex
        {
            List<Dog> list = new List<Dog>();

            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Dogs", conn))
            using (SqlDataReader reader = cmd.ExecuteReader()) // ex
            {
                while (reader.Read())
                {
                    list.Add(new Dog(reader)); // ex
                }
            }

            return list;
        }

        //UPDATE
        public void UpdateDog(Dog dog)
        {
            using (SqlCommand cmd = new SqlCommand("UPDATE Dogs SET Name = @Name, Age = @Age WHERE Id = @Id", conn))
            {
                cmd.Parameters.AddWithValue("@Name", dog.name);
                cmd.Parameters.AddWithValue("@Age", dog.age);
                cmd.Parameters.AddWithValue("@Id", dog.id);
                cmd.ExecuteNonQuery(); //SQLException IO exception
            }
        }

        //INSERT DATA TO DB
        public void AddDog(Dog dog)
        {

            using (SqlCommand cmd = new SqlCommand("INSERT INTO Dogs" +
                " (Name, Age)" +
                " VALUES (@Name, @Age)", conn))
            {
                cmd.Parameters.AddWithValue("@Name", dog.name);
                cmd.Parameters.AddWithValue("@Age", dog.age);
                cmd.ExecuteNonQuery(); //SQLException IO exception
            }
        }

        //DELETE
        public void DeleteDog(int id)
        {
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Dogs WHERE Id = @Id", conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery(); //SQLException IO exception
            }
        }
    }

    public class Dog
    {
        public int id;
        public string name;
        public int age;

        public Dog(int id, string name, int age)
        {
            this.id = id;
            this.name = name;
            this.age = age;
        }

        public Dog(SqlDataReader reader)
        {
            id = reader.GetInt32(reader.GetOrdinal("Id"));
            name = reader.GetString(reader.GetOrdinal("Name"));
            age = reader.GetInt32(reader.GetOrdinal("Age"));
        }
        public override string ToString()
        {
            return string.Format("{0}:{1} is {2} y/o", id, name, age);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Database db = null;
            try
            {

                try
                {
                    db = new Database();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error connection to database: " + ex.Message);
                }

                Console.Write("Inserting doggy: \n");
                Console.Write("Please enter name: ");
                string name = Console.ReadLine();
                Console.Write("Please enter age: ");
                int.TryParse(Console.ReadLine(), out int age);

                Dog dog = new Dog(0, name, age);

                try
                {
                    //insert in database
                    db.AddDog(dog);
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error adding to database: " + ex.Message);
                }
                catch (IOException ex)
                {
                    Console.WriteLine("Error adding to database: " + ex.Message);
                }

                var allDogs = new List<Dog>();
                try
                {
                    //get all from db
                    allDogs = db.GetAllDogs();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error adding to database: " + ex.Message);
                }
                catch (IOException ex)
                {
                    Console.WriteLine("Error adding to database: " + ex.Message);
                }


                Console.Write("Here all doggies: \n");
                foreach (Dog d in allDogs)
                {
                    Console.WriteLine(d);
                }

                Console.Write("We have to delete some doggies: \n");
                Console.Write("Enter dog's id to delete dog: ");

                int.TryParse(Console.ReadLine(), out int id);
                try
                {
                    //delete record by id
                    db.DeleteDog(id);
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error adding to database: " + ex.Message);
                }
                catch (IOException ex)
                {
                    Console.WriteLine("Error adding to database: " + ex.Message);
                }

                Console.Write("E tudo, look there is not more that cute doggy: \n" +
                    "");
                var Dogs = new List<Dog>();
                try
                {
                    //get all from db
                    Dogs = db.GetAllDogs();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error adding to database: " + ex.Message);
                }
                catch (IOException ex)
                {
                    Console.WriteLine("Error adding to database: " + ex.Message);
                }

                foreach (Dog d in Dogs)
                {
                    Console.WriteLine(d);
                }

                Console.Write("I think now it is time to update some dogs' records \n");
                Console.Write("Enter dog's id to update dog: ");
                
                int.TryParse(Console.ReadLine(), out int idToUpdate);

                var doggyToUpdate = (from d in Dogs
                                    where d.id == idToUpdate
                                    select d).ToList();

                Console.Write("Very nice, lets update: " + doggyToUpdate[0]+ "\n");
                Console.Write("Please enter new name for "+ doggyToUpdate[0].name + " : ");
                string nome = Console.ReadLine();
                Console.Write("Please enter age for " + doggyToUpdate[0].name + " : ");
                int.TryParse(Console.ReadLine(), out int idade);

                doggyToUpdate[0].name = nome;
                doggyToUpdate[0].age = idade;

                try
                {
                    //update
                    db.UpdateDog(doggyToUpdate[0]);
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error updating in database: " + ex.Message);
                }
                catch (IOException ex)
                {
                    Console.WriteLine("Error updating in database: " + ex.Message);
                }


                var Pups = new List<Dog>();
                try
                {
                    //get all from db
                    Pups = db.GetAllDogs();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error loading from database: " + ex.Message);
                }
                catch (IOException ex)
                {
                    Console.WriteLine("Error loading from database: " + ex.Message);
                }


                Console.Write("Caramba, now list of dogs looks like this: \n");
                foreach (Dog d in Pups)
                {
                    Console.WriteLine(d);
                }

            }
            finally
            {
                Console.WriteLine("Press any key");
                Console.ReadKey();
            }
        }
    }
}

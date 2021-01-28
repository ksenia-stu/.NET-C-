using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatsDb
{

    class Database
    {
        const string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Documents\2020-ipd23-dotnet\CatsDb\CatsDb.mdf;Integrated Security=True;Connect Timeout=30";

        SqlConnection conn;

        public Database()
        {
            conn = new SqlConnection(connString);
            conn.Open(); //sqlexception
        }

        //get all cats
        public List<Cat> GetAllCats()
        {
            List<Cat> list = new List<Cat>();

            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Cats", conn))
            using (SqlDataReader reader = cmd.ExecuteReader()) // ex
            {
                while (reader.Read())
                {
                    list.Add(new Cat(reader)); // SqlException, ArgumentException
                }
            }
            return list;
        }

        //get all owners with catId
        public List<Owner> GetAllOwnersWithCatId(int id)
        {
            List<Owner> list = new List<Owner>();

            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Owners WHERE CatId=@CatId", conn))
            {
                cmd.Parameters.AddWithValue("@CatId", id);
                using (SqlDataReader reader = cmd.ExecuteReader()) // ex
                {
                    while (reader.Read())
                    {
                        list.Add(new Owner(reader)); // SqlException, ArgumentException
                    }
                }
                return list;
            }
        }

        //add cat
        public int AddCat(Cat cat) // ex
        {
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Cats (Name, Age) OUTPUT INSERTED.ID VALUES (@Name, @Age);", conn))
            {
                cmd.Parameters.AddWithValue("@Name", cat.Name);
                cmd.Parameters.AddWithValue("@Age", cat.Age);
                int newId = (int)cmd.ExecuteScalar(); //ex
                return newId;
            }
        }

        //add owner
        public void AddOwner(Owner owner) // ex
        {
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Owners (FullName, CatId) VALUES (@FullName, @CatId);", conn))
            {
                cmd.Parameters.AddWithValue("@FullName", owner.FullName );
                cmd.Parameters.AddWithValue("@CatId", owner.CatId);
               cmd.ExecuteNonQuery(); //ex
              
            }
        }

        //update cat
        public void UpdateCat(Cat cat)
        {
            using (SqlCommand cmd = new SqlCommand("UPDATE Cats SET Name = @Name, Age = @Age WHERE Id=@Id", conn))
            {
                cmd.Parameters.AddWithValue("@Name", cat.Name);
                cmd.Parameters.AddWithValue("@Age", cat.Age);
                cmd.Parameters.AddWithValue("@Id", cat.Id);
                cmd.ExecuteNonQuery();
            }
        }

        //update owner
        public void UpdateOwner(Owner owner)
        {
            using (SqlCommand cmd = new SqlCommand("UPDATE Owners SET FullName = @FullName, CatId = @CatId WHERE Id=@Id", conn))
            {
                cmd.Parameters.AddWithValue("@FullName", owner.FullName);
                cmd.Parameters.AddWithValue("@CatId", owner.CatId);
                cmd.Parameters.AddWithValue("@Id", owner.Id);
                cmd.ExecuteNonQuery();
            }
        }

        //delete cat
        public void DeleteCat(int id)
        {
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Cats WHERE Id=@Id", conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }

        //delete owner
        public void DeleteOwner(int id)
        {
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Owners WHERE Id=@Id", conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksDb
{
    public class Database
    {
        string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Documents\2020-ipd23-dotnet\BooksDb\BooksDatabase.mdf;Integrated Security=True;Connect Timeout=30";

        SqlConnection conn;

        public Database()
        {
            conn = new SqlConnection(connString);
            conn.Open();  //sql ex
        }

        //get all books
        public List<Book> GetAllBooks()
        {
            List<Book> list = new List<Book>();

            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Books", conn))
            using (SqlDataReader reader = cmd.ExecuteReader()) // sql ex, IO ex
            {
                while (reader.Read())
                {
                    list.Add(new Book(reader)); // SqlException, ArgumentException
                }
            }
            return list;
        }

        //add book
        public int AddBook(Book book) // ex
        {
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Books (Title, Isbn, PubDate, Cover) OUTPUT INSERTED.ID VALUES (@Title, @Isbn, @PubDate,@Cover);", conn))
            {
                cmd.Parameters.AddWithValue("@Title", book.Title);
                cmd.Parameters.AddWithValue("@Isbn", book.Isbn);
                cmd.Parameters.AddWithValue("@PubDate", book.PubDate);
                cmd.Parameters.AddWithValue("@Cover", book.Cover);
                int newId = (int)cmd.ExecuteScalar(); //ex
                return newId;
            }
        }
    }
}

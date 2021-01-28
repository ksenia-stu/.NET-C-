using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksDb
{
    public class Author
    {
        public int Id { get; set; }
        string _name;
        int _bookId;

        public Author(int id, string name, int bookId)
        {
            Id = id;
            Name = name;
            BookId = bookId;
        }

        public Author(SqlDataReader reader)
        {
            Id = reader.GetInt32(reader.GetOrdinal("Id"));
            Name = reader.GetString(reader.GetOrdinal("Name"));
            BookId = reader.GetInt32(reader.GetOrdinal("BookId"));
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value.Length < 1 || value.Length > 100)
                {
                    throw new ArgumentException("Name should be between 1 and 100 characters");
                }
                _name = value;
            }
        }

        public int BookId
        {
            get
            {
                return _bookId;
            }
            set
            {
                
                _bookId = value;
            }
        }
    }
}

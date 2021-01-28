using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksDb
{
    public class Book
    {
        public int Id { get; set; }
        string _title;
        string _isbn;
        DateTime _pubDate;
        byte[] _cover;

        public Book(int id, string title, string isbn, DateTime pubDate, byte [] cover)
        {
            Id = id;
            Title = title;
            Isbn = isbn;
            PubDate = pubDate;
            Cover = cover;
        }

        public Book(SqlDataReader reader)
        {
            Id = reader.GetInt32(reader.GetOrdinal("Id"));
            Title = reader.GetString(reader.GetOrdinal("Title"));
            Isbn = reader.GetString(reader.GetOrdinal("ISBN"));
            PubDate = reader.GetDateTime(reader.GetOrdinal("PubDate"));
            Cover = (byte[])reader["Cover"];
        }

        //title
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                if (value.Length < 1 || value.Length > 100)
                {
                    throw new ArgumentException("Title should be between 1 and 100 characters");
                }
                _title = value;
            }
        }

        //isbn
        public string Isbn
        {
            get
            {
                return _isbn;
            }
            set
            {
                if (value.Length != 13)
                {
                    throw new ArgumentException("Isbn should be between 13 uppercase characters");
                }
                _title = value.ToUpper();
            }
        }

        //pubdate
        public DateTime PubDate
        {
            get
            {
                return _pubDate;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Date cannot be null");
                }
                _pubDate = value;
            }
        }

        //cover
        public byte [] Cover
        {
            get
            {
                return _cover;
            }
            set
            {
                _cover = value;
            }
        }


    }
}

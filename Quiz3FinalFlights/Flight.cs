using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Quiz3FinalFlights
{
    public class Flight
    {
        public int Id { get; set; }
        private DateTime _date;
        private String _fromCode;
        private String _toCode;
        public TypeEnum Type { get; set; }
        private int _passengers;

       public enum TypeEnum{ Domestic, International, Private}

        public const string CodePattern = "[A-Z]{3,5}";


        public Flight(int id, DateTime date, string fromCode, string toCode, TypeEnum type, int passengers)
        {
            Id = id;
            Date = date;
            FromCode = fromCode;
            ToCode = toCode;
            Type = type;
            Passengers = passengers;
        }

        public Flight(SqlDataReader reader) // SqlException, ArgumentException,
        {
            Id = reader.GetInt32(reader.GetOrdinal("Id"));
            Date = reader.GetDateTime(reader.GetOrdinal("Date"));
            FromCode = reader.GetString(reader.GetOrdinal("FromCode"));
            ToCode = reader.GetString(reader.GetOrdinal("ToCode"));
            string typeStr = reader.GetString(reader.GetOrdinal("Type"));
            if (!Enum.TryParse<TypeEnum>(typeStr, out TypeEnum type))
            {
                throw new ArgumentException("Cannot parse Type");
            }
            Type = type;
            Passengers = reader.GetInt32(reader.GetOrdinal("Passengers"));
        }


        //date
        public DateTime Date
        {
            get
            {
                return _date;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Date cannot be null");
                }
                _date = value;
            }
        }

        //from code
        public string FromCode
        {
            get
            {
                return _fromCode;
            }
            set
            {
                if (!Regex.IsMatch(value, CodePattern))
                {
                    throw new ArgumentException("From code must be between 3-5 characters, uppercase only");
                }
                _fromCode = value;
            }
        }


        //to code
        public string ToCode
        {
            get
            {
                return _toCode;
            }
            set
            {
                if (!Regex.IsMatch(value, CodePattern))
                {
                    throw new ArgumentException("To code must be between 3-5 characters, uppercase only");
                }
                _toCode = value;
            }
        }

      

        //passengers
        public int Passengers
        {
            get
            {
                return _passengers;
            }
            set
            {
                if (value < 0 || value > 200)
                {
                    throw new ArgumentException("Number of passengers should be between 0 and 200");
                }
                _passengers = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0};{1};{2};{3};{4};{5}",Id, Date, FromCode, ToCode, Type, Passengers);
        }
    }
}

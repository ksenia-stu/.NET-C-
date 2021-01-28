using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatsDb
{
    public class Cat
    {
        public int Id { get; set; }
        string _name;
        int _age;

        public Cat(int id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }

        public Cat(SqlDataReader reader)
        {
            Id = reader.GetInt32(reader.GetOrdinal("Id"));
            Name = reader.GetString(reader.GetOrdinal("Name"));
            Age = reader.GetInt32(reader.GetOrdinal("Age"));
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value.Length < 3 || value.Length > 30)
                {
                    throw new ArgumentException("Name should be between 3 and 30 characters");
                }
                _name = value;
            }
        }

        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                if (value < 0 || value > 20)
                {
                    throw new ArgumentException("Age should be between 0 and 20");
                }
                _age = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}: {1} is {2} y/o", Id, Name, Age);
        }
    }
}

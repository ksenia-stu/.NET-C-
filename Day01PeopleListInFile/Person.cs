using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day01PeopleListInFile
{
    class Person
    {

        public Person(string name, int age, string city)
        {
            Name = name;
            Age = age;
            City = city;
        }

        private string _name; // name storage
        private int _age; //age storage
        private string _city; // city storage


        string NameCity_pattern = "[^;]{2,100}";


        //property Name
        public string Name  //no storage, just getter setter
        {
            get
            {
                return _name;
            }
            set
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(value, NameCity_pattern))
                {
                    throw new ArgumentException("Name must be between 2 and 100 characters long");
                }
                _name = value;
            }
        }

        //property age
        public int Age  //no storage, just getter setter
        {
            get
            {
                return _age;
            }
            set
            {
                if (value < 0 || value > 150)
                {
                    throw new ArgumentException("Age must be between 0 and 150");
                }
                _age = value;
            }
        }

        //property City
        public string City  //no storage, just getter setter
        {
            get
            {
                return _city;
            }
            set
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(value, NameCity_pattern))
                {
                    throw new ArgumentException("City must be between 2 and 100 characters long");
                }
                _city = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} is {1} from {2}", Name, Age, City);
        }

        public string ToDataString()
        {
            return string.Format("{0};{1};{2}", Name, Age, City);
        }
    }
}

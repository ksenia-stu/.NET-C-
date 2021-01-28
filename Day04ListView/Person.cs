using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day04ListView
{
    class Person
    {
        private string _name;
        private int _age;

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Name cannot be empty");
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
                if (value < 0 || value > 150)
                {
                    throw new ArgumentException("Age must be between 0 and 150");
                }
                _age = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} is {1} years old", Name, Age);
        }  
       
    }
}

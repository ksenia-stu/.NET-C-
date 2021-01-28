using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day01Cities
{

    class City
    {
        //methods and fields are private by default
        //internal means it is accessible within the same project (assembly)
        public string Name;
        public double PopulationMillions;

        public override string ToString()
        {
            return string.Format("City: {0} with {1} mil. population", Name, PopulationMillions);
        }
    }

    class BetterCity
    {

        public int Id; //field
        public string Name{ get; set; } //property with storage and default getter/setter

        private string _name2; //storage

        //property
        public string Name2  //no storage, just getter setter
        {
            get
            {
                return _name2;
            }
            set
            {
                if(value.Length <2)
                {
                    throw new InvalidOperationException("Name must be at least 2 characters");
                }
                _name2 = value;
            }
        }
    }

    class Program
    {
        static public List<City> CitiesList = new List<City>();

        static void Main(string[] args)
        {
            try
            {
                City c1 = new City();
                c1.Name = "Montreal";
                c1.PopulationMillions = 2.5;
                Console.WriteLine(c1);

                //object initializer, it is not a constructor
                City c2 = new City { Name = "Toronto", PopulationMillions = 4.5 };

                BetterCity bc1 = new BetterCity();
                bc1.Name = "Vancouver";
                bc1.Name2 = "VC"; //ex

                CitiesList.Add(new City { Name = "New York" });
                CitiesList.Add(new City { Name = "LA" });
                CitiesList.Add(new City { Name = "Recife" });

                foreach (City c in CitiesList)
                {
                    Console.WriteLine(c);
                }

            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Press any key");
                Console.ReadKey();
            }
            

        }
    }
}

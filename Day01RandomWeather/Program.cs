using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day01RandomWeather
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Random rnd = new Random();

                int randomNum = rnd.Next(-30, 31);
                Console.WriteLine(randomNum);

                if (randomNum <= -15)
                {
                    Console.WriteLine("Very very cold");
                }
                else if (randomNum > -15 && randomNum < 0)
                {
                    Console.WriteLine("Freezing already");
                }
                else if (randomNum >= 0 && randomNum <= 15)
                {
                    Console.WriteLine("Spring or Fall");
                }
                else
                {
                    Console.WriteLine("That's what I like");
                }
            }
            finally
            {
                Console.ReadKey();
            }
            
        }
    }
}

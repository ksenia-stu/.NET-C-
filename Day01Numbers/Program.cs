using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day01Numbers
{
    class Program
    {

        static List<int> numList = new List<int>();
        static void Main(string[] args)
        {

            /*Ask user how many numbers he/she wants to generate.
Generate the numbers as random integers in -100 to +100 range, both inclusive.
Place the numbers in List<int> named numList.

In a next loop find the numbers that are less or equal to 0 and print them out, one per line. */
            try
            {
                Console.Write("How many numbers would you like to generate: ");
                int num;
                int.TryParse(Console.ReadLine(), out num);

                Random rnd = new Random();

                for (int i = 0; i < 10; i++)
                {
                    int randNum = rnd.Next(-100, 101);
                    numList.Add(randNum);
                }

                foreach (int i in numList)
                {
                    if (i <= 0)
                    {
                        Console.WriteLine(i);
                    }
                }
            }
            finally
            {
                Console.ReadKey();
            }
            
        }
    }
}

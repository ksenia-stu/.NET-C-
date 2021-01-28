using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day18Indexer
{
    class Program
    {
        static void Main(string[] args)
        {
            PrimeArray pa = new PrimeArray();
            for (int i = 1; i < 10; i++)
            {
                Console.WriteLine(i + " : " + pa[i]);
            }
            Console.ReadKey();
        }
    }
}

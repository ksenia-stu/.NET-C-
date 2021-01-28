using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day01Cone
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("How big does your icecream cone needs to be: ");
                int n;
                int.TryParse(Console.ReadLine(), out n);


                //triangle
                /*      while(num >= 1)
                      {
                          for (int i = 0; i < num; i++)
                          {
                              Console.Write("*");
                              // Console.WriteLine();
                          }
                          Console.WriteLine();
                          num--;
                      } */

                //reverse triangle

                /*     for(int a =num; a>0; a--)
                     {
                         for (int i = num; i > 0; i--)
                         {
                             Console.Write("*");

                         }
                         Console.WriteLine();
                     for(int b=num; b>0; b--)
                     {
                         Console.Write(" ");
                     }

                     num--;
                     } */
                for (int i = 1; i <= n; i++)
                {
                    for (int j = 1; j < i; j++)
                    {
                        Console.Write(" ");
                    }
                    for (int j = 1; j <= (n * 2 - (i * 2 - 1)); j++)
                    {
                        Console.Write("*");
                    }
                    Console.WriteLine();
                }









            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}

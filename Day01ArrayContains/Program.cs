using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day01ArrayContains
{
    class Program
    {
        static public int[] Concatenate(int[] a1, int[] a2) 
        {
            int [] newArray = new int[a1.Length + a2.Length];
            a1.CopyTo(newArray, 0);
            a2.CopyTo(newArray, a1.Length);

            return newArray;
           

        }

        public static void PrintDups(int[] a1, int []a2)
        {
           //  int [] newArray = a1.Union(a2).ToArray();
            int length = a1.Length + a2.Length;
            foreach (int i in a2)
            {
                if(a1.Contains(i))
                {
                    length--;
                }
            }
            int[] newArray = new int[length];
            a1.CopyTo(newArray, 0);
            foreach (int i in a2)
            {
                if (!a1.Contains(i))
                {
                    try
                    {
                        a2.CopyTo(newArray, a1.Length - 1);
                    }
                    catch(ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    
                }
              
            }
            foreach(int i in newArray)
            {
                Console.Write(i + " ");
            }


        }


        public static int[] RemoveDups(int[] a1, int[] a2) 
        {
            /*Return a copy of a1, except elements that are also present in a2 are removed.
            Note: returned array must be of exactly the needed size, not larger. */
            int length = a1.Length;
            foreach (int i in a2)
            {
                if (a1.Contains(i))
                {
                    length--;
                }
            }
            Console.WriteLine(length);
            int[] newA1 = new int[length];
            foreach (int i in a1)
            {
                if (!a2.Contains(i))
                { 
                    for(int j=0; j< newA1.Length; j++)
                    {
                        newA1[j] = i;
                    }
                    
                }
            }
            return newA1;

        }



        static void Main(string[] args)
        {
            int[] a1 = { 2, 3, 5, 7, 3, 2 };
            int[] a2 = { 3, 9, 7 };

            PrintDups(a1, a2);


            int [] newArray = RemoveDups(a1, a2);

            foreach(int i in newArray)
            {
                Console.Write(i + " ");
            }

            Console.ReadKey();
        }
    }
}

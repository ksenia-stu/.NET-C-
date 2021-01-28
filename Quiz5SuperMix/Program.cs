using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz5SuperMix
{
    class Program
    {
        public const int MaxValue = 2147483647;
        static void Main(string[] args)
        {
            SuperFibs sf = new SuperFibs();
            for (int i = 1; i < 10; i++)
            {
                Console.WriteLine(i + " : " + sf[i]);
            }
            try
            {
                Console.WriteLine(sf[0]);
            }
            catch(IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }



            Console.WriteLine("1: {0}, steps {1}", sf[1], sf.StepsCount); // prints 1: 0, steps 0
            Console.WriteLine("2: {0}, steps {1}", sf[2], sf.StepsCount); // prints 2: 1, steps 0
            Console.WriteLine("3: {0}, steps {1}", sf[3], sf.StepsCount); // prints 3: 1, steps 0
            Console.WriteLine("5: {0}, steps {1}", sf[5], sf.StepsCount); // prints 5: 4, steps 2
            Console.WriteLine("9: {0}, steps {1}", sf[9], sf.StepsCount); // prints 9: 44, steps 4
            Console.WriteLine("7: {0}, steps {1}", sf[7], sf.StepsCount); // prints 7: 13, steps 0 (because it's already in the cache) 
            Console.WriteLine("9: {0}, steps {1}", sf[9], sf.StepsCount);

            //Prompt user to enter seconds
            float userTime;
            while (true)
            {
                Console.Write("Please enter number of seconds: ");
                
                try
                {
                    userTime = float.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Enter numbers only");
                }
            }

            var startTime = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds; //starting time point


            for (int i = 1; i < MaxValue; i++)
            {
               Console.WriteLine(i + " : " + sf[i]);
                if(((int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds - startTime) > userTime)
                {
                    Console.WriteLine(i + " numbers are generated in " + ((int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds - startTime) + " second(s)");
                    break;
                }
            }
            Console.ReadKey();


        }
    }
}

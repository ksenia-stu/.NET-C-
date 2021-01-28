using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz5SuperMix
{
    public class SuperFibs
    {
        private Dictionary<int, long> cache = new Dictionary<int, long> { { 1, 0 }, { 2, 1 }, { 3, 1 } };
        public int StepsCount;


        private long getNthFib(int n)
        {


            if (cache.ContainsKey(n))
            {
                return cache[n];
            }
            else
            {
                
                cache[n] = getNthFib(n - 1) + getNthFib(n - 2) + getNthFib(n - 3);
                StepsCount++;
                return (getNthFib(n - 1) + getNthFib(n - 2) + getNthFib(n - 3));
                
            }

        //without cache
        /*    if (n == 1)
            {
                return 0;
            }
            else if (n == 2)
            {
                return 1;
            }
            else if( n == 3)
            {
                return 1;
            }
            else
            {
                return getNthFib(n - 1) + getNthFib(n - 2) + getNthFib(n -3);
            } */
        }

        // indexer
        public long this[int index]
        {
            get
            {
                if (index < 1)
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    return getNthFib(index);
                }
            }

        }
    }
}

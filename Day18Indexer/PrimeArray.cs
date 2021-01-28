﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day18Indexer
{
    class PrimeArray
    {
        private bool IsPrime(long number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
                if (number % i == 0)
                    return false;

            return true;
        }


       

// indexer
public long this[int index]
        {
            get
            {
                long number = IsPrime(index)? 
                return IsPrime(index);
            }
            
        }
    }
}

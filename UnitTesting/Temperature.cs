using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting
{
    public class Temperature
    {
        public static double CelciusToFar(double cel)
        {
            if (cel < -273.15) throw new ArgumentOutOfRangeException();
            return cel * 9 / 5 + 32;
        }
    }
}

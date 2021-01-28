using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestingNUnit
{
    public class Reservation
    {
        public class User
        {
            public bool IsAdmin { get; set; }
        }

        public User MadeBy { get; set; }

        public bool CanBeCancelledBy(User user)
        {
            if(user.IsAdmin)
            {
                return true;
            }
            if(MadeBy == user)
            {
                return true;
            }
            return false;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}

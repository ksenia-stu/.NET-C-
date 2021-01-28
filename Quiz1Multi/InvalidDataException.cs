using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz1Multi
{
    class InvalidDataException : Exception
    {
        public InvalidDataException(string msg) : base(msg) { }
    }
}

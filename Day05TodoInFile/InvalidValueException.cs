﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day05TodoInFile
{
    class InvalidValueException : Exception
    {
        public InvalidValueException(string msg) : base(msg) { }
    }
}

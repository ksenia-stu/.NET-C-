using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTesting.Test
{
    [TestClass]
    class TempTests
    {
        [TestMethod]
        public void CellToFahMany()
        {
            Assert.AreEqual(Temperature.CelciusToFar(0), 32, 0.00001, "Conversion error 0 -> 32");

            //just call to amek sure that it does not throw an exception
            Temperature.CelciusToFar(-273.15);
        }

        [TestMethod]
         [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CellBelowAbsoluteZero()
        {
          
                //should throw exception
                Temperature.CelciusToFar(-274);
                Assert.Fail("Exception must be thrown");
           
        }
    }
}

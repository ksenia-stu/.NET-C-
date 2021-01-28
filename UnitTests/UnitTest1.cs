using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        Quiz5SuperMix.SuperFibs sf;

        [TestInitialize]
        public void TestInitialize()
        {
            sf = new Quiz5SuperMix.SuperFibs();
        }

        [TestMethod]
        [Timeout(5000)]
        public void NthSuperFibNumbers()
        {
            Assert.AreEqual(sf[1], 0, 0.00001, "1st super fib num error ");
            Assert.AreEqual(sf[2], 1, 0.00001, "2nd super fib num error ");
            Assert.AreEqual(sf[3], 1, 0.00001, "3rd super fib num error ");
            Assert.AreEqual(sf[7], 13, 0.00001, "7th super fib num error ");
            Assert.AreEqual(sf[10], 81, 0.00001, "10th super fib num error ");
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void IndexBelowOne()
        {
            Console.WriteLine(sf[0]);  //exception
            Assert.Fail("Exception must be thrown");
        }
    }
}

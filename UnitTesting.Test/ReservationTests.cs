using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestingNUnit.Test
{
    [TestClass]
    public class ReservationTests
    {
        Reservation reservation;

        [TestInitialize]
        public void TestInitialize()
        {
            reservation = new Reservation();
        }

        [TestMethod]
        public void CanBeCancelledBy_UserIsAdmin_ReturnsTrue()
        {
            //arrange
           // var reservation = new Reservation();

            //act
            var result = reservation.CanBeCancelledBy(new Reservation.User { IsAdmin = true });

            //assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CanBeCancelledBy_UserWhoMadeReservation_ReturnsTrue()
        {
            //arrange

           // var reservation = new Reservation();
            Reservation.User user = new Reservation.User { IsAdmin = false };
            reservation.MadeBy = user;

            //act
            var result = reservation.CanBeCancelledBy(user);

            //assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CanBeCancelledBy_NotUserWhoMadeReservationNotAdmin_ReturnsFalse()
        {
            //arrange

          //  var reservation = new Reservation();
            Reservation.User user = new Reservation.User { IsAdmin = false };
            reservation.MadeBy = null;

            //act
            var result = reservation.CanBeCancelledBy(user);

            //assert
            Assert.IsFalse(result);
        }
    }
}

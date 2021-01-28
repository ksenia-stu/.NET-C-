
using NUnit.Framework;
using System;

namespace UnitTestingNUnit
{
    [TestFixture]
    public class ReservationTests
    {
        [Test]
        public void CanBeCancelledBy_UserIsAdmin_ReturnsTrue()
        {
            //arrange
            var reservation = new Reservation();

            //act
            var result = reservation.CanBeCancelledBy(new Reservation.User { IsAdmin = true });

            //assert
            Assert.IsTrue(result);
        }

        [Test]
        public void CanBeCancelledBy_UserWhoMadeReservation_ReturnsTrue()
        {
            //arrange

            var reservation = new Reservation();
            Reservation.User user = new Reservation.User { IsAdmin = false };
            reservation.MadeBy = user;

            //act
            var result = reservation.CanBeCancelledBy(user);

            //assert
          //  Assert.IsTrue(result);
          //  Assert.That(result, Is.True);
            Assert.That(result == true);
        }

        [Test]
        public void CanBeCancelledBy_NotUserWhoMadeReservationNotAdmin_ReturnsFalse()
        {
            //arrange

            var reservation = new Reservation();
            Reservation.User user = new Reservation.User { IsAdmin = false };
            reservation.MadeBy = null;

            //act
            var result = reservation.CanBeCancelledBy(user);

            //assert
            Assert.IsFalse(result);
        }
    }
}

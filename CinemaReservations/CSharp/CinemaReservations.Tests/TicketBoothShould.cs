using CinemaReservations.Tests.StubMovieScreening;
using External.AuditoriumLayout;
using NFluent;
using NUnit.Framework;

namespace CinemaReservations.Tests
{
    [TestFixture]
    public class TicketBoothShould
    {
        [Test]
        public void Reserve_one_seat_when_available()
        {
            const string showId = "1";
            const int partyRequested = 1;

            // Leaving this here as reference on how to use the provided testing frameworks.
            // Feel free to use your personal favorite
            
            // Check.That(XXX).HasSize(1);
            // Check.That(XXX).IsEqualTo("A3");
        }

        [Test]
        public void Return_SeatsNotAvailable_when_all_seats_are_unavailable()
        {
            const string showId = "5";
            const int partyRequested = 1;
        }

    }
}
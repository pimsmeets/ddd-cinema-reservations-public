using CinemaReservations.Tests.StubMovieScreening;
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

            IMovieScreeningRepsitory repository =  new StubMovieScreeningRepository();
            MovieScreening screening = repository.FindMovieScreeningById(showId);

            var seatsReserved = screening.reserveSeats(new ReserveSeats(showId, partyRequested));

            Check.That(seatsReserved.ReservedSeats).HasSize(1);
            Check.That(seatsReserved.ReservedSeats[0].ToString()).IsEqualTo("A3");
        }

        [Test]
        public void Return_SeatsNotAvailable_when_all_seats_are_unavailable()
        {
            const string showId = "5";
            const int partyRequested = 1;

            IMovieScreeningRepsitory repository =  new StubMovieScreeningRepository();
            MovieScreening screening = repository.FindMovieScreeningById(showId);

            var seatsReserved = screening.reserveSeats(new ReserveSeats(showId, partyRequested));

            Check.That(seatsReserved.ReservedSeats).HasSize(0);
            Check.That(seatsReserved).IsInstanceOf<ReservationNotAvailable>();
        }

    }
}
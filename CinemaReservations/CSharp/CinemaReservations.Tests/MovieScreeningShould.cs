using CinemaReservations.Tests.StubMovieScreening;
using CinemaReservations.Domain;
using External.AuditoriumLayout;
using NFluent;
using NUnit.Framework;

namespace CinemaReservations.Tests
{
  [TestFixture]
  public class MovieScreeningShould
  {
    [Test]
    public void Allocate_exactly_five_seats_when_they_are_available()
    {
      const string showId = "2";
      const int partyRequested = 5;

      IMovieScreeningRepository repository =  new StubMovieScreeningRepository(new StubAuditoriumRepository());
      MovieScreening movieScreening = repository.FindMovieScreeningById(showId);
      SeatsAllocated seatsAllocated = movieScreening.allocateSeats(new AllocateSeats(showId, partyRequested));

      Check.That(seatsAllocated.ReservedSeats.Count).IsEqualTo(partyRequested);
    }

    [Test]
    public void Allocate_nothing_when_not_enough_seats_available()
    {
      const string showId = "1";
      const int partyRequested = 5;

      IMovieScreeningRepository repository =  new StubMovieScreeningRepository(new StubAuditoriumRepository());
      MovieScreening movieScreening = repository.FindMovieScreeningById(showId);
      SeatsAllocated seatsAllocated = movieScreening.allocateSeats(new AllocateSeats(showId, partyRequested));

      Check.That(seatsAllocated.ReservedSeats.Count).IsEqualTo(0);
    }
  }
}

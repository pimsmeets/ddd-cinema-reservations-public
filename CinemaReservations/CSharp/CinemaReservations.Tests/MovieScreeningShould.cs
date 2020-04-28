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
    public void Return_seatmap_for_specific_screening()
    {
      const string showId = "1";
      IMovieScreeningRepository repository =  new StubMovieScreeningRepository(new StubAuditoriumRepository());

      MovieScreening movieScreening = repository.FindMovieScreeningById(showId);
      Check.That(movieScreening.Rows).Not.IsEmpty();
    }
  }
}

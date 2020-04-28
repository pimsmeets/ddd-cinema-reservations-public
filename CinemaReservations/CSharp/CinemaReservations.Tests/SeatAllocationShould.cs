using CinemaReservations.Tests.StubMovieScreening;
using CinemaReservations.Domain;
using External.AuditoriumLayout;
using NFluent;
using NUnit.Framework;

namespace CinemaReservations.Tests
{
  [TestFixture]
  public class SeatAllocationShould
  {
    [Test]
    public void Update_the_allocated_seats_map_when_adding_one_seat()
    {
      const int partyRequested = 1;
      SeatAllocation seatAllocation = new SeatAllocation(partyRequested);
      seatAllocation.AddSeat(new Seat("A1", 1, SeatAvailability.Available));

      Check.That(seatAllocation.AllocatedSeats[0].RowName).IsEqualTo("A1");
      Check.That(seatAllocation.AllocatedSeats[0].IsAvailable).IsEqualTo(false);
    }
  }
}

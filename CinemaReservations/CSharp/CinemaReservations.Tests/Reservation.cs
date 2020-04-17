using System.Collections.Generic;

namespace CinemaReservations.Tests {
    public class Reservation {

        public int PartyRequested { get; }
        public List<Seat> ReservedSeats { get; set; } = new List<Seat>();
        public bool IsFulfilled => ReservedSeats.Count == PartyRequested;
        public Reservation(int partyRequested)
        {
            this.PartyRequested = partyRequested;
        }
        public void AddSeat(Seat seat)
        {
            seat.UpdateAvailability(SeatAvailability.Reserved);
            ReservedSeats.Add(seat);
        }
    }
}
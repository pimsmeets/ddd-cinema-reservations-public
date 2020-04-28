using System;
using System.Collections.Generic;

namespace CinemaReservations.Domain {
    public class SeatAllocation {

        public int PartyRequested { get; }
        public List<Seat> AllocatedSeats { get; set; } = new List<Seat>();
        public bool IsFulfilled => AllocatedSeats.Count == PartyRequested;
        public SeatAllocation(int partyRequested)
        {
            this.PartyRequested = partyRequested;
        }
        public void AddSeat(Seat seat)
        {
          /* This function updates the value object AllocatedSeats
           * It adds 'seat' and updates the status of the seat
           */
          throw new NotImplementedException();
        }
    }
}

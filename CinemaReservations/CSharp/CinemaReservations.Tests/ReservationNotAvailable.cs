using System.Collections.Generic;

namespace CinemaReservations.Tests {

    public class ReservationNotAvailable : SeatsReserved
    {
        public ReservationNotAvailable(int partyRequested) : base(partyRequested, new List<Seat>())
        {
        }
    }
}
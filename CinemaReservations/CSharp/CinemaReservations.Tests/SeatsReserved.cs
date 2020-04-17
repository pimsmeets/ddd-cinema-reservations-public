using System.Collections.Generic;

namespace CinemaReservations.Tests {
    public class SeatsReserved 
    {
        public int PartyRequested { get; }
        public List<Seat> ReservedSeats { get; }
        public SeatsReserved(int partyRequested, List<Seat> reservedSeats)
        {
            PartyRequested = partyRequested;
            ReservedSeats = reservedSeats;
        }
    }
}
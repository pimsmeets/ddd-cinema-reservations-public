using System.Collections.Generic;

namespace CinemaReservations.Tests {

    public class NoPossibleAllocationsFound : SeatsAllocated
    {
        public NoPossibleAllocationsFound(int partyRequested) : base(partyRequested, new List<Seat>())
        {
        }
    }
}
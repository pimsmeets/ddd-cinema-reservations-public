using System;
using System.Collections.Generic;

namespace CinemaReservations.Domain
{
    public class MovieScreening  {
        public readonly Dictionary<string, Row> Rows;
        public MovieScreening(Dictionary<String, Row> rows) {
            Rows = rows;
        }
        public SeatsAllocated allocateSeats(AllocateSeats allocateSeats)
        {
          var allocation = new SeatAllocation(allocateSeats.PartyRequested);

          /*
           * allocateSeats is called by TicketBooth, it's function is to:
           * - Iterate through all rows for a certain movie
           * - Iterate through each seat in those rows
           * - Check if the seats are available and assign the seats to the allocation if they are
           *
           * Possible return values:
           * - SeatsAllocated object
           * - NoPossibleAllocationsFound object
           */
          
          throw new NotImplementedException();

        }
    }
}

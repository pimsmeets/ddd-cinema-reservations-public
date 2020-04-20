using System;
using System.Collections.Generic;

namespace CinemaReservations.Tests 
{    
    public class MovieScreening  {
        public readonly Dictionary<string, Row> Rows;
        public MovieScreening(Dictionary<String, Row> rows) {
            Rows = rows;
        }
        public SeatsAllocated allocateSeats(AllocateSeats allocateSeats)
        {
            var allocation = new SeatAllocation(allocateSeats.PartyRequested);

            foreach (var row in Rows)
            {
                foreach (Seat seat in row.Value.Seats)
                {
                    if (seat.IsAvailable)
                    {
                        allocation.AddSeat(seat);

                        if(allocation.IsFulfilled) {
                            return new SeatsAllocated(allocateSeats.PartyRequested, allocation.AllocatedSeats);
                        }
                    }
                }
            }
            return new NoPossibleAllocationsFound(allocateSeats.PartyRequested);;
        }
    }
}
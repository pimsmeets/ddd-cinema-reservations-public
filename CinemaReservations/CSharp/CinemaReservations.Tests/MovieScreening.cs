using System;
using System.Collections.Generic;

namespace CinemaReservations.Tests 
{    
    public class MovieScreening  {
        public readonly Dictionary<string, Row> Rows;
        public MovieScreening(Dictionary<String, Row> rows) {
            Rows = rows;
        }
        public SeatsReserved reserveSeats(ReserveSeats reserveSeats)
        {
            var reservation = new Reservation(reserveSeats.PartyRequested);

            foreach (var row in Rows)
            {
                foreach (Seat seat in row.Value.Seats)
                {
                    if (seat.IsAvailable)
                    {
                        reservation.AddSeat(seat);

                        if(reservation.IsFulfilled) {
                            return new SeatsReserved(reserveSeats.PartyRequested, reservation.ReservedSeats);
                        }
                    }
                }
            }
            return new ReservationNotAvailable(reserveSeats.PartyRequested);;
        }
    }
}
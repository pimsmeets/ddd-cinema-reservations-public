using System;

namespace CinemaReservations.Domain
{
    public class TicketBooth {
        private IMovieScreeningRepository _screeningRepository;

        public TicketBooth(IMovieScreeningRepository repo)
        {
            _screeningRepository = repo;
        }

        public SeatsAllocated AllocateSeats(AllocateSeats allocateSeats)
        {
            /* TicketBooth is a service that can be used to allocate sets.
             * Currently there are two possible outcomes:
             * - We return a SeatsAllocated object if the allocation is successful
             * - We return a NoPossibleAllocationsFound object if the allocation is unsuccessful
             *
             * Hint: look at the model in /docs/
             */
            throw new NotImplementedException();
        }

    }
}

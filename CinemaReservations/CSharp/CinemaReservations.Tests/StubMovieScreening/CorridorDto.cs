using System.Collections.Generic;

namespace CinemaReservations.Tests.StubMovieScreening
{
    public class CorridorDto
    {
        public int Number { get; set; }
        public IEnumerable<string> InvolvedRowNames { get; set; }
    }
}
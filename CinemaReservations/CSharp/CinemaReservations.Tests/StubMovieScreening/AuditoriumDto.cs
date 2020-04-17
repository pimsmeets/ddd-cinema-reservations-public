using System.Collections.Generic;

namespace CinemaReservations.Tests.StubMovieScreening
{
    public class AuditoriumDto
    {
        public Dictionary<string, IReadOnlyList<SeatDto>> Rows { get; set; }
        public IEnumerable<CorridorDto> Corridors { get; set; }
    }
}
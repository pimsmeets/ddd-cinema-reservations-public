using System.Collections.Generic;

namespace External.AuditoriumLayout
{
    public class AuditoriumDto
    {
        public Dictionary<string, IReadOnlyList<SeatDto>> Rows { get; set; }
        public IEnumerable<CorridorDto> Corridors { get; set; }
    }
}
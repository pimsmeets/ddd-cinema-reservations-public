using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using CinemaReservations.Domain;
using External.AuditoriumLayout;

namespace CinemaReservations.Tests.StubMovieScreening
{
    public class StubMovieScreeningRepository : IMovieScreeningRepository
    {
        private IAuditoriumRepository _auditoriumRepository;
        private readonly Dictionary<string, ReservedSeatsDto> _reservedSeatsRepository = new Dictionary<string, ReservedSeatsDto>();
        public StubMovieScreeningRepository(IAuditoriumRepository auditoriumRepository)
        {
            _auditoriumRepository = auditoriumRepository;

            var directoryName = $"{GetExecutingAssemblyDirectoryFullPath()}\\AuditoriumLayouts\\";

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                directoryName = $"{GetExecutingAssemblyDirectoryFullPath()}/AuditoriumLayouts/";
            }

            foreach (var fileFullName in Directory.EnumerateFiles($"{directoryName}"))
            {
                if (fileFullName.Contains("_booked_seats.json"))
                {
                    var fileName = Path.GetFileName(fileFullName);
                    var eventId = Path.GetFileName(fileName.Split("-")[0]);

                    _reservedSeatsRepository[eventId] = JsonFile.ReadFromJsonFile<ReservedSeatsDto>(fileFullName);
                }
            }
        }

        public MovieScreening FindMovieScreeningById(string screeningId)
        {
            AuditoriumDto auditoriumDto = _auditoriumRepository.FindAuditoriumForScreeningId(screeningId);
            ReservedSeatsDto reservedSeatsDto = _reservedSeatsRepository[screeningId];

            var rows = new Dictionary<string, Row>();
            foreach (var rowDto in auditoriumDto.Rows)
            {
                foreach (var seatDto in rowDto.Value)
                {
                    var rowName = ExtractRowName(seatDto.Name);
                    var number = ExtractNumber(seatDto.Name);

                    var isReserved = reservedSeatsDto.ReservedSeats.Contains(seatDto.Name);

                    if (!rows.ContainsKey(rowName))
                    {
                        rows[rowName] = new Row();
                    }

                    rows[rowName].Seats.Add(new Seat(rowName, number, isReserved ? SeatAvailability.Reserved : SeatAvailability.Available));
                }
            }

            return new MovieScreening(rows);
        }

        private static string GetExecutingAssemblyDirectoryFullPath()
        {
            var directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);

            if (directoryName.StartsWith(@"file:\"))
            {
                directoryName = directoryName.Substring(6);
            }

            if (directoryName.StartsWith(@"file:/"))
            {
                directoryName = directoryName.Substring(5);
            }

            return directoryName;
        }

        private static uint ExtractNumber(string name)
        {
            return uint.Parse(name.Substring(1));
        }

        private static string ExtractRowName(string name)
        {
            return name[0].ToString();
        }
    }
}

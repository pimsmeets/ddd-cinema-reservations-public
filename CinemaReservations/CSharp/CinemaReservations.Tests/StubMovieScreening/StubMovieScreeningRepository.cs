using System;
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

            /*In our model a MovieScreening contains rows, which contains seats.
             The status of each seat is determined by the SeatAvailability enum.

             We are relying on the auditoriumRepository to provide us with a map of the seats for a certain screening,
             and on the reservedSeatsRepository to determine the status.

             Implement the necessary logic to populate and return the value object rows
             */

            var rows = new Dictionary<string, Row>();

            // Todo: implement this
            throw new NotImplementedException();
            
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

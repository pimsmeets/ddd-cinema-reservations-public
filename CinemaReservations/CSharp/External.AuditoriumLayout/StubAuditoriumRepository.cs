using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace External.AuditoriumLayout
{
    public class StubAuditoriumRepository : IAuditoriumRepository
    {
        private readonly Dictionary<string, AuditoriumDto> _auditoriumRepository = new Dictionary<string, AuditoriumDto>();  

        public StubAuditoriumRepository() 
        {
            var directoryName = $"{GetExecutingAssemblyDirectoryFullPath()}\\AuditoriumLayouts\\";
            
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                directoryName = $"{GetExecutingAssemblyDirectoryFullPath()}/AuditoriumLayouts/";
            }
            
            foreach (var fileFullName in Directory.EnumerateFiles($"{directoryName}"))
            {
                if (fileFullName.Contains("_theater.json"))
                {
                    var fileName = Path.GetFileName(fileFullName);
                    var eventId = Path.GetFileName(fileName.Split("-")[0]);
                    _auditoriumRepository[eventId] = JsonFile.ReadFromJsonFile<AuditoriumDto>(fileFullName);
                }
            }
        }

        public AuditoriumDto FindAuditoriumForScreeningId(string screeningId)
        {
            if(_auditoriumRepository.ContainsKey(screeningId))
            {
                return _auditoriumRepository[screeningId];
            }

            throw new ArgumentException("Auditorium not found for screening ID: " + screeningId);
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
    }
}
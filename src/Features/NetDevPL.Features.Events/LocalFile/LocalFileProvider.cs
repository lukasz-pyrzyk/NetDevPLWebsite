using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace NetDevPL.Features.Events.LocalFile
{
    public class LocalFileProvider : IEventProvider
    {
        private const string Path = "LocalFile/conferences.json";

        public Task<Event[]> GetEventsAsync()
        {
            var json = File.ReadAllText(Path);
            var events = JsonConvert.DeserializeObject<Event[]>(json, new IsoDateTimeConverter
            {
                DateTimeFormat = "d.M.yyyy"
            });

            return Task.FromResult(events);
        }
    }
}

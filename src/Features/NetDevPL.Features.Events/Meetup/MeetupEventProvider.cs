using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NetDevPL.Features.Events.Meetup
{
    public class MeetupEventProvider : IEventProvider
    {
        private readonly HttpClient _client = new HttpClient
        {
            BaseAddress = new Uri("https://api.meetup.com")
        };

        private static readonly string[] _meetupGroups = { "Dot-Netos" };

        public async Task<Event[]> GetEventsAsync()
        {
            Task<Event[]>[] meetupTasks = _meetupGroups.Select(GetEventsForGroup).ToArray();
            await Task.WhenAll(meetupTasks);
            return meetupTasks.SelectMany(x => x.Result).ToArray();
        }

        private async Task<Event[]> GetEventsForGroup(string groupName)
        {
            var response = await _client.GetAsync($"{groupName}/events");
            var json = await response.Content.ReadAsStringAsync();
            var obj = JsonConvert.DeserializeObject<MeetupEvent[]>(json);
            return obj.Select(e => e.ToEvent()).ToArray();
        }
    }
}

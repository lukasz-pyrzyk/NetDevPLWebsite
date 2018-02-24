using System;
using System.Linq;
using System.Threading.Tasks;
using Nancy;
using NetDevPL.Features.Events;
using NetDevPL.Features.Events.LocalFile;
using NetDevPL.Features.Events.Meetup;

namespace NetDevPLWeb.Features.Events
{
    public sealed class EventsModule : NancyModule
    {
        private readonly EventsSource _source = new EventsSource();

        public EventsModule()
        {
            Get["/Events"] = parameters =>
            {
                var events = _source.GetEvents();
                return View["EventsList", new EventListViewModel(events, Request.Url)];
            };
        }
    }

    public class EventsSource
    {
        private readonly IEventProvider[] _providers =
        {
            new LocalFileProvider(), new MeetupEventProvider()
        };

        public Event[] GetEvents()
        {
            var tomorrow = DateTime.Today.AddDays(1);
            var events = GetEventsFromProvidersAsync().GetAwaiter().GetResult();

            return events.Where(c => c.EndDate > tomorrow).OrderBy(c => c.StartDate).ToArray();
        }

        private async Task<Event[]> GetEventsFromProvidersAsync()
        {
            var tasks = _providers.Select(x => x.GetEventsAsync());
            var eventsPerProvider = await Task.WhenAll(tasks);
            return eventsPerProvider.SelectMany(e => e).ToArray();
        }
    }
}
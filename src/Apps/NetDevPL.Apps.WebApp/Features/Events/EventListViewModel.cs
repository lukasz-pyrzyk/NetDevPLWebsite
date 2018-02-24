using Nancy;
using NetDevPL.Features.Events;
using NetDevPLWeb.Features.Shared;

namespace NetDevPLWeb.Features.Events
{
    public class EventListViewModel : BaseViewModel
    {
        public EventListViewModel(Event[] events, Url url) : base(url)
        {
            Events = events;
        }

        public Event[] Events { get; set; }
    }
}
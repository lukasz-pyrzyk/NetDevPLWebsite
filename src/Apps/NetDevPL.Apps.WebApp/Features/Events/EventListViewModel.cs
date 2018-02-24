using System;
using Nancy;
using NetDevPL.Features.Events;
using NetDevPLWeb.Features.Shared;

namespace NetDevPLWeb.Features.Events
{
    public class EventListViewModel : BaseViewModel
    {
        public EventListViewModel(EventViewModel[] events, Url url) : base(url)
        {
            Events = events;
        }

        public EventViewModel[] Events { get; set; }
    }

    public class EventViewModel
    {
        public string Url { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string City { get; set; }

        public string PrintPeriod(string format)
        {
            if (EndDate.HasValue)
            {
                return $"{StartDate.ToString(format)} - {EndDate.Value.ToString(format)}";
            }

            return StartDate.ToString(format);
        }

        public static EventViewModel FromEvent(Event e)
        {
            return new EventViewModel
            {
                Url = e.Url,
                Title = e.Title,
                StartDate = e.StartDate,
                EndDate = e.EndDate,
                City = e.City,
            };
        }
    }
}
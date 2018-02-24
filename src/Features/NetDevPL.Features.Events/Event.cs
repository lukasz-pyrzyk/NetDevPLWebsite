using System;

namespace NetDevPL.Features.Events
{
    public class Event
    {
        public Event(string url, string title, DateTime startDate, DateTime? endDate, string city)
        {
            Url = url;
            Title = title;
            StartDate = startDate;
            EndDate = endDate;
            City = city;
        }

        public string Url { get; }
        public string Title { get; }
        public DateTime StartDate { get; }
        public DateTime? EndDate { get; }
        public string City { get; }
    }
}

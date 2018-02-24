using System;
using NetDevPL.Features.Events;

namespace NetDevPL.TestHelpers.Builders
{
    public class EventBuilder
    {
        private string _url;
        private string _title;
        private DateTime _startDate;
        private DateTime _endDate;
        private string _city;

        public EventBuilder WithUrl(string url)
        {
            _url = url;
            return this;
        }

        public EventBuilder WithTitle(string title)
        {
            _title = title;
            return this;
        }

        public EventBuilder WithStartDate(DateTime startDate)
        {
            _startDate = startDate;
            return this;
        }

        public EventBuilder WithEndDate(DateTime endDate)
        {
            _endDate = endDate;
            return this;
        }

        public EventBuilder WithCity(string city)
        {
            _city = city;
            return this;
        }

        public Event Build()
        {
            return new Event(_url, _title, _startDate, _endDate, _city);
        }
    }
}

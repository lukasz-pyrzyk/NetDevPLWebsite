using System;
using Newtonsoft.Json;

namespace NetDevPL.Features.Events.Meetup
{
    public class MeetupEvent
    {
        public string Name { get; set; }
        [JsonProperty("rsvp_limit")]
        public int RsvpLimit { get; set; }
        public string Status { get; set; }
        public object Time { get; set; }
        [JsonProperty("local_date")]
        public string LocalDate { get; set; }
        [JsonProperty("local_time")]
        public string LocalTime { get; set; }
        public object Updated { get; set; }
        [JsonProperty("utc_offset")]
        public int UtcOffset { get; set; }
        [JsonProperty("waitlist_count")]
        public int WaitlistCount { get; set; }
        [JsonProperty("yes_rsvp_count")]
        public int YesRsvpCount { get; set; }
        public MeetupVenue Venue { get; set; }
        public MeetupGroup MeetupGroup { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        [JsonProperty("how_to_find_us")]
        public string HowToFindUs { get; set; }
        public string Visibility { get; set; }

        public Event ToEvent()
        {
            var startTime = DateTime.Parse(LocalDate);
            return new Event(Link, Name, startTime, startTime, Venue?.City);
        }
    }
}

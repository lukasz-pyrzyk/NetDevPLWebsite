using Newtonsoft.Json;

namespace NetDevPL.Features.Events.Meetup
{
    public class MeetupGroup
    {
        public object Created { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }
        [JsonProperty("join_mode")]
        public string JoinMode { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public string Urlname { get; set; }
        public string Who { get; set; }
        [JsonProperty("localized_location")]
        public string LocalizedLocation { get; set; }
        public string Region { get; set; }
    }
}
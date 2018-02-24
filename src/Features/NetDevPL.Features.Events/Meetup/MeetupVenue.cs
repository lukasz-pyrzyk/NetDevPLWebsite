using Newtonsoft.Json;

namespace NetDevPL.Features.Events.Meetup
{
    public class MeetupVenue
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public bool Repinned { get; set; }
        [JsonProperty("address_1")]
        public string Address1 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        [JsonProperty("localized_country_name")]
        public string LocalizedCountryName { get; set; }
        public string Address2 { get; set; }
    }
}
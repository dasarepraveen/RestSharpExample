using System.Collections.Generic;
using Newtonsoft.Json;

namespace APITest.Models
{
    public class Locationresponse
    {
        [JsonProperty("post code")]
        public long PostCode { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("country abbreviation")]
        public string CountryAbbreviation { get; set; }

        [JsonProperty("places")]
        public List<Places.Place> Places { get; set; }
    }
}
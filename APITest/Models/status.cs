using System.Collections.Generic;
using Newtonsoft.Json;

namespace APITest.Models
{
    public class status
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("data")]
        public Data Data { get; set; }
       }

}

using Newtonsoft.Json;

namespace APITest.Models
{
    public class Data
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("salary")]
      //  [JsonConverter(typeof(ParseStringConverter))]
        public long Salary { get; set; }

        [JsonProperty("age")]
       // [JsonConverter(typeof(ParseStringConverter))]
        public long Age { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }
    }
}
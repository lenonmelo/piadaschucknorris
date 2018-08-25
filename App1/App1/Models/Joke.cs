using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace App1.Models
{
    public class Joke : BaseModel
    {
        [JsonProperty("category")]
        public List<string> Category { get; set; }

        [JsonProperty("icon_url")]
        public string IconUrl { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}

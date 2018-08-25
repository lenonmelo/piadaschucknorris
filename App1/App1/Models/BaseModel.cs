using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace App1.Models
{
    public class BaseModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}

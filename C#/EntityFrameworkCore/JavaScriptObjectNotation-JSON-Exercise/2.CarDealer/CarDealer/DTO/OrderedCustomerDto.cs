using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.DTO
{
    [JsonObject]
    public class OrderedCustomerDto
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonIgnore]
        public DateTime BirthDate { get; set; }

        [JsonProperty("BirthDate")]
        public string FormattedBirthDate { get; set; }

        [JsonProperty("IsYoungDriver")]
        public bool IsYoungDriver { get; set; }
    }
}

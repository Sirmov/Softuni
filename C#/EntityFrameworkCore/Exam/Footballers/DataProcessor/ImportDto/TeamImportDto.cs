using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Footballers.DataProcessor.ImportDto
{
    [JsonObject]
    public class TeamImportDto
    {
        [JsonProperty("Name")]
        [Required(AllowEmptyStrings = false)]
        [MinLength(3)]
        [MaxLength(40)]
        [RegularExpression(@"[a-zA-Z\d\s\.\-]{3,40}")]
        public string Name { get; set; }

        [JsonProperty("Nationality")]
        [Required(AllowEmptyStrings = false)]
        [MinLength(2)]
        [MaxLength(40)]
        public string Nationality { get; set; }

        [JsonProperty("Trophies")]
        [Required(AllowEmptyStrings = false)]
        public int Trophies { get; set; }

        [JsonProperty("Footballers")]
        public int[] Footballers { get; set; }
    }
}

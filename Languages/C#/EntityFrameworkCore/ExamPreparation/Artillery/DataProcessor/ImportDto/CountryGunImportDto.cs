using Newtonsoft.Json;

namespace Artillery.DataProcessor.ImportDto
{
    [JsonObject]
    public class CountryGunImportDto
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
    }
}
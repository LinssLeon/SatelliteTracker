using Newtonsoft.Json;
using System.Collections.Generic;

namespace SatelliteTracker
{
    public class GeocodingLocation
    {
        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }
    }

    public class GeocodingResponse
    {
        [JsonProperty("data")]
        public List<GeocodingLocation> Data { get; set; }
    }
}

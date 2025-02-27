using System;
using Newtonsoft.Json;

namespace SatelliteTracker
{
    public class ISSPosition
    {
        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }
    }

    public class ISSResponse
    {
        [JsonProperty("iss_position")]
        public ISSPosition Position { get; set; }

        [JsonProperty("timestamp")]
        public long TimeStamp { get; set; }
    }
}

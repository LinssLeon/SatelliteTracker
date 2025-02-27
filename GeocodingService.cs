using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SatelliteTracker
{
    public class GeocodingService
    {
        private readonly HttpClient _client;
        private readonly string _apiKey = "YOUR_API_KEY";

        public GeocodingService()
        {
            _client = new HttpClient();
        }

        public async Task<string> GetLocationAsync(string latitude, string longitude)
        {
            try
            {
                var url = $"http://api.positionstack.com/v1/reverse?access_key={_apiKey}&query={latitude},{longitude}";

                var response = await _client.GetStringAsync(url);

                // Nur die relevanten Daten extrahieren
                var geocodingResponse = JsonConvert.DeserializeObject<GeocodingResponse>(response);

                if (geocodingResponse?.Data?.Count > 0)
                {
                    var location = geocodingResponse.Data[0];

                    // Nur relevante Daten ausgeben (Region und Land oder Meer)
                    if (!string.IsNullOrEmpty(location.Country) && !string.IsNullOrEmpty(location.Region))
                    {
                        return $"{location.Region}, {location.Country}";
                    }

                    // Wenn keine Stadt/Land verfügbar ist, dann den Meernamen verwenden
                    if (!string.IsNullOrEmpty(location.Label))
                    {
                        return $"{location.Label} (Meer)";
                    }

                    // Fallback, wenn nichts anderes verfügbar ist
                    return "Kein spezifischer Standort gefunden.";
                }
                else
                {
                    return "Kein Standort gefunden.";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Abrufen der Daten: {ex.Message}");
                return null;
            }
        }
    }
}

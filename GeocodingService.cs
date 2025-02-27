using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SatelliteTracker
{
    public class GeocodingService
    {
        private readonly HttpClient _client;
        private readonly string _apiKey = "fe93fea18fc47d167d15a3b2ee3643ef";  // Dein API-Schlüssel, ohne extra Zeilenumbruch

        public GeocodingService()
        {
            _client = new HttpClient();
        }

        public async Task<string> GetLocationAsync(string latitude, string longitude)
        {
            try
            {
                // API-URL für PositionStack Geocoding (mit dem API-Schlüssel)
                var url = $"http://api.positionstack.com/v1/reverse?access_key={_apiKey}&query={latitude},{longitude}";

                // API-Response holen
                var response = await _client.GetStringAsync(url);

                // JSON-Antwort in ein dynamisches Objekt umwandeln
                dynamic result = JsonConvert.DeserializeObject(response);

                // Hier extrahierst du die wichtigsten Informationen (Land und Region)
                var country = result.data[0].country;
                var region = result.data[0].region;

                return $"{region}, {country}";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Abrufen der Daten: {ex.Message}");
                return null;
            }
        }
    }
}

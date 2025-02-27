using System;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace SatelliteTracker
{
	public class SatelliteService
	{
		private readonly HttpClient _client;

		public SatelliteService()
		{
			_client = new HttpClient();
		}

		public async Task<ISSResponse> GetISSLocationAsync()
		{
			try
			{
				// API-Request ausführen..
				var response = await _client.GetStringAsync("http://api.open-notify.org/iss-now.json");

				// JSON in ISSResponse umwandeln:
				var issResponse = JsonConvert.DeserializeObject<ISSResponse>(response);
				return issResponse;
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Fehler beim Abrufen der Daten: {ex.Message}");
				return null;
			}
		}
	}
}


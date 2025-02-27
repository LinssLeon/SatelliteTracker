using System;
using System.Threading.Tasks;

namespace SatelliteTracker;

class Program
{
    static async Task Main(string[] args)
    {
        var satelliteService = new SatelliteService();
        var geocodingService = new GeocodingService();
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("Willkommen bei Satellite Tracker!");
            Console.WriteLine("1) Aktuelle ISS-Position anzeigen");
            Console.WriteLine("2) Live-Tracking der ISS starten");
            Console.WriteLine("3) Beenden");
            Console.Write("Bitte wähle eine Option: ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    await ShowCurrentPosition(satelliteService, geocodingService);
                    break;
                case "2":
                    await LiveTrackingISS(satelliteService, geocodingService);
                    break;
                case "3":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Ungültige Eingabe. Bitte versuchen Sie es erneut.");
                    break;
            }

            Console.WriteLine("\nDrücke eine beliebige Taste um fortzufahren..");
            Console.ReadKey();
        }
    }

    static async Task ShowCurrentPosition(SatelliteService satelliteService, GeocodingService geocodingService)
    {
        var issData = await satelliteService.GetISSLocationAsync();
        if (issData != null)
        {
            Console.WriteLine("\nAktuelle ISS-Position:");
            Console.WriteLine($"Breitengrad: {issData.Position.Latitude}");
            Console.WriteLine($"Längengrad: {issData.Position.Longitude}");
            Console.WriteLine($"Zeitstempel: {DateTimeOffset.FromUnixTimeSeconds(issData.TimeStamp)}");

            // Geocoding-Service für den Standort der ISS
            var location = await geocodingService.GetLocationAsync(issData.Position.Latitude.ToString(), issData.Position.Longitude.ToString());
            Console.WriteLine($"Standort: {location}");
        }
        else
        {
            Console.WriteLine("Konnte die ISS-Position nicht abrufen.");
        }
    }


    static async Task LiveTrackingISS(SatelliteService satelliteService, GeocodingService geocodingService)
    {
        Console.WriteLine("Live-Verfolgung der ISS startet...");

        while (true)
        {
            var issData = await satelliteService.GetISSLocationAsync();
            if (issData != null)
            {
                Console.Clear();
                Console.WriteLine($"Live-Verfolgung: ISS-Position");
                Console.WriteLine($"Breitengrad: {issData.Position.Latitude}");
                Console.WriteLine($"Längengrad: {issData.Position.Longitude}");
                Console.WriteLine($"Zeitstempel: {DateTimeOffset.FromUnixTimeSeconds(issData.TimeStamp)}");

                // Geocoding-Service für den aktuellen Standort der ISS
                var location = await geocodingService.GetLocationAsync(issData.Position.Latitude.ToString(), issData.Position.Longitude.ToString());
                Console.WriteLine($"Standort: {location}");
            }
            else
            {
                Console.WriteLine("Konnte die ISS-Position nicht abrufen.");
                break;
            }

            await Task.Delay(10000);
        }
    }
}

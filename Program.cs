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
            Console.WriteLine("2) Mission starten: Tracke die ISS 5 Mal");
            Console.WriteLine("3) Live-Tracking der ISS starten");
            Console.WriteLine("4) Beenden");
            Console.Write("Bitte wähle eine Option: ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    await ShowCurrentPosition(satelliteService, geocodingService);
                    break;
                case "2":
                    await TrackISS(satelliteService, geocodingService);
                    break;
                case "3":
                    await LiveTrackingISS(satelliteService, geocodingService);
                    break;
                case "4":
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

            // Geocoding-Service für die Umwandlung der Koordinaten in den Standort
            var location = await geocodingService.GetLocationAsync(issData.Position.Latitude.ToString(), issData.Position.Longitude.ToString());
            Console.WriteLine($"Standort: {location}");
        }
        else
        {
            Console.WriteLine("Konnte die ISS-Position nicht abrufen.");
        }
    }

    static async Task TrackISS(SatelliteService satelliteService, GeocodingService geocodingService)
    {
        Console.WriteLine("\nMission: Tracke die ISS 5 Mal!");
        int updates = 0;

        while (updates < 5)
        {
            var issData = await satelliteService.GetISSLocationAsync();
            if (issData != null)
            {
                updates++;
                Console.WriteLine($"Update {updates}/5 - Breitengrad: {issData.Position.Latitude}, Längengrad: {issData.Position.Longitude}");
            }
            await Task.Delay(2000);
        }

        Console.WriteLine("\n✅ Mission abgeschlossen! Du hast die ISS 5 Mal erfolgreich getrackt.");
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


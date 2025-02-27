# 🚀 SatelliteTracker - Version 1.0.4 - How to Use
SatelliteTracker ist eine Konsolenanwendung, die es dir ermöglicht, die Internationale Raumstation (ISS) in Echtzeit zu verfolgen und ihren Standort auf der Erde zu bestimmen. Die Anwendung nutzt verschiedene APIs, um die ISS-Position und den Standort basierend auf den Koordinaten zu ermitteln.

## 🚀 Features

Echtzeit ISS-Position: Verfolge die aktuelle Position der Internationalen Raumstation (ISS) auf der Erde.
Standortbestimmung: Bestimmt den geografischen Standort (Land oder Ozean) basierend auf den Längen- und Breitengraden der ISS.
Live-Verfolgung: Eine Live-Verfolgung der ISS in Echtzeit.
API-Integration: Verwendet APIs wie Open Notify und PositionStack zur Ermittlung der ISS-Position und der geografischen Daten.

## 🛠️ Voraussetzungen

.NET SDK: Stelle sicher, dass du das .NET SDK installiert hast, um das Projekt auszuführen. (ich habe z.B .NET SDK 7.0.317)
API-Schlüssel für PositionStack: Um die Geocoding-Funktion zu nutzen, benötigst du einen gültigen API-Schlüssel für PositionStack (oder einen alternativen Geocoding-Dienst). Du kannst einen kostenlosen API-Schlüssel auf der [PositionStack-Website](https://positionstack.com/) erhalten.

## 📦 Installation

1. Clone das Repository
Erstelle zunächst eine Kopie des Repositories:

> bash

```
git clone https://github.com/LinssLeon/SatelliteTracker.git
```
2. Installiere die Abhängigkeiten
Stelle sicher, dass du die erforderlichen NuGet-Pakete installiert hast:

> bash

```
cd SatelliteTracker
dotnet restore
```
3. API-Schlüssel für Geocoding einfügen
Ersetze den Platzhalter in der Datei GeocodingService.cs mit deinem eigenen API-Schlüssel:

> csharp

```private readonly string _apiKey = "DEIN_API_SCHLÜSSEL";```

Besorge dir den API-Schlüssel von einem Geocoding-Dienst wie PositionStack oder Geonames und füge ihn in den Code ein.
🚀 Anwendung starten
1. Kompilieren und Ausführen
Um die Anwendung auszuführen, benutze den folgenden Befehl:

> bash

`dotnet run`

2. Interaktive Befehlszeile
Nachdem du die Anwendung gestartet hast, wirst du auf eine interaktive Menüaufforderung stoßen:

```
🚀 Willkommen bei Satellite Tracker!
1) Aktuelle ISS-Position anzeigen
2) Live-Verfolgung starten
3) Beenden
Bitte wähle eine Option: 

```
Option 1: Zeigt die aktuelle ISS-Position und den geografischen Standort der ISS (Land oder Ozean) an.
Option 2: Startet die Live-Verfolgung der ISS und zeigt die Position in Echtzeit an.
Option 3: Beendet die Anwendung.

### 🧭 Erklärung der Funktionen
1. Aktuelle ISS-Position anzeigen
Wählen Sie Option 1, um die aktuelle Breiten- und Längengrad-Position der ISS zu sehen. Die Anwendung gibt die ISS-Position sowie den Standort (Land oder Ozean) aus.

Beispiel-Ausgabe:

```
🌍 Aktuelle ISS-Position:
Breitengrad: 37.7749
Längengrad: -122.4194
Zeitstempel: 1610000000
Standort: Kalifornien, Vereinigte Staaten
```

2. Live-Verfolgung starten
Wählen Sie Option 2, um die Live-Verfolgung der ISS zu starten. Die Anwendung zeigt in Echtzeit die Aktualisierung der ISS-Position und den geografischen Standort der ISS an. Alle 10 Sekunden wird die Position aktualisiert.

Beispiel-Ausgabe:

```
🎯 Live-Verfolgung: ISS-Position
Breitengrad: 37.7749
Längengrad: -122.4194
Zeitstempel: 1610000000
Standort: Kalifornien, Vereinigte Staaten
```

3. Beenden
Wählen Sie Option 3, um die Anwendung zu beenden.

###  ⚙️ Anpassen des Projekts
API-Schlüssel für Geocoding: Du kannst den Geocoding-Dienst ändern, indem du den Code in GeocodingService.cs anpasst. Verwende einen anderen API-Dienst wie Geonames oder Nominatim, falls gewünscht.
Hinzufügen von Funktionen: Du kannst weitere APIs hinzufügen, um z. B. zusätzliche Satelliten oder andere geospatiale Daten zu integrieren.

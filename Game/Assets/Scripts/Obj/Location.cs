using UnityEngine;

/// <summary>
/// Structure for storing location information
/// </summary>
[System.Serializable]
public struct Location
{
    public string name;
    public string backgroundPath;
}

/// <summary>
/// Manager of all available locations in the game
/// </summary>
public static class LocationManager
{
    private const string TEXTURES_PATH = "Texturs/Locations";
    private const string LOBBYS_BACKGROUND_PATH = "Texturs/Locations/LobbysBackground";

    // Collection of all available locations
    public static readonly Location[] AllLocations = new Location[]
    {
        new Location { name = "Ghetto/Ghetto_0" },
        new Location { name = "Ghetto/Ghetto_1" },
        new Location { name = "Ghetto/Ghetto_2" },
        new Location { name = "Ghetto/Ghetto_3" },
        new Location { name = "Ghetto/Ghetto_4" }
    };

    /// <summary>
    /// Generate location path from name
    /// </summary>
    private static string GenerateLocationPath(string locationName)
    {
        return $"{LOBBYS_BACKGROUND_PATH}/{locationName}";
    }

    /// <summary>
    /// Get location by name
    /// </summary>
    public static Location GetLocationByName(string locationName)
    {
        for (int i = 0; i < AllLocations.Length; i++)
        {
            if (AllLocations[i].name == locationName)
            {
                AllLocations[i].backgroundPath = GenerateLocationPath(AllLocations[i].name);
                return AllLocations[i];
            }
        }

        Debug.LogWarning($"Location '{locationName}' not found!");
        return GetLocationByIndex(0);
    }

    /// <summary>
    /// Get location by index
    /// </summary>
    public static Location GetLocationByIndex(int index)
    {
        if (index >= 0 && index < AllLocations.Length)
        {
            Location location = AllLocations[index];
            location.backgroundPath = GenerateLocationPath(location.name);
            return location;
        }

        Debug.LogWarning($"Location index {index} is out of range!");
        AllLocations[0].backgroundPath = GenerateLocationPath(AllLocations[0].name);
        return AllLocations[0];
    }
}

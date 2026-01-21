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
        new Location 
        { 
            name = "Ghetto_0", 
            backgroundPath = $"{LOBBYS_BACKGROUND_PATH}/Ghetto_0" 
        },
        new Location 
        { 
            name = "Ghetto_1", 
            backgroundPath = $"{LOBBYS_BACKGROUND_PATH}/Ghetto_1" 
        }
    };

    /// <summary>
    /// Get location by name
    /// </summary>
    public static Location GetLocationByName(string locationName)
    {
        foreach (Location location in AllLocations)
        {
            if (location.name == locationName)
            {
                return location;
            }
        }

        Debug.LogWarning($"Location '{locationName}' not found!");
        return AllLocations[0]; // Return first location as default
    }

    /// <summary>
    /// Get location by index
    /// </summary>
    public static Location GetLocationByIndex(int index)
    {
        if (index >= 0 && index < AllLocations.Length)
        {
            return AllLocations[index];
        }

        Debug.LogWarning($"Location index {index} is out of range!");
        return AllLocations[0];
    }
}

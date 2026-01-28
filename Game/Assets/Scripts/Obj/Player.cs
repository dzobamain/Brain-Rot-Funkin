using UnityEngine;

namespace Obj
{
    /// <summary>
    /// Structure for storing player information
    /// </summary>
    [System.Serializable]
    public struct Player
    {
        public string name;
        public string imagePath;
    }

    /// <summary>
    /// Manager for player data in the game
    /// </summary>
    public static class PlayerManager
    {
        private const string PLAYER_PATH = "Texturs/Player";

        // Collection of all available player characters
        public static readonly Player[] AllPlayers = new Player[]
        {
        new Player { name = "TumSahur_Happy" },
        new Player { name = "TumSahur_Sad" }
        };

        /// <summary>
        /// Generate player path from name
        /// </summary>
        private static string GeneratePlayerPath(string characterName)
        {
            return $"{PLAYER_PATH}/{characterName}";
        }

        /// <summary>
        /// Get player character by name
        /// </summary>
        public static Player GetPlayerByName(string playerName)
        {
            for (int i = 0; i < AllPlayers.Length; i++)
            {
                if (AllPlayers[i].name == playerName)
                {
                    AllPlayers[i].imagePath = GeneratePlayerPath(AllPlayers[i].name);
                    return AllPlayers[i];
                }
            }

            Debug.LogWarning($"Player '{playerName}' not found!");
            return GetPlayerByIndex(0);
        }

        /// <summary>
        /// Get player character by index
        /// </summary>
        public static Player GetPlayerByIndex(int index)
        {
            if (index >= 0 && index < AllPlayers.Length)
            {
                Player player = AllPlayers[index];
                player.imagePath = GeneratePlayerPath(player.name);
                return player;
            }

            Debug.LogWarning($"Player at index {index} not found!");
            AllPlayers[0].imagePath = GeneratePlayerPath(AllPlayers[0].name);
            return AllPlayers[0];
        }
    }
}

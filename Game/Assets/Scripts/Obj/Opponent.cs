using UnityEngine;

namespace Obj
{
    /// <summary>
    /// Structure for storing opponent information
    /// </summary>
    [System.Serializable]
    public struct Opponent
    {
        public string name;
        public string imagePath;
    }

    /// <summary>
    /// Manager of all available opponents in the game
    /// </summary>
    public static class OpponentManager
    {
        private const string OPPONENTS_PATH = "Texturs/Opponents";

        // Collection of all available opponents
        public static readonly Opponent[] AllOpponents = new Opponent[]
        {
        new Opponent { name = "Tralalelotralala_0" },
        new Opponent { name = "1" },
        new Opponent { name = "2" },
        new Opponent { name = "3" },
        new Opponent { name = "4" }
        };

        /// <summary>
        /// Generate opponent path from name
        /// </summary>
        private static string GenerateOpponentPath(string opponentName)
        {
            return $"{OPPONENTS_PATH}/{opponentName}";
        }

        /// <summary>
        /// Get opponent by name
        /// </summary>
        public static Opponent GetOpponentByName(string opponentName)
        {
            for (int i = 0; i < AllOpponents.Length; i++)
            {
                if (AllOpponents[i].name == opponentName)
                {
                    AllOpponents[i].imagePath = GenerateOpponentPath(AllOpponents[i].name);
                    return AllOpponents[i];
                }
            }

            Debug.LogWarning($"Opponent '{opponentName}' not found!");
            return GetOpponentByIndex(0);
        }

        /// <summary>
        /// Get opponent by index
        /// </summary>
        public static Opponent GetOpponentByIndex(int index)
        {
            if (index >= 0 && index < AllOpponents.Length)
            {
                Opponent opponent = AllOpponents[index];
                opponent.imagePath = GenerateOpponentPath(opponent.name);
                return opponent;
            }

            Debug.LogWarning($"Opponent at index {index} not found!");
            AllOpponents[0].imagePath = GenerateOpponentPath(AllOpponents[0].name);
            return AllOpponents[0];
        }
    }
}

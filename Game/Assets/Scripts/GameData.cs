using UnityEngine;

namespace Data
{
    [System.Serializable]
    public class Game
    {
        public int playedLevel;
        public int selectedLevel;

        public int playerModel;

        public void SetNewPlayerModel(int modelIndex)
        {
            if (modelIndex < 0 || modelIndex > PlayerManager.AllPlayers.Length)
            {
                return;
            }
            playerModel = modelIndex;
        }

        public void SetPlayedLevel(int levelIndex)
        {
            if (levelIndex < 0 || levelIndex > LocationManager.AllLocations.Length)
            {
                return;
            }
            playedLevel = levelIndex;
        }

        public void SetSelectedLevel(int levelIndex)
        {
            if (levelIndex < 0 || levelIndex > playedLevel)
            {
                return;
            }
            selectedLevel = levelIndex;
        }
    }
}

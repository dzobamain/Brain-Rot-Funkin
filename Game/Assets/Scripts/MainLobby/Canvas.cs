using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static Scene;
using Data;

public class MainLobbyCanvas : MonoBehaviour
{
    void Start()
    {
        GameData gameData = new GameData();

        bool loaded = Config.LoadFromJson(Config.PathData, ref gameData);

        if (!loaded)
        {
            Debug.LogError("Failed to load GameData");

            gameData.playedLevel = 0;
            gameData.selectedLevel = 0;
            gameData.playerModel = 0;
        }

        UpdateAllObjects(true, true, true, gameData.selectedLevel, gameData.playerModel);
    }

    private void UpdateAllObjects(bool locUpdate, bool oppUpdate, bool playerUpdate, int locAndOppIndex = 0, int playerIndex = 0)
    {
        if (!locUpdate || !oppUpdate || !playerUpdate)
        {
            return;
        }

        if (locUpdate)
        {
            Location location = LocationManager.GetLocationByIndex(locAndOppIndex);
            Scene.LoadImage(location.backgroundPath, "Background");
        }

        if (oppUpdate)
        {
            Opponent opponent = OpponentManager.GetOpponentByIndex(locAndOppIndex);
            Scene.LoadImage(opponent.imagePath, "Opponent");
        }

        if (playerUpdate)
        {
            Player player = PlayerManager.GetPlayerByIndex(playerIndex);
            Scene.LoadImage(player.imagePath, "Player");
        }
    }
}

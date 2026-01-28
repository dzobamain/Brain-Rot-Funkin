using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Data;

public class BattleButtons : MonoBehaviour
{
    public void OnRightButtonClicked()
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

        gameData.SetSelectedLevel(gameData.selectedLevel + 1);
        Debug.Log("OnRightButtonClicked() new selectedLevel: " + gameData.selectedLevel);

        UpdateAllObjects(true, true, true, gameData.selectedLevel, gameData.playerModel);
        Config.SaveToJson(Config.PathData, gameData);
    }   

    public void OnLeftButtonClicked()
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

        gameData.SetSelectedLevel(gameData.selectedLevel - 1);

        UpdateAllObjects(true, true, true, gameData.selectedLevel, gameData.playerModel);
        Config.SaveToJson(Config.PathData, gameData);
    }

    private void UpdateAllObjects(bool locUpdate, bool oppUpdate, bool playerUpdate, int locAndOppIndex = 0, int playerIndex = 0)
    {
        if (!locUpdate || !oppUpdate || !playerUpdate)
        {
            return;
        }

        Debug.Log("UpdateAllObjects() locAndOppIndex: " + locAndOppIndex);

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

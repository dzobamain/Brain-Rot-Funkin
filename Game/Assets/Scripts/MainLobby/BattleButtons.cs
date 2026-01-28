using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace UserInterface
{
    public class BattleButtons : MonoBehaviour
    {
        public void OnRightButtonClicked()
        {
            Data.Game gameData = new Data.Game();

            bool loaded = Data.Config.LoadFromJson(Data.Config.PathData, ref gameData);

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
            Data.Config.SaveToJson(Data.Config.PathData, gameData);
        }

        public void OnLeftButtonClicked()
        {
            Data.Game gameData = new Data.Game();

            bool loaded = Data.Config.LoadFromJson(Data.Config.PathData, ref gameData);

            if (!loaded)
            {
                Debug.LogError("Failed to load GameData");

                gameData.playedLevel = 0;
                gameData.selectedLevel = 0;
                gameData.playerModel = 0;
            }

            gameData.SetSelectedLevel(gameData.selectedLevel - 1);

            UpdateAllObjects(true, true, true, gameData.selectedLevel, gameData.playerModel);
            Data.Config.SaveToJson(Data.Config.PathData, gameData);
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
                Obj.Location location = Obj.LocationManager.GetLocationByIndex(locAndOppIndex);
                Scene.LoadImage(location.backgroundPath, "Background");
            }

            if (oppUpdate)
            {
                Obj.Opponent opponent = Obj.OpponentManager.GetOpponentByIndex(locAndOppIndex);
                Scene.LoadImage(opponent.imagePath, "Opponent");
            }

            if (playerUpdate)
            {
                Obj.Player player = Obj.PlayerManager.GetPlayerByIndex(playerIndex);
                Scene.LoadImage(player.imagePath, "Player");
            }
        }
    }
}

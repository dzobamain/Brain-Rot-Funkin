using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace MainLobby
{
    public class Canvas : MonoBehaviour
    {
        void Start()
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

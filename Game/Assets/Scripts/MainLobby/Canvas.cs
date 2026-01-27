using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static Scene;

public class MainLobbyCanvas : MonoBehaviour
{
    void Start()
    {
        UpdateAllObjects(true, true, true);
    }

    private void UpdateAllObjects(bool locUpdate, bool playerUpdate, bool oppUpdate)
    {
        if (!locUpdate || !oppUpdate || !playerUpdate)
        {
            return;
        }

        if (locUpdate)
        {
            Location location = LocationManager.GetLocationByIndex(0);
            Scene.LoadImage(location.backgroundPath, "Background");
        }

        if (oppUpdate)
        {
            Opponent opponent = OpponentManager.GetOpponentByIndex(0);
            Scene.LoadImage(opponent.imagePath, "Opponent");
        }

        if (playerUpdate)
        {
            Player player = PlayerManager.GetPlayerByIndex(0);
            Scene.LoadImage(player.imagePath, "Player");
        }
    }
    
}

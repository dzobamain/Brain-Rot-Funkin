using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static Scene;

public class BattleButtons : MonoBehaviour
{
    public void OnRightButtonClicked()
    {
        UpdateAllObjects(true, true, true, 1);
    }   

    public void OnLeftButtonClicked()
    {
        UpdateAllObjects(true, true, true, 0);
    }

    private void UpdateAllObjects(bool locUpdate, bool playerUpdate, bool oppUpdate, int index = 0)
    {
        if (!locUpdate || !oppUpdate || !playerUpdate)
        {
            return;
        }

        if (locUpdate)
        {
            Location location = LocationManager.GetLocationByIndex(index);
            Scene.LoadImage(location.backgroundPath, "Background");
        }

        if (oppUpdate)
        {
            Opponent opponent = OpponentManager.GetOpponentByIndex(index);
            Scene.LoadImage(opponent.imagePath, "Opponent");
        }

        if (playerUpdate)
        {
            Player player = PlayerManager.GetPlayerByIndex(index);
            Scene.LoadImage(player.imagePath, "Player");
        }
    }
}

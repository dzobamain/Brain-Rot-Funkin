using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainLobby : MonoBehaviour
{
    void Start()
    {
        Location location = LocationManager.GetLocationByIndex(0);
        LoadLobbyBackground(location.backgroundPath);

        Opponent opponent = OpponentManager.GetOpponentByIndex(0);
        LoadOpponentImage(opponent.imagePath);

        Player player = PlayerManager.GetPlayerByIndex(0);
        LoadPlayerImage(player.imagePath);
    }

    private void LoadLobbyBackground(string backgroundPath)
    {
        Image bg = GameObject.Find("Background")?.GetComponent<Image>();

        if (bg == null)
        {
            Debug.LogError("Background Image component not found!");
            return;
        }

        // Load sprite using provided background path
        Sprite sprite = Resources.Load<Sprite>(backgroundPath);

        if (sprite == null)
        {
            Debug.LogError($"SPRITE NOT FOUND BY PATH: {backgroundPath}");
            return;
        }

        bg.sprite = sprite;
        Debug.Log($"Lobby background loaded successfully! Path: {backgroundPath}");
    }

    private void LoadOpponentImage(string opponentImagePath)
    {
        Image opponentImage = GameObject.Find("Opponent")?.GetComponent<Image>();

        if (opponentImage == null)
        {
            Debug.LogError("Opponent Image component not found!");
            return;
        }

        // Load sprite using provided opponent image path
        Sprite sprite = Resources.Load<Sprite>(opponentImagePath);

        if (sprite == null)
        {
            Debug.LogError($"OPPONENT SPRITE NOT FOUND BY PATH: {opponentImagePath}");
            return;
        }

        opponentImage.sprite = sprite;
        Debug.Log($"Opponent image loaded successfully! Path: {opponentImagePath}");
    }

    private void LoadPlayerImage(string playerImagePath)
    {
        Image playerImage = GameObject.Find("Player")?.GetComponent<Image>();

        if (playerImage == null)
        {
            Debug.LogError("Player Image component not found!");
            return;
        }

        // Load sprite using provided player image path
        Sprite sprite = Resources.Load<Sprite>(playerImagePath);

        if (sprite == null)
        {
            Debug.LogError($"PLAYER SPRITE NOT FOUND BY PATH: {playerImagePath}");
            return;
        }

        playerImage.sprite = sprite;
        Debug.Log($"Player image loaded successfully! Path: {playerImagePath}");
    }

    public void OnStartButtonClicked()
    {
        SceneManager.LoadScene("GameScene");
    }
}

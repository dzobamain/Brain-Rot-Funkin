using UnityEngine;
using UnityEngine.UI;

public class MainLobby : MonoBehaviour
{
    void Start()
    {
        Location location = LocationManager.GetLocationByIndex(0);
        LoadLobbyBackground(location.backgroundPath);
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
}

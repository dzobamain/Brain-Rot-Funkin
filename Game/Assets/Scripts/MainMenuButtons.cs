using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public void GameButton()
    {
        Debug.Log("Game button pressed!");
        SceneManager.LoadScene("MainLobby");
    }

    public void SettingsButton()
    {
        // has no settings yet
        Debug.Log("Settings button pressed!");
    }

    public void QuitButton()
    {
        Debug.Log("Quit the game!");  
        Application.Quit();
    }
}

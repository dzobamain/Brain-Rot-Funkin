using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    /// <summary>
    /// Load a sprite from Resources by path and assign it to a UI Image on the scene by GameObject name.
    /// </summary>
    public static void LoadImage(string path, string name)
    {
        Image image = GameObject.Find(name)?.GetComponent<Image>();

        if (image == null)
        {
            Debug.LogError($"Image component not found on GameObject '{name}'!");
            return;
        }

        // Load sprite using provided path
        Sprite sprite = Resources.Load<Sprite>(path);

        if (sprite == null)
        {
            Debug.LogError($"SPRITE NOT FOUND BY PATH: {path}");
            return;
        }

        image.sprite = sprite;
        Debug.Log($"Image '{name}' loaded successfully from path: {path}");
    }
}

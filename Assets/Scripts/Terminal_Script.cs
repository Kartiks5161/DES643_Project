using UnityEngine;
using UnityEngine.SceneManagement;

public class Terminal_Script : MonoBehaviour
{
    [Header("Teleport Settings")]
    public string spaceSceneName = "Binary_Star_Scene";

    // Put this on your "Launch to Orbit" button
    public void TeleportToSpace()
    {
        // Ensure time isn't frozen and load the scene
        Time.timeScale = 1f;
        SceneManager.LoadScene(spaceSceneName);
    }
}
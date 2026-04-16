using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // NEW & CRITICAL: This tells Unity we want to load scenes!

public class Panel_Script : MonoBehaviour
{
    public GameObject infoPanel;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI infoText;

    private string targetScene; // NEW: Remembers which scene to load

    public void ShowPanel(string pName, string info, string sceneName, Vector3 worldPos)
    {
        infoPanel.SetActive(true);

        // UNLOCK MOUSE
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Save the scene name so the button knows what to load
        targetScene = sceneName;

        // Set the Title text
        if (string.IsNullOrEmpty(pName))
            titleText.text = "Unknown Planet";
        else
            titleText.text = pName;

        // Set the Info text
        if (string.IsNullOrEmpty(info))
            infoText.text = "No Data Available";
        else
            infoText.text = info;

        // Move panel to that position
        Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPos);
        infoPanel.transform.position = screenPos;
    }

    public void HidePanel()
    {
        infoPanel.SetActive(false);

        // RESUME TIME
        Time.timeScale = 1f;

        // RELOCK MOUSE
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // UPDATED: TELEPORT FUNCTION
    public void TeleportToPlanet()
    {
        if (!string.IsNullOrEmpty(targetScene))
        {
            // CRITICAL: Unpause the game before leaving, otherwise the next scene will be frozen!
            Time.timeScale = 1f;

            // Load the scene
            SceneManager.LoadScene(targetScene);
        }
        else
        {
            Debug.LogWarning("No scene name was typed into the Inspector for this planet!");
        }
    }
}
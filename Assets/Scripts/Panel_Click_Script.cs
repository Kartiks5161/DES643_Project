using UnityEngine;

public class Panel_Click_Script : MonoBehaviour
{
    public Panel_Script uiManager;

    public string planetName;

    [TextArea]
    public string planetInfo;

    public string sceneToLoad; // NEW: The exact name of the scene file to load

    void OnMouseDown()
    {
        if (uiManager != null)
        {
            // NEW: Pass the sceneToLoad and the world position to the UI manager
            uiManager.ShowPanel(planetName, planetInfo, sceneToLoad, transform.position);

            // FREEZE TIME
            Time.timeScale = 0f;
        }
    }
}
using UnityEngine;

public class Panel_Click_Script : MonoBehaviour
{
    public Panel_Script uiManager;

    [TextArea]
    public string planetInfo;

    void OnMouseDown()
    {
        if (uiManager != null)
        {
            uiManager.ShowPanel(planetInfo, transform.position);
        }
    }
}
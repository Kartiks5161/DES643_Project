using UnityEngine;
using TMPro;

public class Panel_Script : MonoBehaviour
{
    public GameObject infoPanel;
    public TextMeshProUGUI infoText;

    public void ShowPanel(string info, Vector3 worldPos)
    {
        infoPanel.SetActive(true);

        // Set text
        if (string.IsNullOrEmpty(info))
            infoText.text = "No Data Available";
        else
            infoText.text = info;

        // Convert world position to screen position
        Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPos);

        // Move panel to that position
        infoPanel.transform.position = screenPos;
    }

    public void HidePanel()
    {
        infoPanel.SetActive(false);
    }
}
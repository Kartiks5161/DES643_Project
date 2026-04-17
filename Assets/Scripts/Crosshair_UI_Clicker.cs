using UnityEngine;
using UnityEngine.EventSystems; // Required for interacting with UI
using UnityEngine.UI;
using System.Collections.Generic;

public class Crosshair_UI_Clicker : MonoBehaviour
{
    void Update()
    {
        // When you left click...
        if (Input.GetMouseButtonDown(0))
        {
            // 1. Create a fake "mouse pointer" exactly in the dead-center of your screen
            PointerEventData pointerData = new PointerEventData(EventSystem.current);
            pointerData.position = new Vector2(Screen.width / 2f, Screen.height / 2f);

            // 2. Shoot a raycast to see if that center point is hitting any UI elements
            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointerData, results);

            // 3. Look through whatever we hit
            foreach (RaycastResult result in results)
            {
                // Did we hit a Button?
                Button uiButton = result.gameObject.GetComponentInParent<Button>();

                if (uiButton != null)
                {
                    // Force the button to click!
                    uiButton.onClick.Invoke();
                    break; // Stop looking after we click the first button
                }
            }
        }
    }
}
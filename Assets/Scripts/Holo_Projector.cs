using UnityEngine;

public class Holo_Projector : MonoBehaviour
{
    [Header("Settings")]
    public KeyCode summonKey = KeyCode.T; // Press 'T' for Terminal
    public float spawnDistance = 2.5f;    // How many meters in front of you it spawns

    [Header("References")]
    public GameObject terminalPrefab; // Your Data_Terminal prefab goes here
    public Transform playerCamera;    // Your Main Camera goes here

    private GameObject activeTerminal;

    void Start()
    {
        // When the game starts, spawn a hidden copy of the terminal
        if (terminalPrefab != null)
        {
            activeTerminal = Instantiate(terminalPrefab);
            activeTerminal.SetActive(false); // Hide it immediately
        }
    }

    void Update()
    {
        // Did the player press 'T'?
        if (Input.GetKeyDown(summonKey) && activeTerminal != null)
        {
            // If the terminal is already visible, turn it off (put it away)
            if (activeTerminal.activeSelf)
            {
                activeTerminal.SetActive(false);
            }
            // If it's hidden, summon it!
            else
            {
                // 1. Figure out exactly which way the camera is looking
                Vector3 flatForward = playerCamera.forward;
                flatForward.y = 0; // Ignore looking up/down so it stays on the ground
                flatForward.Normalize();

                // 2. Calculate a spot 2.5 meters in front of the player
                Vector3 spawnPosition = transform.position + (flatForward * spawnDistance);

                // 3. Keep it exactly level with the player's feet
                spawnPosition.y = transform.position.y;

                // 4. Move the terminal to that spot
                activeTerminal.transform.position = spawnPosition;

                // 5. Rotate it so the screen is facing the player perfectly!
                activeTerminal.transform.LookAt(transform.position);
                activeTerminal.transform.Rotate(0, 180f, 0); // NEW LINE: Spin it 180 degrees on the Y-axis!

                // 6. Turn it on
                activeTerminal.SetActive(true);
            }
        }
    }
}
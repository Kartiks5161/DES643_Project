using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PC_Movement : MonoBehaviour
{
    [Header("Settings")]
    public float walkSpeed = 5f;
    public float lookSensitivity = 2f;
    public float gravity = -9.81f;

    [Header("References")]
    public Camera playerCamera; // Drag your Main Camera here in the Inspector!

    private CharacterController controller;
    private float verticalLookRotation = 0f;
    private Vector3 velocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        // Lock the mouse to the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // 1. MOUSE LOOK (Looking around)
        float mouseX = Input.GetAxis("Mouse X") * lookSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * lookSensitivity;

        // Rotate the whole player body left/right
        transform.Rotate(Vector3.up * mouseX);

        // Rotate just the camera up/down
        verticalLookRotation -= mouseY;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f); // Prevents looking past straight up/down
        playerCamera.transform.localEulerAngles = Vector3.right * verticalLookRotation;

        // 2. WASD MOVEMENT (Walking)
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Move relative to where the player is looking
        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        controller.Move(move * walkSpeed * Time.deltaTime);

        // 3. GRAVITY (Keeps you stuck to the terrain when walking down hills)
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Slight downward push to stick to slopes
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
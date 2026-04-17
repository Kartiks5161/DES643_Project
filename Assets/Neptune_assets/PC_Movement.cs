using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(AudioSource))]
public class PC_Movement : MonoBehaviour
{
    [Header("Settings")]
    public float walkSpeed = 5f;
    public float lookSensitivity = 2f;
    public float gravity = -9.81f;

    [Header("References")]
    public Camera playerCamera;

    [Header("Audio")]
    public AudioClip footstepSound;
    // Notice the timer variables are gone! We don't need them for continuous loops.

    private AudioSource audioSource;
    private CharacterController controller;
    private float verticalLookRotation = 0f;
    private Vector3 velocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        // 1. SET UP THE AUDIO SOURCE AUTOMATICALLY
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = footstepSound;
        audioSource.loop = true; // CRITICAL: This tells the long clip to loop forever
        audioSource.playOnAwake = false; // Makes sure you don't hear walking before you move

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // 1. MOUSE LOOK
        float mouseX = Input.GetAxis("Mouse X") * lookSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * lookSensitivity;

        transform.Rotate(Vector3.up * mouseX);

        verticalLookRotation -= mouseY;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);
        playerCamera.transform.localEulerAngles = Vector3.right * verticalLookRotation;

        // 2. WASD MOVEMENT
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        controller.Move(move * walkSpeed * Time.deltaTime);

        // 3. GRAVITY
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        // 4. CONTINUOUS FOOTSTEP AUDIO LOGIC
        // We check if the player is touching the ground AND pushing a movement key
        bool isWalking = controller.isGrounded && move.magnitude > 0.1f;

        if (isWalking)
        {
            // If we are walking but the audio isn't playing yet, start it
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            // If we stop walking but the audio is still playing, pause it right where it is
            if (audioSource.isPlaying)
            {
                audioSource.Pause();
                // Note: We use Pause() instead of Stop() so that when you walk again, 
                // the audio resumes from the exact second you left off!
            }
        }
    }
}
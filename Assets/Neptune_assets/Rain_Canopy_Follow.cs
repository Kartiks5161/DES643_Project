using UnityEngine;

public class RainFollow : MonoBehaviour
{
    [Tooltip("Drag your Main Camera here")]
    public Transform vrCamera;

    [Tooltip("How high above your head the rain starts")]
    public float rainHeight = 10f;

    void Update()
    {
        if (vrCamera != null)
        {
            // Moves the rain to exactly over the user's head, no matter where they walk
            transform.position = new Vector3(vrCamera.position.x, vrCamera.position.y + rainHeight, vrCamera.position.z);

            // Forces the emitter to always aim straight down, ignoring VR head tilt
            transform.rotation = Quaternion.Euler(90f, 0f, 0f);
        }
    }
}
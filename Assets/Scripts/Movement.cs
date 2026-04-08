using UnityEngine;

public class MobileMovement : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        // ALSO WORKS IN EDITOR (mouse)
        if (Input.GetMouseButton(0))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        // MOBILE TOUCH
        if (Input.touchCount > 0)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}
using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    public float speedX = 0.01f;
    public float speedY = 0.0f;

    private Renderer rend;
    private Vector2 offset;

    void Start()
    {
        rend = GetComponent<Renderer>();
        offset = Vector2.zero;
    }

    void Update()
    {
        offset.x += speedX * Time.deltaTime;
        offset.y += speedY * Time.deltaTime;

        rend.material.mainTextureOffset = offset;
    }
}
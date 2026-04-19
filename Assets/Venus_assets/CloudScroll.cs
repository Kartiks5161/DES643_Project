using UnityEngine;

public class CloudScroll : MonoBehaviour
{
    public float speed = 0.01f;
    private Material mat;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    void Update()
    {
        Vector2 offset = mat.mainTextureOffset;
        offset.y += speed * Time.deltaTime;
        mat.mainTextureOffset = offset;
    }
}
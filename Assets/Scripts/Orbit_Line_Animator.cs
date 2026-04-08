using UnityEngine;

public class OrbitLineAnimator : MonoBehaviour
{
    public float scrollSpeed = 0.5f;

    private LineRenderer line;
    private Material mat;
    private float offset = 0f;

    void Start()
    {
        line = GetComponent<LineRenderer>();

        if (line != null)
        {
            mat = line.material;
        }
    }

    void Update()
    {
        if (mat == null) return;

        offset += Time.deltaTime * scrollSpeed;

        // Animate texture movement
        mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
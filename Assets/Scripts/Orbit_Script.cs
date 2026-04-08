using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class PlanetOrbit : MonoBehaviour
{
    [Header("Center Object")]
    public Transform centerObject;

    [Header("Orbit Shape")]
    public float semiMajorAxis = 10f;   // a
    public float semiMinorAxis = 9f;    // b

    [Header("Motion")]
    public float speed = 0.2f;          // slow for realism
    public float phaseOffset = 0f;      // use π for opposite objects

    [Header("Orbit Path")]
    public int segments = 120;
    public float lineWidth = 0.01f;
    public Color lineColor = new Color(1, 1, 1, 0.4f);

    private float angle;
    private LineRenderer line;

    void Start()
    {
        line = GetComponent<LineRenderer>();

        // Random start position (natural look)
        angle = Random.Range(0f, 2 * Mathf.PI);

        // Setup line renderer
        line.positionCount = segments + 1;
        line.loop = true;

        line.startWidth = lineWidth;
        line.endWidth = lineWidth;

        line.material = new Material(Shader.Find("Sprites/Default"));
        line.startColor = lineColor;
        line.endColor = lineColor;

        DrawOrbit();
    }

    void Update()
    {
        if (centerObject == null) return;

        angle += speed * Time.deltaTime;

        float x = Mathf.Cos(angle + phaseOffset) * semiMajorAxis;
        float z = Mathf.Sin(angle + phaseOffset) * semiMinorAxis;

        transform.position = centerObject.position + new Vector3(x, 0, z);
    }

    void DrawOrbit()
    {
        if (centerObject == null) return;

        for (int i = 0; i <= segments; i++)
        {
            float ang = i * 2 * Mathf.PI / segments;

            float x = Mathf.Cos(ang) * semiMajorAxis;
            float z = Mathf.Sin(ang) * semiMinorAxis;

            Vector3 pos = new Vector3(x, 0, z) + centerObject.position;
            line.SetPosition(i, pos);
        }
    }
}
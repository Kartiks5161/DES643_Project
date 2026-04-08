using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Orbit_path : MonoBehaviour
{
    public Transform centerObject;
    public float radius = 10f;
    public int segments = 100;

    [Header("Line Settings")]
    public float lineWidth = 0.02f;   // 👈 THIS is your input box
    public Color lineColor = Color.white;

    private LineRenderer line;

    void Start()
    {
        line = GetComponent<LineRenderer>();

        // Set line properties
        line.positionCount = segments + 1;
        line.loop = true;

        // 👇 WIDTH CONTROL (your main goal)
        line.startWidth = lineWidth;
        line.endWidth = lineWidth;

        // 👇 COLOR CONTROL
        line.startColor = lineColor;
        line.endColor = lineColor;

        DrawOrbit();
    }

    void DrawOrbit()
    {
        for (int i = 0; i <= segments; i++)
        {
            float angle = i * 2 * Mathf.PI / segments;

            float x = Mathf.Cos(angle) * radius;
            float z = Mathf.Sin(angle) * radius;

            Vector3 pos = new Vector3(x, 0, z);

            if (centerObject != null)
                pos += centerObject.position;

            line.SetPosition(i, pos);
        }
    }
}
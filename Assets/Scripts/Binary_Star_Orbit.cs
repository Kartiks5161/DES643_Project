using UnityEngine;

public class BinaryStarOrbit : MonoBehaviour
{
    [Header("References")]
    public Transform starA;
    public Transform starB;
    public Transform centerObject;

    [Header("Orbit Shape")]
    public float semiMajorAxis = 5f;
    public float semiMinorAxis = 4.5f;

    [Header("Motion")]
    public float speed = 0.2f;

    private float angle;

    void Start()
    {
        angle = Random.Range(0f, 2 * Mathf.PI);
    }

    void Update()
    {
        if (centerObject == null || starA == null || starB == null) return;

        angle += speed * Time.deltaTime;

        // Star A position
        float xA = Mathf.Cos(angle) * semiMajorAxis;
        float zA = Mathf.Sin(angle) * semiMinorAxis;

        Vector3 posA = centerObject.position + new Vector3(xA, 0, zA);

        // Star B = opposite side (angle + π)
        float xB = Mathf.Cos(angle + Mathf.PI) * semiMajorAxis;
        float zB = Mathf.Sin(angle + Mathf.PI) * semiMinorAxis;

        Vector3 posB = centerObject.position + new Vector3(xB, 0, zB);

        starA.position = posA;
        starB.position = posB;
    }
}
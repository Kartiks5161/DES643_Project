using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float intensity = 0.01f;

    void Update()
    {
        transform.localPosition += Random.insideUnitSphere * intensity * Time.deltaTime;
    }
}
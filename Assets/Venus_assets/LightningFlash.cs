using UnityEngine;

public class LightningFlash : MonoBehaviour
{
    public Light lightningLight;
    public float minDelay = 5f;
    public float maxDelay = 15f;

    void Start()
    {
        InvokeRepeating(nameof(Flash), Random.Range(minDelay, maxDelay), Random.Range(minDelay, maxDelay));
    }

    void Flash()
    {
        StartCoroutine(FlashRoutine());
    }

    System.Collections.IEnumerator FlashRoutine()
    {
        lightningLight.intensity = Random.Range(3f, 6f);
        yield return new WaitForSeconds(0.05f);

        lightningLight.intensity = 0f;
    }
}
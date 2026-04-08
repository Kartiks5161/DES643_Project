using UnityEngine;

public class PlanetHighlight : MonoBehaviour
{
    private Material mat;
    private Color originalEmission;
    public Color highlightEmission = Color.cyan;
    public float glowIntensity = 3f;

    void Start()
    {
        mat = GetComponent<Renderer>().material;

        // Store original emission
        if (mat.IsKeywordEnabled("_EMISSION"))
            originalEmission = mat.GetColor("_EmissionColor");
        else
            originalEmission = Color.black;
    }

    void OnMouseEnter()
    {
        mat.EnableKeyword("_EMISSION");
        mat.SetColor("_EmissionColor", highlightEmission * glowIntensity);
    }

    void OnMouseExit()
    {
        mat.SetColor("_EmissionColor", originalEmission);
    }
}
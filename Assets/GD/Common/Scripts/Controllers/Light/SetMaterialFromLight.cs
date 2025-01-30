using UnityEngine;

/// <summary>
/// Sets the emissive color of a material based on a light's color and intensity.
/// </summary>
[RequireComponent(typeof(Renderer))]
[ExecuteAlways] // Ensures the script runs in both Play mode and Edit mode
public class SetMaterialFromLight : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The light component to use as a reference for the emissive color.")]
    private Light targetLight;

    [SerializeField]
    [Tooltip("The material to modify.")]
    private Material material;

    [SerializeField, Range(0f, 2f)]
    [Tooltip("A multiplier for the emissive intensity.")]
    private float emissiveIntensityMultiplier = 1f;

    private void Update()
    {
        if (material == null || targetLight == null)
            return;

        // Scale the emissive color by the light's intensity and multiplier
        Color emissiveColor = targetLight.color * targetLight.intensity * emissiveIntensityMultiplier;
        material.SetColor("_EmissionColor", emissiveColor);

        // Enable the emission keyword for the material
        material.EnableKeyword("_EMISSION");
    }
}
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Reference to the light component")]
    private Light lightSource;

    [SerializeField]
    [Tooltip("Minimum intensity of the light")]
    private float minIntensity = 0.5f;

    [SerializeField]
    [Tooltip("Maximum intensity of the light")]
    private float maxIntensity = 1.5f;

    [SerializeField]
    [Tooltip("Minimum speed of flicker")]
    private float minFlickerSpeed = 0.1f;

    [SerializeField]
    [Tooltip("Maximum speed of flicker")]
    private float maxFlickerSpeed = 2.0f;

    private float targetIntensity; // The current target intensity to lerp towards
    private float flickerSpeed; // The current speed of flicker
    private float flickerTimer; // Timer to switch target intensity

    private void Start()
    {
        if (lightSource == null)
        {
            lightSource = GetComponent<Light>();
        }

        // Set an initial target intensity and flicker speed
        SetRandomFlickerSettings();
    }

    private void Update()
    {
        if (lightSource == null) return;

        // Gradually move the light intensity towards the target
        lightSource.intensity = Mathf.Lerp(lightSource.intensity, targetIntensity, Time.deltaTime * flickerSpeed);

        // Reduce the timer and change the target intensity and flicker speed when the timer reaches zero
        flickerTimer -= Time.deltaTime;
        if (flickerTimer <= 0)
        {
            SetRandomFlickerSettings();
        }
    }

    private void SetRandomFlickerSettings()
    {
        targetIntensity = Random.Range(minIntensity, maxIntensity);
        flickerSpeed = Random.Range(minFlickerSpeed, maxFlickerSpeed);
        flickerTimer = Random.Range(0.05f, 0.2f); // Randomize the time before the next flicker
    }
}
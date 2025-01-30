using UnityEngine;

/// <summary>
/// Use as attribute with AudioClip to add a "▶" button to preview audio
/// </summary>
/// <example>
///
/// [AudioClipButton]
/// public AudioClip myClip1;
///
/// [AudioClipButton(volume = 0.5f, pitch = 2]
/// public AudioClip myClip2;
///
/// </example>
public class AudioClipButtonAttribute : PropertyAttribute
{
    public float volume = 1;
    public float pitch = 1;

    public AudioClipButtonAttribute(float volume = 1, float pitch = 1)
    {
        this.volume = volume >= 0 && volume <= 1 ? volume : 1;
        this.pitch = pitch >= 0.1f && pitch <= 3 ? pitch : 1;
    }
}
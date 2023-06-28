using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Tooltip("Audio source")]
    [SerializeField]
    private AudioSource Source;
    [Tooltip("Is muted")]
    [SerializeField]
    private BoolVariable IsMuted;

    /// <summary>
    /// Play dice sound
    /// </summary>
    public void Play()
    {
        Source.Play();
    }

    /// <summary>
    /// Toggle sound settings
    /// </summary>
    public void ToggleSoundSettings() {
        Source.mute = IsMuted.value;
    }
}

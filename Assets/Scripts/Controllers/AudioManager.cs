using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public const string IS_MUTED = "IS_MUTED";

    public AudioSource source;
    public BoolVariable IsMuted;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }
    public void Play()
    {
        source.Play();
    }

    public void FlipSoundSettings() {
        source.mute = IsMuted.value;
    }
}

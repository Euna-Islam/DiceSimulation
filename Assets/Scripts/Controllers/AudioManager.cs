using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource source;
    [SerializeField]
    private BoolVariable IsMuted;

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

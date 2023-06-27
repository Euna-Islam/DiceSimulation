using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public const string IS_MUTED = "IS_MUTED";

    public AudioSource source;
    public BoolVariable IsMuted;

    private void Start()
    {
        //CheckPlayerPref();

        source = GetComponent<AudioSource>();

        //if (isSoundOn)
        //{
        //    speakerBtn.SetActive(true);
        //    muteBtn.SetActive(false);
        //}
        //else
        //{
        //    speakerBtn.SetActive(false);
        //    muteBtn.SetActive(true);
        //}
    }

    void CheckPlayerPref() {
        /*
         * check if player preference is saved for sound mute/unmute
         */
        if (PlayerPrefs.HasKey(IS_MUTED))
        {
            IsMuted.value = PlayerPrefs.GetInt(IS_MUTED) == 0 ? true : false;
        }
        else
        {
            IsMuted.value = false;
            PlayerPrefs.SetInt(IS_MUTED, 0);
        }
    }


    public void Play()
    {
        source.Play();
    }

    public void FlipSoundSettings() {
        source.mute = IsMuted.value;
    }
}

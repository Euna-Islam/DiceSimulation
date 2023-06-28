using UnityEngine;
using UnityEngine.UI;

public class ButtonSprite : MonoBehaviour
{
    private const string IS_MUTED = "IS_MUTED";
    [Tooltip("Mute Unmute sprites")]
    [SerializeField]
    private SpriteVariable Mute, Unmute;
    [Tooltip("Is muted SO")]
    [SerializeField]
    private BoolVariable IsMuted;
    [Tooltip("Event for change in sound setting")]
    [SerializeField]
    private GameEvent SoundEvent;

    private void Start()
    {
        CheckPlayerPref();
        UpdateSprite();
    }
    /// <summary>
    /// at the beginning check player prefs for sound settings
    /// </summary>
    void CheckPlayerPref()
    {
        /*
         * check if player preference is saved for sound mute/unmute
         */
        if (PlayerPrefs.HasKey(IS_MUTED))
        {
            IsMuted.value = PlayerPrefs.GetInt(IS_MUTED) == 0 ? false : true;
        }
        else
        {
            IsMuted.value = false;
            PlayerPrefs.SetInt(IS_MUTED, 0);
        }
    }
    /// <summary>
    /// Toggle sound settings
    /// </summary>
    public void ToggleSoundSettings() {
        IsMuted.FlipBool();
        PlayerPrefs.SetInt(IS_MUTED, IsMuted.value ? 1 : 0);
        UpdateSprite();
    }
    /// <summary>
    /// Update the button sprite for mute/unmute
    /// </summary>
    public void UpdateSprite() {
        GetComponent<Image>().sprite = IsMuted.value ? Mute.Sprite : Unmute.Sprite;
        SoundEvent.Raise();
    }
}

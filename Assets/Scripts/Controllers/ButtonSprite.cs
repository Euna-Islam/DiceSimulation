using UnityEngine;
using UnityEngine.UI;

public class ButtonSprite : MonoBehaviour
{
    private const string IS_MUTED = "IS_MUTED";
    [SerializeField]
    private SpriteVariable Mute, Unmute;
    [SerializeField]
    private BoolVariable IsMuted;
    [SerializeField]
    private GameEvent SoundEvent;

    private void Start()
    {
        CheckPlayerPref();
        UpdateSprite();
    }
    /*
    <summary>
        Description
        Input
        Return
    </summary>
    */
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
    public void FlipSoundSettings() {
        IsMuted.FlipBool();
        PlayerPrefs.SetInt(IS_MUTED, IsMuted.value ? 1 : 0);
        UpdateSprite();
    }

    public void UpdateSprite() {
        GetComponent<Image>().sprite = IsMuted.value ? Mute.Sprite : Unmute.Sprite;
        SoundEvent.Raise();
    }
}

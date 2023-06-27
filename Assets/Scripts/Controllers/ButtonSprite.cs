using UnityEngine;
using UnityEngine.UI;

public class ButtonSprite : MonoBehaviour
{
    public const string IS_MUTED = "IS_MUTED";

    public SpriteVariable Mute, Unmute;

    public BoolVariable IsMuted;

    public GameEvent SoundEvent;

    public void FlipSoundSettings() {
        IsMuted.FlipBool();
        GetComponent<Image>().sprite = IsMuted.value ? Mute.Sprite : Unmute.Sprite;
        SoundEvent.Raise();
    }

    

}

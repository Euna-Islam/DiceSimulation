using System;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI timeNow;

    public GameObject speakerBtn;
    public GameObject muteBtn;

    private void Start()
    {
        InvokeRepeating("UpdateTime", 0f, 1f);
    }

    void UpdateTime()
    {
        /*
         * display current hour and minute in the UI
         */
        DateTime current = DateTime.Now;
        int hour = current.Hour;
        string hourString = "";
        string minuteString = "";
        if (hour.ToString().Length < 2)
        {
            hourString = "0" + hour.ToString();
        }
        else
        {
            hourString = hour.ToString();
        }

        int minute = current.Minute;

        if (minute.ToString().Length < 2)
        {
            minuteString = "0" + minute.ToString();
        }
        else
        {
            minuteString = minute.ToString();
        }

        timeNow.text = hourString + ":" + minuteString;

    }

    //public void FlipSoundSprite() {
    //    speakerBtn.SetActive(false);
    //    muteBtn.SetActive(true);
    //}
}

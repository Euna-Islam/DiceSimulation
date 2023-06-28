using System;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Tooltip("Current time text field")]
    [SerializeField]
    private TextMeshProUGUI TimeNow;
    [Tooltip("Score text field")]
    [SerializeField]
    private TextMeshProUGUI ScoreText;

    [SerializeField]
    private IntVariable Score;
    [SerializeField]
    private DiceRuntimeSet DiceSet;

    private void Start()
    {
        InvokeRepeating("UpdateTime", 0f, 1f);
    }

    /// <summary>
    /// display current hour and minute
    /// </summary>
    void UpdateTime()
    {
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

        TimeNow.text = hourString + ":" + minuteString;

    }

    /// <summary>
    /// Update the UI score
    /// </summary>
    public void UpdateScore() {
        Score.value = 0;
 
        foreach (Dice dice in DiceSet.Items)
        {
            Score.value += dice.DiceScore;
        }
        ScoreText.text = "Score: " + Score.value.ToString();
    }
}

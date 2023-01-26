using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public const int MAX_DICE = 8;

    public AudioSource source;
    public bool isSoundOn;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeNow;

    public GameObject dicePrefab;
    public Stack diceList;
    public GameObject speakerBtn;
    public GameObject muteBtn;

    int score;

    /*
     * Add new dice when plus button is clicked
     * to keep track of the dice, add it to list
     */
    public void AddNewPrefab()
    {
        if (diceList.Count < MAX_DICE)
        {
            GameObject newDice = Instantiate(dicePrefab, new Vector3(UnityEngine.Random.Range(-2.5f,2.5f), 6, UnityEngine.Random.Range(-1.5f, 1.5f)), dicePrefab.transform.rotation);
            diceList.Push(newDice);
        }
    }

    /*
     * Remove and destroy one dice when minus button is clicked
     */
    public void RemovePrefab()
    {
        if (diceList.Count > 0)
        {
            GameObject lastDice = (GameObject)diceList.Pop();
            Destroy(lastDice);
        }    
    }

    /*
     * count final score by adding the score of each dice
     */
    public void CalculateScoreandDisplay()
    {
        score = 0;
        foreach (GameObject dice in diceList)
        {
            score += dice.GetComponent<Dice>().diceScore;
        }
        scoreText.text = "Score: " + score.ToString();
    }

    public void SoundOn()
    {
        isSoundOn = false;
        speakerBtn.SetActive(false);
        muteBtn.SetActive(true);
        PlayerPrefs.SetInt("isSoundOn", 0);
    }
    public void MuteAudio()
    {
        isSoundOn = true;
        speakerBtn.SetActive(true);
        muteBtn.SetActive(false);
        PlayerPrefs.SetInt("isSoundOn", 1);
    }

    /*
     * Roll all dices when tap is detected
     */
    public void RollAllDice()
    {
        foreach (GameObject dice in diceList)
        {
            dice.GetComponent<Dice>().RollDice();
        }
    }
   
    public void Update()
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

    void Start()
    {
        instance = this;
        diceList = new Stack();
        /*
         * check if player preference is saved for sound mute/unmute
         */
        if (PlayerPrefs.HasKey("isSoundOn"))
        {
            isSoundOn = PlayerPrefs.GetInt("isSoundOn") == 0 ? false : true;
        }
        else
        {
            isSoundOn = true;
            PlayerPrefs.SetInt("isSoundOn", 1);
        }

        source = GetComponent<AudioSource>();

        if (isSoundOn)
        {
            speakerBtn.SetActive(true);
            muteBtn.SetActive(false);
        }
        else
        {
            speakerBtn.SetActive(false);
            muteBtn.SetActive(true);
        }
    }
}

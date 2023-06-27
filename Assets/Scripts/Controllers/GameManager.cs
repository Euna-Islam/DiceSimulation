using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public const int MAX_DICE = 8;

    public TextMeshProUGUI scoreText;

    

    int score;

    

    /*
     * count final score by adding the score of each dice
     */
    public void CalculateScoreandDisplay()
    {
        score = 0;
        //foreach (GameObject dice in diceList)
        //{
        //    score += dice.GetComponent<Dice>().diceScore;
        //}
        scoreText.text = "Score: " + score.ToString();
    }


   
    

    void Start()
    {
        instance = this;
    }
}

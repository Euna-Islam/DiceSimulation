using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public const int MAX_DICE = 8;

    public TextMeshProUGUI scoreText;

    public GameObject dicePrefab;
    public Stack diceList;

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
   
    

    void Start()
    {
        instance = this;
        diceList = new Stack();
        
    }
}

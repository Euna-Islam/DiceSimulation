using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceController : MonoBehaviour
{
    public GameObject dicePrefab;
    public Stack diceList;

    public IntVariable MAX_DICE;

    public IntVariable Score;

    /*
     * Add new dice when plus button is clicked
     * to keep track of the dice, add it to list
     */
    public void AddNewPrefab()
    {
        if (diceList.Count < MAX_DICE.value)
        {
            GameObject newDice = Instantiate(dicePrefab, new Vector3(UnityEngine.Random.Range(-2.5f, 2.5f), 6, UnityEngine.Random.Range(-1.5f, 1.5f)), dicePrefab.transform.rotation);
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

    //public void CalculateScore() {
    //    Score.value = 0;
    //    foreach (GameObject dice in diceList)
    //    {
    //        Score.value += dice.GetComponent<Dice>().diceScore;
    //    }
    //}

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

    private void Start()
    {
        diceList = new Stack();
    }
}

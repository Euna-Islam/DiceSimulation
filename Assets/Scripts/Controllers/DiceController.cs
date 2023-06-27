using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class DiceController : MonoBehaviour
{
    [SerializeField]
    private GameObject DicePrefab;
    private Stack DicesOnBoard;

    [SerializeField]
    private IntVariable MaxNoOfDice;

    private ObjectPool<GameObject> DicePool;

    private void Start()
    {
        DicesOnBoard = new Stack();

        DicePool = new ObjectPool<GameObject>(() =>
        { return Instantiate(DicePrefab); },
        dice => { dice.SetActive(true); },
        dice => { dice.SetActive(false); },
        dice => { Destroy(dice); },
        false,
        MaxNoOfDice.value,
        MaxNoOfDice.value
        );
    }

    /*
     * Add new dice when plus button is clicked
     * to keep track of the dice, add it to list
     */
    public void AddNewPrefab()
    {
        if (DicesOnBoard.Count < MaxNoOfDice.value)
        {
            GameObject newDice = DicePool.Get();// Instantiate(DicePrefab, new Vector3(Random.Range(-2.5f, 2.5f), 6, Random.Range(-1.5f, 1.5f)), DicePrefab.transform.rotation);

            newDice.transform.position = new Vector3(Random.Range(-2.5f, 2.5f), 6, Random.Range(-1.5f, 1.5f));
            newDice.transform.rotation = DicePrefab.transform.rotation;

            DicesOnBoard.Push(newDice);
        }
    }

    /*
     * Remove and destroy one dice when minus button is clicked
     */
    public void RemovePrefab()
    {
        if (DicesOnBoard.Count > 0)
        {
            GameObject lastDice = (GameObject)DicesOnBoard.Pop();
            DicePool.Release(lastDice);
        }
    }

    ///*
    // * Roll all dices when tap is detected
    // */
    //public void RollAllDice()
    //{
    //    foreach (GameObject dice in DicesOnBoard)
    //    {
    //        dice.GetComponent<Dice>().RollDice();
    //    }
    //}


}

using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class DiceController : MonoBehaviour
{
    [Tooltip("Dice Prefab")]
    [SerializeField]
    private GameObject DicePrefab;
    //List of dices on board
    private Stack DicesOnBoard;
    [Tooltip("Max no of dice allowed")]
    [SerializeField]
    private IntVariable MaxNoOfDice;

    [SerializeField]
    private FloatVariable BoardWidth, BoardLength, DiceInitialHeight;
    //Dice Pool
    private ObjectPool<GameObject> DicePool;

    private void Start()
    {
        DicesOnBoard = new Stack();
        //Initialize the pool
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

    /// <summary>
    /// Add new dice when plus button is clicked
    /// to keep track of the dice, add it to list
    /// </summary>
    public void AddDice()
    {
        if (DicesOnBoard.Count < MaxNoOfDice.value)
        {
            GameObject newDice = DicePool.Get();
            newDice.transform.position = new Vector3(Random.Range(-BoardLength.Value, BoardLength.Value), DiceInitialHeight.Value, Random.Range(-BoardWidth.Value, BoardWidth.Value));
            newDice.transform.rotation = DicePrefab.transform.rotation;

            DicesOnBoard.Push(newDice);
        }
    }

    /// <summary>
    /// remove dice from the board
    /// </summary>
    public void RemoveDice()
    {
        if (DicesOnBoard.Count > 0)
        {
            GameObject lastDice = (GameObject)DicesOnBoard.Pop();
            DicePool.Release(lastDice);
        }
    }
}

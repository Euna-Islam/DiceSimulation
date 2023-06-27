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

    [SerializeField]
    private FloatVariable BoardWidth, BoardLength, DiceInitialHeight;

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
            GameObject newDice = DicePool.Get();
            newDice.transform.position = new Vector3(Random.Range(-BoardLength.Value, BoardLength.Value), DiceInitialHeight.Value, Random.Range(-BoardWidth.Value, BoardWidth.Value));
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
}

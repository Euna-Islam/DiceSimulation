using UnityEngine;

public class DiceSide : MonoBehaviour
{
    public int sideValue;
    public GameObject dice;

    /*
     * when the dice is on the ground, update the dice score
     * with the upper side value
     */
    void OnTriggerStay(Collider col)
    {
        if (col.tag == "Ground")
        {
            dice.GetComponent<Dice>().UpdateDiceScore(sideValue);
        } 
    }
}

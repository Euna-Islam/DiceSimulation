using UnityEngine;

public class DiceSide : MonoBehaviour
{
    [Tooltip("Value of the opposite side")]
    [SerializeField]
    private int SideValue;
    [Tooltip("Reference to parent dice")]
    [SerializeField]
    private GameObject Dice;

    /// <summary>
    /// when the dice is on the ground, update the dice score
    /// with the upper side value
    /// </summary>
    /// <param name="col"></param>
    void OnTriggerStay(Collider col)
    {
        if (col.tag == "Ground")
        {
            Dice.GetComponent<Dice>().UpdateDiceScore(SideValue);
        } 
    }
}

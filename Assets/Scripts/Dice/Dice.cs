using UnityEngine;

public class Dice : MonoBehaviour
{
    Rigidbody Rb;
    [Tooltip("Dice score side value")]
    public int DiceScore;
    [Tooltip("List of all sides of a dice")]
    public DiceSide[] DiceSides;

    #region Configuration
    [SerializeField]
    private GameEvent SoundEvent, ScoreEvent;
    [SerializeField]
    private DiceRuntimeSet DiceSet;
    [SerializeField]
    private IntVariable MinTorque, MaxTorque, Force;
    #endregion

    /// <summary>
    /// on enable add this object to runtime dice set
    /// </summary>
    private void OnEnable()
    {
        DiceSet.Add(this);
    }

    /// <summary>
    /// on disable remove from runtime dice set
    /// </summary>
    private void OnDisable()
    {
        DiceSet.Remove(this);
    }

    void Start()
    {
        Rb = GetComponent<Rigidbody>();
        ThrowDice();
    }

    /// <summary>
    /// throw dice on board
    /// </summary>
    public void ThrowDice()
    {
        Rb.AddTorque(Random.Range(MinTorque.value, MaxTorque.value), Random.Range(MinTorque.value, MaxTorque.value), Random.Range(MinTorque.value, MaxTorque.value));
    }

    /// <summary>
    /// roll the dice after landing on board
    /// </summary>
    public void RollDice()
    {
        if (Rb.velocity.magnitude == 0)
        {
            Rb.AddForce(0, Force.value, 0, ForceMode.Force);
            ThrowDice();
        }
    }

    /// <summary>
    /// update dice score after landing
    /// </summary>
    /// <param name="sideValue">dice score side</param>
    public void UpdateDiceScore(int sideValue)
    {
        DiceScore = sideValue;

        if (Rb.IsSleeping())
        {
            ScoreEvent.Raise();
        }
    }

    /// <summary>
    /// on touching the ground, raise sound event
    /// </summary>
    /// <param name="col"></param>
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Ground")
        {
            SoundEvent.Raise();
        }
    }
}

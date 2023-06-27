using UnityEngine;

public class Dice : MonoBehaviour
{
    Rigidbody rb;

    public int diceScore;

    public DiceSide[] diceSides;

    public GameEvent SoundEvent, ScoreEvent;

    public DiceRuntimeSet DiceSet;

    private void OnEnable()
    {
        DiceSet.Add(this);
    }

    private void OnDisable()
    {
        DiceSet.Remove(this);
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddTorque(Random.Range(0, 500), Random.Range(0, 500), Random.Range(0, 500));
        ThrowDice();
    }

    /*
     * throw the dice on board
     */
    public void ThrowDice()
    {
        rb.AddTorque(Random.Range(0, 500), Random.Range(0, 500), Random.Range(0, 500));
    }

    /*
     * roll the dice on tap
     */
    public void RollDice()
    {
        if (rb.velocity.magnitude == 0)
        {
            rb.AddForce(0, 1000f, 0, ForceMode.Force);
            rb.AddTorque(Random.Range(0, 500), Random.Range(0, 500), Random.Range(0, 500));
        }
    }

    /*
     * update the dice score by value of upper side
     */
    public void UpdateDiceScore(int sideValue)
    {
        diceScore = sideValue;

        if (rb.IsSleeping())
        {
            ScoreEvent.Raise();
        }
    }

    /*
     * play roll sound when dice collides with ground
     */
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Ground"/* && GameManager.instance.isSoundOn*/)
        {
            SoundEvent.Raise();
            //GameManager.instance.source.Play();
        }
    }
}

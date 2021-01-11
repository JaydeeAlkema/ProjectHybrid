using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetBehaviour : MonoBehaviour
{
    enum PetStates 
    { 
        Idle = 0,
        Panicking = 1
    }    
    enum IdleStates 
    { 
        StandingStill = 0,
        MovingLeft = 1,
        MovingRight = 2
    }
    [SerializeField] private float maxBounds = 4f;
    [SerializeField] private float petMaxSpeed = 2f;
    [SerializeField] private float petMovementSpeed = 2f;
    [SerializeField] private float petPanickMovementSpeed = 2f;
    [SerializeField] private PetStates currentState = PetStates.Idle;
    [SerializeField] private IdleStates idleState = IdleStates.StandingStill;
    [SerializeField] private Vector2Int timeBetweenIdleActions = new Vector2Int(500,1000);
    [SerializeField] private int timer = 300;
    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (currentState == PetStates.Idle)
        {
            if (timer < 0)
            {
                timer = SetTimerToTimeBetweenActions(timeBetweenIdleActions);
                ChangeToRandomIdleStateWithinBounds();
            }

            if (idleState == IdleStates.MovingLeft)
            {
                if (rb2d.velocity.x < petMaxSpeed && rb2d.velocity.x > -petMaxSpeed)
                {
                    transform.localScale = new Vector3(-1,1,1);
                    rb2d.AddForce(new Vector2(-petMovementSpeed, 0));
                }
            }
            if (idleState == IdleStates.MovingRight)
            {
                if (rb2d.velocity.x < petMaxSpeed && rb2d.velocity.x > -petMaxSpeed)
                {
                    transform.localScale = new Vector3(1,1,1);
                    rb2d.AddForce(new Vector2(petMovementSpeed, 0));
                }
            }
        }
        if (currentState == PetStates.Panicking)
        {
            if (timer < 0)
            {
                timer = SetTimerToTimeBetweenActions(timeBetweenIdleActions);
                ChangeToRandomIdleStateWithinBounds();
            }

            if (idleState == IdleStates.MovingLeft)
            {

                rb2d.AddForce(new Vector2(-petPanickMovementSpeed, 0));
            }
            if (idleState == IdleStates.MovingRight)
            {

                rb2d.AddForce(new Vector2(petPanickMovementSpeed, 0));
            }
        }


        timer--;
    }
    public int SetTimerToTimeBetweenActions(Vector2Int timeBetween)
    {
        return Random.Range(timeBetween.x, timeBetween.y);
    }

    public void ChangeToRandomIdleStateWithinBounds()
    {
        if (transform.position.x > maxBounds)
        {
            idleState = IdleStates.MovingLeft;
            return;
        }
        if (transform.position.x < -maxBounds)
        {
            idleState = IdleStates.MovingRight;
            return;
        }

        int random = Random.Range(0,9);
        if (random < 3)
        {
            idleState = IdleStates.StandingStill;
        } 
        else if (random > 3 && random < 6)
        {
            idleState = IdleStates.MovingLeft;
        } 
        else if (random > 6)
        {
            idleState = IdleStates.MovingRight;
        }

    }
    
}

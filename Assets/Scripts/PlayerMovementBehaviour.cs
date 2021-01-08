using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBehaviour : MonoBehaviour
{
	[SerializeField]
	private Vector2 moveSpeed = new Vector2(2.5f,0);
	[SerializeField]
	private float maxSpeed = 2;
	private Rigidbody2D rb2d;

	private bool walkingLeft = false;
	private bool walkingRight = false;

	void Start()
	{
		rb2d = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		float horizontal = Input.GetAxis("Horizontal");
        //MovePlayer(horizontal);
        if (walkingLeft)
        {
			if (rb2d.velocity.x < maxSpeed && rb2d.velocity.x > -maxSpeed)
			{
				rb2d.AddForce(-moveSpeed);
			}
		}
		if (walkingRight)
        {
			if (rb2d.velocity.x < maxSpeed && rb2d.velocity.x > -maxSpeed)
			{
				rb2d.AddForce(moveSpeed);
			}
		}
	}

	public void MovePlayer(float direction)
	{
		Vector2 move = new Vector2(direction, 0);
		//transform.Translate(move * Time.deltaTime * moveSpeed);
		if(rb2d.velocity.x < maxSpeed && rb2d.velocity.x > -maxSpeed)
		{
			rb2d.AddForce(move);
		}
	}

	public void EnableWalkLeft()
    {
		walkingLeft = true;
    }
	public void DisableWalkLeft()
    {
		walkingLeft = false;
    }
	public void EnableWalkRight()
    {
		walkingRight = true;
    }
	public void DisableWalkRight()
    {
		walkingRight = false;
    }

}

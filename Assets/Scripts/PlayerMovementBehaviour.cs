using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovementBehaviour : MonoBehaviour
{
	[SerializeField] private Animator anim;
	[SerializeField] private float moveSpeed = 2f;

	float horizontal;
	Rigidbody2D rb2d;
	float scaleX;

	void Start()
	{
		anim = GetComponentInChildren<Animator>();
		rb2d = GetComponent<Rigidbody2D>();

		scaleX = transform.localScale.x;
	}

	void Update()
	{
		horizontal = CrossPlatformInputManager.GetAxis("Horizontal") * moveSpeed;
		SetRotation((int)CrossPlatformInputManager.GetAxis("Horizontal"));
		MovePlayer(horizontal);
	}

	public void MovePlayer(float direction)
	{
		rb2d.velocity = new Vector2(direction * Time.deltaTime, 0f);
	}

	public void SetRotation(int dir)
	{
		if(dir == 1)
		{
			anim.SetBool("Walk", true);
			transform.localScale = new Vector3(-scaleX, transform.localScale.y, transform.localScale.z);
		}
		else if(dir == -1)
		{
			anim.SetBool("Walk", true);
			transform.localScale = new Vector3(scaleX, transform.localScale.y, transform.localScale.z);
		}
		else
		{
			anim.SetBool("Walk", false);
			anim.SetBool("Idle", true);

		}
	}
}

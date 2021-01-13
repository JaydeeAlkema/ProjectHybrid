using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NPCStates
{
	Idle = 0,
	Walking = 1,
	Panicking = 2,
	Angry = 3,
	Happy = 4
}

public class NPCBehaviour : MonoBehaviour
{
	[SerializeField] private Animator anim;
	[Space]
	[SerializeField] private Vector3 targetPos = default;
	[SerializeField] private float maxBounds = 4f;
	[SerializeField] private float movementSpeed = 2f;
	[SerializeField] private float panicMovementSpeed = 3f;
	[Space]
	[SerializeField] private NPCStates currentState = NPCStates.Idle;
	[SerializeField] private Vector2Int timeBetweenActions = new Vector2Int(1, 3);
	[Space]
	[SerializeField] private string idleAnimation = "";
	[SerializeField] private string walkAnimation = "";
	[SerializeField] private string panicAnimation = "";
	[SerializeField] private string angryAnimation = "";
	[SerializeField] private string happyAnimation = "";
	[Space]
	[SerializeField] private bool inverseSpriteFlipX = true;

	void Start()
	{
		anim = GetComponentInChildren<Animator>();

		SetState(NPCStates.Walking);
		SetRandomTargetPosition();
		StartCoroutine(HandleRandomMovement());
	}

	private IEnumerator HandleRandomMovement()
	{
		while(true)
		{
			float finalMovementSpeed = (currentState == NPCStates.Walking) ? movementSpeed : panicMovementSpeed;
			float step = finalMovementSpeed * Time.deltaTime;
			Vector3 desiredPos = new Vector3(targetPos.x, transform.position.y, transform.position.z);
			transform.position = Vector3.MoveTowards(transform.position, desiredPos, step);

			if(currentState == NPCStates.Walking || currentState == NPCStates.Panicking)
			{
				Debug.Log(this.name + " is moving towards target position.");

				// Flip the localscale accordingly.
				if((targetPos.x - transform.position.x) > 0)
				{
					if(inverseSpriteFlipX) transform.localScale = new Vector3(-transform.localScale.y, transform.localScale.y, transform.localScale.z);
					else transform.localScale = new Vector3(transform.localScale.y, transform.localScale.y, transform.localScale.z);
				}
				else
				{
					if(inverseSpriteFlipX) transform.localScale = new Vector3(transform.localScale.y, transform.localScale.y, transform.localScale.z);
					else transform.localScale = new Vector3(-transform.localScale.y, transform.localScale.y, transform.localScale.z);
				}

				if(Vector3.Distance(transform.position, desiredPos) <= 0.1f)
				{
					if(currentState == NPCStates.Panicking)
					{
						SetRandomTargetPosition();
						yield return null;
					}
					else
					{
						SetState(NPCStates.Idle);
						yield return new WaitForSeconds(SetTimerToTimeBetweenActions(timeBetweenActions));
						SetRandomTargetPosition();
						SetState(NPCStates.Walking);
					}
				}
			}
			yield return null;
		}
	}

	public float SetTimerToTimeBetweenActions(Vector2Int timeBetween)
	{
		float time = Random.Range(timeBetween.x, timeBetween.y);
		Debug.Log(this.name + "Set time between actions: " + time);
		return time;
	}

	/// <summary>
	/// This sets a random target where the NPC will be walking towards.
	/// </summary>
	public void SetRandomTargetPosition()
	{
		Debug.Log("Acquiring new random target position");
		targetPos = new Vector3(Random.Range(-maxBounds, maxBounds), 0, 0);
	}

	/// <summary>
	/// Sets the targeted position.
	/// </summary>
	public void SetTargetPosition(Vector3 pos)
	{
		targetPos = pos;
	}

	public void SetState(NPCStates state)
	{
		this.currentState = state;

		switch(currentState)
		{
			case NPCStates.Idle:
				anim.SetBool(idleAnimation, true);
				anim.SetBool(walkAnimation, false);
				anim.SetBool(panicAnimation, false);
				anim.SetBool(angryAnimation, false);
				anim.SetBool(happyAnimation, false);
				break;
			case NPCStates.Walking:
				anim.SetBool(idleAnimation, false);
				anim.SetBool(walkAnimation, true);
				anim.SetBool(panicAnimation, false);
				anim.SetBool(angryAnimation, false);
				anim.SetBool(happyAnimation, false);
				break;
			case NPCStates.Panicking:
				anim.SetBool(idleAnimation, false);
				anim.SetBool(walkAnimation, false);
				anim.SetBool(panicAnimation, true);
				anim.SetBool(angryAnimation, false);
				anim.SetBool(happyAnimation, false);
				break;
			case NPCStates.Angry:
				anim.SetBool(idleAnimation, false);
				anim.SetBool(walkAnimation, false);
				anim.SetBool(panicAnimation, false);
				anim.SetBool(angryAnimation, true);
				anim.SetBool(happyAnimation, false);
				break;
			case NPCStates.Happy:
				anim.SetBool(idleAnimation, false);
				anim.SetBool(walkAnimation, false);
				anim.SetBool(panicAnimation, false);
				anim.SetBool(angryAnimation, false);
				anim.SetBool(happyAnimation, true);
				break;
			default:
				break;
		}
	}
}

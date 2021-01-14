using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameBehaviour_Fire : MonoBehaviour
{
	[SerializeField] private bool isActive = false;
	[SerializeField] private MicInput micInput = default;
	[SerializeField] private float micDB = 0;

	[SerializeField] private List<GameObject> fireSprites = new List<GameObject>();
	[SerializeField] private List<NPCBehaviour> npcsInScene = new List<NPCBehaviour>();

	[SerializeField] private GameObject UIWarningPopup = default;

	public bool IsActive { get => isActive; set => isActive = value; }

	private void Start()
	{
		micInput.enabled = false;

		UIWarningPopup.SetActive(false);
		ToggleFireSprites(false);
		GetNPCs();
		StartCoroutine(InitMinigame());
	}

	/// <summary>
	/// Gets all NPCs in the scene.
	/// </summary>
	private void GetNPCs()
	{
		NPCBehaviour[] npcs = FindObjectsOfType<NPCBehaviour>();

		foreach(NPCBehaviour nPC in npcs)
		{
			npcsInScene.Add(nPC);
		}
	}

	/// <summary>
	/// Initializes the minigame, which is making sure the mic input is on before checking the volume(dB).
	/// </summary>
	/// <returns></returns>
	private IEnumerator InitMinigame()
	{
		while(true)
		{
			if(isActive)
			{
				UIWarningPopup.GetComponent<Animator>().SetBool("Exit", false);
				UIWarningPopup.SetActive(true);
				ToggleFireSprites(true);
				TriggerPannickState(true);
				if(micInput.enabled == false)
				{
					micInput.enabled = true;
					yield return new WaitForSeconds(1f);
				}

				micDB = MicInput.MicLoudnessinDecibels;

				if(micDB > -10f)
				{
					StartCoroutine(FireSpritesExtinguishEvent());
					isActive = false;
					micInput.enabled = false;
				}
			}
			yield return null;
		}
	}

	/// <summary>
	/// This triggers the fire extinguish animation on all fire gameobjects.
	/// With a little delay this looks way better than all of them going out at the same time.
	/// </summary>
	/// <returns></returns>
	private IEnumerator FireSpritesExtinguishEvent()
	{
		yield return new WaitForSeconds(3f);
		foreach(GameObject sprite in fireSprites)
		{
			sprite.GetComponent<Animator>().SetBool("Extinguished", true);
			yield return new WaitForSeconds(Random.Range(0.1f, 0.3f));
		}
		TriggerPannickState(false);
		UIWarningPopup.GetComponent<Animator>().SetBool("Exit", true);
		yield return new WaitForSeconds(1f);
		UIWarningPopup.SetActive(false);
		StartCoroutine(TriggerNPCHappyState());
	}

	private IEnumerator TriggerNPCHappyState()
	{
		foreach(NPCBehaviour NPC in npcsInScene)
		{
			NPC.SetState(NPCStates.Happy);
		}

		yield return new WaitForSeconds(3f);

		foreach(NPCBehaviour NPC in npcsInScene)
		{
			NPC.SetState(NPCStates.Walking);
		}
		yield return null;
	}

	/// <summary>
	/// A simple function with which you can toggle all the fire gameobjects.
	/// usefull for resetting the minigame.
	/// </summary>
	/// <param name="toggle"></param>
	private void ToggleFireSprites(bool isActive)
	{
		if(isActive)
		{
			foreach(GameObject sprite in fireSprites)
			{
				sprite.SetActive(true);
				sprite.GetComponent<Animator>().SetBool("Extinguished", false);
			}
		}
		else
		{
			foreach(GameObject sprite in fireSprites)
			{
				sprite.SetActive(false);
			}
		}
	}

	/// <summary>
	/// Triggers the pannick state on all the NPCs in the list.
	/// </summary>
	/// <param name="isActive"> is Pannick state active. </param>
	private void TriggerPannickState(bool isActive)
	{
		if(isActive)
		{
			foreach(NPCBehaviour NPC in npcsInScene)
			{
				NPC.SetState(NPCStates.Panicking);
			}
		}
		else
		{
			foreach(NPCBehaviour NPC in npcsInScene)
			{
				NPC.SetState(NPCStates.Walking);
			}
		}
	}
}

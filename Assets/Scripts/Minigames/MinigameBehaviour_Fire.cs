using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameBehaviour_Fire : MonoBehaviour
{
	[SerializeField] private bool isActive = false;
	[SerializeField] private Transform fireSpritesParent = default;
	[SerializeField] private MicInput micInput = default;
	[SerializeField] private float micDB = 0;

	[SerializeField] private List<GameObject> fireSprites = new List<GameObject>();

	private void Start()
	{
		micInput.enabled = false;

		for(int i = 0; i < fireSpritesParent.childCount; i++)
		{
			fireSprites.Add(fireSpritesParent.GetChild(i).gameObject);
		}

		StartCoroutine(InitMinigame());
	}

	private IEnumerator InitMinigame()
	{
		while(true)
		{
			if(isActive)
			{
				if(micInput.enabled == false)
				{
					micInput.enabled = true;
					yield return new WaitForSeconds(1f);
				}

				micDB = MicInput.MicLoudnessinDecibels;

				if(micDB > -30f)
				{
					StartCoroutine(ToggleFireSprites(false));
					isActive = false;
					micInput.enabled = false;
				}
			}
			yield return null;
		}
	}

	private IEnumerator ToggleFireSprites(bool toggle)
	{
		yield return new WaitForSeconds(3f);
		if(toggle)
		{
			foreach(GameObject sprite in fireSprites)
			{
				sprite.GetComponent<Animator>().SetBool("Extinguished", false);
				yield return new WaitForSeconds(Random.Range(0.1f, 0.3f));
			}
		}
		else
		{
			foreach(GameObject sprite in fireSprites)
			{
				sprite.GetComponent<Animator>().SetBool("Extinguished", true);
				yield return new WaitForSeconds(Random.Range(0.1f, 0.3f));
			}
		}
	}
}

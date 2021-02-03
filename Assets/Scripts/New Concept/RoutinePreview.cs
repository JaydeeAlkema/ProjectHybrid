using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoutinePreview : MonoBehaviour
{
	[SerializeField] private Image progressBar;
	[SerializeField] private PetHappiness petHappiness;
	float value = 1;

	private void Update()
	{
		UpdateProgressBar();
	}

	private void UpdateProgressBar()
	{
		value -= Time.deltaTime / 50f;
		progressBar.fillAmount = value;
	}

	public void ApplyHappiness()
	{
		petHappiness.Value += 25f;
		gameObject.SetActive(false);
	}
}

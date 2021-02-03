using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoutinePreview : MonoBehaviour
{
	[SerializeField] private Image progressBar;
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
}

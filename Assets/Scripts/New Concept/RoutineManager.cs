using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoutineManager : MonoBehaviour
{
	[SerializeField] private GameObject routinePrefab = default;
	[SerializeField] private GameObject routinePreview = default;

	private void Awake()
	{
		//routinePreview.SetActive(false);
	}

	public void EnableRoutinePreview()
	{
		routinePreview.SetActive(true);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoutineManager : MonoBehaviour
{
	[SerializeField] private GameObject routinePrefab = default;
	[SerializeField] private GameObject activeRoutinesList = default;
	[SerializeField] private List<Routine> activeRoutines = default;

	public void AddRoutineToList(Routine routine)
	{
		activeRoutines.Add(routine);
	}

	public void RemoveRoutineFromList(Routine routine)
	{
		activeRoutines.Remove(routine);
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Routine : MonoBehaviour
{
	[SerializeField] private new string name = default;
	[SerializeField] private string description = default;
	[SerializeField] private DateTime dateTime = default;
	[SerializeField] private DateTime timeTillRoutine = default;

	public string Name { get => name; set => name = value; }
	public string Description { get => description; set => description = value; }
	public DateTime DateTime { get => dateTime; set => dateTime = value; }
	public DateTime TimeTillRoutine { get => timeTillRoutine; set => timeTillRoutine = value; }
}

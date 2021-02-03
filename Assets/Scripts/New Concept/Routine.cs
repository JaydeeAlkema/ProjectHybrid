
using System;
using TMPro;
using UnityEngine;

public enum DateRepeatType
{
	Never = 0,
	Dayly = 1,
	EveryTwoDays = 2,
	EveryThreeDays = 3,
	EveryFourDays = 4,
	EveryFiveDays = 5,
	EverySixDays = 6,
	Weekly = 7,
}

public class Routine : MonoBehaviour
{
	[Header("Components")]
	[SerializeField] private TMP_InputField nameText = default;
	[SerializeField] private TMP_InputField descriptionText = default;
	[Space]
	[SerializeField] private TMP_InputField dateDayText = default;
	[SerializeField] private TMP_InputField dateDayMonth = default;
	[SerializeField] private TMP_InputField dateDayMinute = default;
	[SerializeField] private TMP_InputField dateDayHour = default;

	[Header("Date Data")]
	[SerializeField] private DateRepeatType dateRepeat = DateRepeatType.Never;
	[SerializeField] private new string name = default;
	[SerializeField] private string description = default;
	[SerializeField] private RoutineDate routineDate = default;

	public DateRepeatType DateRepeat { get => dateRepeat; set => dateRepeat = value; }
	public string Name { get => name; set => name = value; }
	public string Description { get => description; set => description = value; }
	public RoutineDate RoutineDate { get => routineDate; set => routineDate = value; }

	private RoutineManager routineManager;

	private void Start()
	{
		routineManager = FindObjectOfType<RoutineManager>();
	}

	public void AddroutineToManager()
	{
		routineManager.AddRoutineToList(this);
		CloseRoutineWindow();
	}

	public void CloseRoutineWindow()
	{
		Destroy(this.gameObject);
	}

	/// <summary>
	/// Get the remaining time until the routine date.
	/// https://stackoverflow.com/questions/845379/difference-between-two-datetimes-c
	/// </summary>
	public void GetTimeUntillRoutineDate()
	{
		// Set local routine date variable as a DateTime object.
		DateTime _routineDate = new DateTime(DateTime.Now.Year, routineDate.Month, routineDate.Day, routineDate.Hour, routineDate.Minute, 0);
		// We could use DateTime.Now for this, but I want to exclude seconds and Milliseconds from the equation.
		DateTime _dateTimeNow = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, 0);
		// Get the timespan unitl the routine date.
		TimeSpan _timeUntilRoutine = _routineDate - _dateTimeNow;

		Debug.Log(_routineDate);
		Debug.Log(_timeUntilRoutine);
	}
}

[Serializable]
public class RoutineDate
{
	[SerializeField] private int day = default;
	[SerializeField] private int month = default;
	[Space]
	[SerializeField] private int minute = default;
	[SerializeField] private int hour = default;

	public int Day { get => day; set => day = value; }
	public int Month { get => month; set => month = value; }
	public int Minute { get => minute; set => minute = value; }
	public int Hour { get => hour; set => hour = value; }
}

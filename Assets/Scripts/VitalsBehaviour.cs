using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VitalsBehaviour : MonoBehaviour
{
	[SerializeField]
	private float hunger = 100;
	[SerializeField]
	private float thirst = 100;
	[SerializeField]
	private float energy = 100;
	[SerializeField]
	private float hygiene = 100;
	[SerializeField]
	private float hungerDecayAmount = 5;
	[SerializeField]
	private float thirstDecayAmount = 5;
	[SerializeField]
	private float energyDecayAmount = 5;
	[SerializeField]
	private float hygieneDecayAmount = 5;

	public float Hunger { get => hunger; set => hunger = value; }
	public float Thirst { get => thirst; set => thirst = value; }
	public float Energy { get => energy; set => energy = value; }
	public float Hygiene { get => hygiene; set => hygiene = value; }

	void Update()
	{
		VitalsDecay();
	}

	private void VitalsDecay()
	{
		if(Random.Range(1, 100) < hungerDecayAmount && hunger > 0)
		{
			hunger--;
			if(hunger < 25) NotificationsManager.SendNotification("1", "Pet Hunger Low!", "Your pet has run very low on food! Give your pet some food before it terrorizes your home!", System.DateTime.Now.AddMinutes(1), default, default);
		}
		if(Random.Range(1, 100) < thirstDecayAmount && thirst > 0)
		{
			thirst--;
			if(thirst < 25) NotificationsManager.SendNotification("1", "Pet Thirst Low!", "Your pet has run very low on Water! Give your pet some Water before it terrorizes your home!", System.DateTime.Now.AddMinutes(1), default, default);
		}
		if(Random.Range(1, 100) < energyDecayAmount && energy > 0)
		{
			if(energy < 15) NotificationsManager.SendNotification("1", "Pet Energy Low!", "Your pet has run very low on energy!", System.DateTime.Now.AddMinutes(1), default, default);
			energy--;
		}
		if(Random.Range(1, 100) < hygieneDecayAmount && hygiene > 0)
		{
			hygiene--;
			if(thirst < 25) NotificationsManager.SendNotification("1", "Pet Hygiene Low!", "Your pet is very filthy! Give him a wash or suffer the consequences!", System.DateTime.Now.AddMinutes(1), default, default);
		}
	}
}

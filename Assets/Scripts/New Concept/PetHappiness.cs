using UnityEngine;
using UnityEngine.UI;

public class PetHappiness : MonoBehaviour
{
	[SerializeField] private Image progressBar = default;

	float value = 1;

	public float Value { get => value; set => this.value = value; }

	private void Update()
	{
		value -= Time.deltaTime / 100f;
		progressBar.fillAmount = value;
	}
}

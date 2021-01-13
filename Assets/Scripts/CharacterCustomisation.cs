using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The Character Customisation class handles all the customisables for the Character.
/// The Creature will have it's own class that will be similair to this one, but with unique customisables.
/// </summary>
public class CharacterCustomisation : MonoBehaviour
{
	#region List of Art Assets
	[SerializeField] private List<Sprite> headVariants = new List<Sprite>();
	[SerializeField] private List<Sprite> bodyVariants = new List<Sprite>();
	[SerializeField] private List<Sprite> legsVariants = new List<Sprite>();
	[Space]
	[SerializeField] private Image headImage = default;
	[SerializeField] private Image bodyImage = default;
	[SerializeField] private Image legsImage = default;
	[Space]
	[SerializeField] private int headVariantIndex = 0;
	[SerializeField] private int bodyVariantIndex = 0;
	[SerializeField] private int legsVariantIndex = 0;
	#endregion

	private void Start()
	{
		SetupAssets();
	}

	private void SetupAssets()
	{
		headImage.sprite = headVariants[headVariantIndex];
		bodyImage.sprite = bodyVariants[bodyVariantIndex];
		legsImage.sprite = legsVariants[legsVariantIndex];
	}

	/// <summary>
	/// Cycles to the next head variant in the list.
	/// </summary>
	public void NextHeadVariant()
	{
		headVariantIndex++;
		if(headVariantIndex > headVariants.Count - 1) headVariantIndex = 0;

		headImage.sprite = headVariants[headVariantIndex];
	}
	/// <summary>
	/// Cycles to the previous head variant in the list.
	/// </summary>
	public void PreviousHeadVariant()
	{
		headVariantIndex--;
		if(headVariantIndex < 0) headVariantIndex = headVariants.Count;

		headImage.sprite = headVariants[headVariantIndex];
	}

	/// <summary>
	/// Cycles to the next Body variant in the list.
	/// </summary>
	public void NextBodyVariant()
	{
		bodyVariantIndex++;
		if(bodyVariantIndex > bodyVariants.Count - 1) bodyVariantIndex = 0;

		bodyImage.sprite = bodyVariants[bodyVariantIndex];
	}
	/// <summary>
	/// Cycles to the previous Body variant in the list.
	/// </summary>
	public void PreviousBodyVariant()
	{
		bodyVariantIndex--;
		if(bodyVariantIndex < 0) bodyVariantIndex = bodyVariants.Count;

		bodyImage.sprite = bodyVariants[bodyVariantIndex];
	}

	/// <summary>
	/// Cycles to the next Legs variant in the list.
	/// </summary>
	public void NextLegsVariant()
	{
		legsVariantIndex++;
		if(legsVariantIndex > legsVariants.Count - 1) legsVariantIndex = 0;

		legsImage.sprite = legsVariants[legsVariantIndex];
	}
	/// <summary>
	/// Cycles to the previous Legs variant in the list.
	/// </summary>
	public void PreviousLegsVariant()
	{
		legsVariantIndex--;
		if(legsVariantIndex < 0) legsVariantIndex = legsVariants.Count;

		legsImage.sprite = legsVariants[legsVariantIndex];
	}
}

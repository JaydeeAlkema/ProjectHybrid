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
	[SerializeField] private List<Sprite> clothesVariants = new List<Sprite>();
	[Space]
	[SerializeField] private Image headImage = default;
	[SerializeField] private Image bodyImage = default;
	[SerializeField] private Image ClothesImage = default;
	[Space]
	[SerializeField] private int headVariantIndex = 0;
	[SerializeField] private int bodyVariantIndex = 0;
	[SerializeField] private int clothesVariantIndex = 0;
	#endregion

	private void Start()
	{
		SetupAssets();
	}

	private void SetupAssets()
	{
		headImage.sprite = headVariants[headVariantIndex];
		bodyImage.sprite = bodyVariants[bodyVariantIndex];
		ClothesImage.sprite = clothesVariants[clothesVariantIndex];
	}

	/// <summary>
	/// Cycles to the next head variant in the list.
	/// </summary>
	public void NextHeadVariant()
	{
		headVariantIndex++;
		if(headVariantIndex > headVariants.Count) headVariantIndex = 0;

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
		if(bodyVariantIndex > bodyVariants.Count) bodyVariantIndex = 0;

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
	/// Cycles to the next Clothes variant in the list.
	/// </summary>
	public void NextClothesVariant()
	{
		clothesVariantIndex++;
		if(clothesVariantIndex > clothesVariants.Count) clothesVariantIndex = 0;

		ClothesImage.sprite = clothesVariants[clothesVariantIndex];
	}
	/// <summary>
	/// Cycles to the previous Clothes variant in the list.
	/// </summary>
	public void PreviousClothesVariant()
	{
		clothesVariantIndex--;
		if(clothesVariantIndex < 0) clothesVariantIndex = clothesVariants.Count;

		ClothesImage.sprite = clothesVariants[clothesVariantIndex];
	}
}

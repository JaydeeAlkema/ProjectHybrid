using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuBehaviour : MonoBehaviour
{

	[SerializeField] private GameObject codeInputfield = default;
	[SerializeField] private GameObject doneButton = default;

	public void LoadCharacterCustomizationScene()
	{
		SceneManager.LoadScene(1);
	}

	public void ToggleCodeInputField()
	{
		codeInputfield.SetActive(!codeInputfield.activeInHierarchy);
	}

	public void ToggleDoneButton()
	{
		doneButton.SetActive(!doneButton.activeInHierarchy);
	}
}

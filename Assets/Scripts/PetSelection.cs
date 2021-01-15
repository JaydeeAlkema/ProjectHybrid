using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PetSelection : MonoBehaviour
{

	[SerializeField] private List<GameObject> pets = new List<GameObject>();
	[SerializeField]
	private int index = 0;
	private GameObject activePet;
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	/// <summary>
	/// Cycles to the next head variant in the list.
	/// </summary>
	public void NextHeadVariant()
	{
		index++;
		if (index > pets.Count - 1) index = 0;

		activePet = pets[index];
		updateActivePet();
	}
	/// <summary>
	/// Cycles to the previous head variant in the list.
	/// </summary>
	public void PreviousHeadVariant()
	{
		index--;
		if (index < 0) index = pets.Count - 1;

		activePet = pets[index];
		updateActivePet();
	}

	void updateActivePet()
    {
        for (int i = 0; i < pets.Count; i++)
        {
            if (pets[i] != activePet)
            {
				pets[i].SetActive(false);
            } else
            {
				pets[i].SetActive(true);
			}
        }
    }

	public void LoadMainScene()
	{
		SceneManager.LoadScene(2);
	}
}

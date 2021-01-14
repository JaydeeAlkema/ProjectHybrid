using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Image hungerbar;
    [SerializeField] private Image thirstBar;
    [SerializeField] private Image energyBar;
    [SerializeField] private Image hygieneBar;
    [SerializeField] private VitalsBehaviour vitals;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hungerbar.fillAmount = vitals.Hunger / 100;
        thirstBar.fillAmount = vitals.Thirst / 100;
        energyBar.fillAmount = vitals.Energy / 100;
        hygieneBar.fillAmount = vitals.Hygiene / 100;
    }
}

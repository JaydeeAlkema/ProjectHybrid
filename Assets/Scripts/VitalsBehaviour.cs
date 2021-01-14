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

    [SerializeField]
    private MinigameBehaviour_Fire fireEvent;

    public float Hunger { get => hunger; set => hunger = value; }
    public float Thirst { get => thirst; set => thirst = value; }
    public float Energy { get => energy; set => energy = value; }
    public float Hygiene { get => hygiene; set => hygiene = value; }

    void Start()
    {
        if (!fireEvent)
        {
            Debug.LogError("Assign the fire event to the Vitals Behaviour script!!!!");
        }
    }

    void Update()
    {
        VitalsDecay();
    }

    private void VitalsDecay()
    {
        if (Random.Range(1,100) < hungerDecayAmount && hunger > 0)
        {
            hunger--;
        }
        if (Random.Range(1,100) < thirstDecayAmount && thirst > 0)
        {
            thirst--;
        }
        if (Random.Range(1,100) < energyDecayAmount && energy > 0)
        {
            if (energy < 15)
            {
                fireEvent.IsActive = true;
                energy = 100;
            }
            energy--;
        }
        if (Random.Range(1,100) < hygieneDecayAmount && hygiene > 0)
        {
            hygiene--;
        }
    }
}

using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class CustomButton : MonoBehaviour
{
    public UnityEvent OnHeld;
    bool isHeld = false;

    private void Update()
    {
        if (isHeld)
        {
            OnHeld.Invoke();
        }
    }
}

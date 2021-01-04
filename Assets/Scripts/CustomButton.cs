using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class CustomButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public UnityEvent OnHeld;
    bool isHeld = false;
    public void OnPointerDown(PointerEventData eventData)
    {
        isHeld = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isHeld = false;
    }
    private void Update()
    {
        if (isHeld)
        {
            OnHeld.Invoke();
        }
    }
}

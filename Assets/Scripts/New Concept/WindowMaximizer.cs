using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowMaximizer : MonoBehaviour
{
    private Animator anim;
    [SerializeField]
    private Animator buttonAnimator;

    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("isUp", false);
        buttonAnimator.SetBool("isButtonUp", true);
    }




    public void ToggleWindow()
    {
        if (anim.GetBool("isUp") == true)
        {
            anim.SetBool("isUp", false);
        } 
        else
        {
            anim.SetBool("isUp", true);
        }
    }

    public void FlipButton() 
    {
        if (buttonAnimator.GetBool("isButtonUp") == false)
        {
            buttonAnimator.SetBool("isButtonUp", true);
        }
        else
        {
            buttonAnimator.SetBool("isButtonUp", false);
        }
    }

}

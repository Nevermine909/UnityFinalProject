using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnFX : MonoBehaviour
{
    public AudioSource myFx;
    public AudioClip hoverFx;
    public AudioClip clickFx;
    public AudioClip popUpFx;
    public AudioClip forwardButtonClickFx;

    public void HoverSound()
    {
        myFx.PlayOneShot(hoverFx);
    }

    public void ClickSound()
    {
        myFx.PlayOneShot(clickFx);
    }

    public void PopUpSound()
    {
        myFx.PlayOneShot(popUpFx);
    }

    public void forwardButtonClickSound()
    {
        myFx.PlayOneShot(forwardButtonClickFx);
    }

}

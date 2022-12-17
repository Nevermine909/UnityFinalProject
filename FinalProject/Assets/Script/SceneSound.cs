using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSound : MonoBehaviour
{
    public AudioSource myFx;
    void Start()
    {
        myFx.Play();
    }

}
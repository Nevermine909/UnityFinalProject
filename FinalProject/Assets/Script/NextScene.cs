using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public void MoveToNextScene()
    {
        SceneManager.LoadScene(3);
    }

    public void Back2Menu()
    {
        SceneManager.LoadScene(0);
    }
}

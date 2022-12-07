using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    private int sceneToContinue;
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void GameContinue()
    {
        //sceneToContinue = PlayerPrefs.GetInt("SavedScene");
        //SceneManager.LoadScene(sceneToContinue);
        Debug.Log(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

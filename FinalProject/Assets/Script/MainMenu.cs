using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    private int sceneToContinue;
    public void PlayGame() => SceneManager.LoadScene(1);

    public void GameContinue()
    {
        if (PlayerPrefs.HasKey("LevelSaved"))
        {
            sceneToContinue = PlayerPrefs.GetInt("LevelSaved");
            SceneManager.LoadScene(sceneToContinue);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

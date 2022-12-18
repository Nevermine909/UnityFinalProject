using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseMenu : MonoBehaviour
{
    public GameObject loseMenu;
    public bool isLosed;
    private int currentSceneIndex;
    public PlayerHealth playerHealth;

    void Update()
    {
        if (playerHealth.getPlayerHealth() == 0)
        {
            Time.timeScale = 0f;
            LoseMenuPop();
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
    /*
        public void Back2Menu() {
            int activeScene = SceneManager.GetActiveScene().buildIndex;
            PlayerPrefs.SetInt("LevelSaved", activeScene);
            gameObject.SetActive(false);
            Time.timeScale = 1f;
            SceneManager.LoadScene(0);
        }
    */
    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        while (operation.isDone == false)
        {
            yield return null;
        }
    }

    public void LoseMenuPop()
    {
        loseMenu.SetActive(true);
        isLosed = true;

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

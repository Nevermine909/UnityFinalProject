using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneLoad : MonoBehaviour
{
    public GameObject loadingScreen;
    public Image sliderFill;
    public TMP_Text progressText;
    public TMP_Text loadingText;

    public void LoadScene (int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously (int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadingScreen.SetActive(true);

        while (operation.isDone == false)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            sliderFill.fillAmount = progress;
            progressText.text = progress * 100f + "%";
            yield return null;
        }
    }
}

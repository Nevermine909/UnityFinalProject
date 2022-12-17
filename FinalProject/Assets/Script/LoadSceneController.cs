using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class LoadSceneController : MonoBehaviour
{
    public GameObject loadingScreen;
    public Image sliderFill;
    public TMP_Text progressText;
    public TMP_Text loadingText;
    private int sceneToContinue;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            int activeScene = SceneManager.GetActiveScene().buildIndex + 1;
            PlayerPrefs.SetInt("NextLevel", activeScene);
            StartCoroutine(LoadAsynchronously());
            gameObject.SetActive(false);
        }
    }


    IEnumerator LoadAsynchronously()
    {
        if (PlayerPrefs.HasKey("NextLevel"))
        {
            sceneToContinue = PlayerPrefs.GetInt("NextLevel");
        }

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneToContinue);

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

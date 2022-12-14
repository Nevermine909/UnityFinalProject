using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingMap : MonoBehaviour
{
    // Update is called once per frame
    public Animator transition;
    public float transitionTime = 1f;
    public GameObject loadingScreen;
    public Slider sliderFill;

    public void LoadingNextMap(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        transition.SetTrigger("StartAnimation");
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadingScreen.SetActive(true);

        while (operation.isDone == false)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            sliderFill.value = progress;

            yield return null;
        }

        yield return new WaitForSeconds(transitionTime);
    }
}

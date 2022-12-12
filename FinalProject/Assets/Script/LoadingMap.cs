using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingMap : MonoBehaviour
{
    // Update is called once per frame
    public Animator transition;
    public float transitionTime = 1f;
    private int nextScene;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            LoadingNextMap();
        }
    }

    public void LoadingNextMap()
    {
        nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        StartCoroutine(LoadMap(nextScene));
    }

    IEnumerator LoadMap( int mapIndex)
    {
        transition.SetTrigger("StartAnimation");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(mapIndex);
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            int activeScene = SceneManager.GetActiveScene().buildIndex + 1;

            SceneManager.LoadScene(activeScene);

            gameObject.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SaveController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            int activeScene = SceneManager.GetActiveScene().buildIndex;
            PlayerPrefs.SetInt("LevelSaved", activeScene);
            gameObject.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class Dialog : MonoBehaviour
{
    public Text textComponent;
    public string[] lines;
    public float textSpeed;
    private int index;
    

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialog();
    }

    // Update is called once per frame
    public void nextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(WordByWord());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    void StartDialog()
    {
        index = 0;
        StartCoroutine(WordByWord());
    }

    IEnumerator WordByWord()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
}

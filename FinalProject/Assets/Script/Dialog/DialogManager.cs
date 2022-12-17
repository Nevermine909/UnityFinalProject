using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogManager : MonoBehaviour
{
    public Image characterAvatar;
    public TMP_Text characterName;
    //public TMP_Text lineText;
    public Text lineText2;
    public RectTransform dialogTransition;

    public GameObject loadingScreen;
    public Image sliderFill;
    public TMP_Text progressText;
    public TMP_Text loadingText;


    Line[] currentLines;
    Character[] currentCharacters;
    int activeLine = 0;
    public static bool isActive = false;

    public void OpenDialog(Line[] lines, Character[] characters)
    {
        currentLines = lines;
        currentCharacters = characters;
        activeLine = 0;
        isActive = true;
        DisplayLine();
        dialogTransition.LeanScale(Vector3.one, 0.5f).setEaseInOutExpo();
    }

    void DisplayLine()
    {
        Line displayLine = currentLines[activeLine];
        lineText2.text = displayLine.line;

        Character displayCharacter = currentCharacters[displayLine.characterId];
        characterName.text = displayCharacter.characterName;
        characterAvatar.sprite = displayCharacter.characterAvatar;
    }

    public void NextLine(int sceneIndex)
    {
        activeLine++;
        if (activeLine < currentLines.Length)
        {
            DisplayLine();
        }
        else
        {
            dialogTransition.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
            isActive = false;
            StartCoroutine(LoadAsynchronously(sceneIndex));
        }
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
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

    void Start()
    {
        dialogTransition.transform.localScale = Vector3.zero;
    }
}

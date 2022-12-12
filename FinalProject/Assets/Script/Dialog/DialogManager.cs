using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public Image characterAvatar;
    public TMP_Text characterName;
    public TMP_Text lineText;
    public RectTransform dialogTransition;


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
        lineText.text = displayLine.line;

        Character displayCharacter = currentCharacters[displayLine.characterId];
        characterName.text = displayCharacter.characterName;
        characterAvatar.sprite = displayCharacter.characterAvatar;

    }

    public void NextLine()
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
        }
    }


    void Start()
    {
        dialogTransition.transform.localScale = Vector3.zero;
    }
}

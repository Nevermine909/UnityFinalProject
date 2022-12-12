using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogTrigger : MonoBehaviour
{
    public Line[] lines;
    public Character[] characters;

    public void startDialog()
    {
        FindObjectOfType<DialogManager>().OpenDialog(lines, characters);
    }
}

[System.Serializable]
public class Line
{   
    public int characterId;

    [TextArea(3, 10)]
    public string line;
}

[System.Serializable]
public class Character
{
    public string characterName;
    public Sprite characterAvatar;
}


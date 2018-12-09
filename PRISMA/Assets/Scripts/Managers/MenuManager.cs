using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    GameObject backPackBox, dialogueBox;
    Text dialogueText;

    void Start()
    {
        dialogueText = dialogueBox.GetComponentInChildren<Text>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (backPackBox.active)
            {
                CloseBackpack();
            }
            else
            {
                OpenBackpack();
            }
        }
    }
    public void OpenBackpack()
    {
        backPackBox.SetActive(true);
    }
    public void CloseBackpack()
    {
        backPackBox.SetActive(false);
    }

    public void ViewDialogue(string dialogue)
    {
        dialogueBox.SetActive(true);
        if(dialogue != "")
        {
            dialogueText.text = dialogue;
        }
        else
        {
            dialogueBox.SetActive(false);
        }
    }
}

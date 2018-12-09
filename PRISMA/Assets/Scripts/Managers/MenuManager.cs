using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    GameObject popUpImage, dialogueBox;
    Text dialogueText;

    void Start()
    {
        dialogueText = dialogueBox.GetComponentInChildren<Text>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (popUpImage.active)
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
        popUpImage.SetActive(true);
    }
    public void CloseBackpack()
    {
        popUpImage.SetActive(false);
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

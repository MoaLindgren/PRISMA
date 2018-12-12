using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    GameObject backPackBox, dialogueBox, itemPrefab, backPackButton, score, timer, miniGame1UI;
    [SerializeField]
    Transform itemParent;
    Text dialogueText, scoreText;
    public Text timerText;
    ItemsManager itemManager;
    public bool newItem;

    void Start()
    {
        itemManager = GetComponent<ItemsManager>();
        dialogueText = dialogueBox.GetComponentInChildren<Text>();
        timerText = timer.GetComponent<Text>();
        scoreText = score.GetComponent<Text>();
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
        if (newItem)
        {
            backPackButton.GetComponent<Image>().color = Color.blue;
        }
        else
        {
            backPackButton.GetComponent<Image>().color = Color.white;
        }
    }

    public void OpenBackpack()
    {
        backPackBox.SetActive(true);

        for (int i = 0; i <= itemManager.items.Count; i++)
        {
            itemManager.GetItem(i, false);
        }
    }

    //Blir kallad på från ItemsManager OM det är ett nytt item i backpack.
    public void InstantianteItem(int index, string name)
    {
        GameObject item = Instantiate(itemPrefab, itemParent);
        item.GetComponentInChildren<Text>().text = name;
        item.name = index.ToString();
        newItem = true;
    }
    public void CloseBackpack()
    {
        backPackBox.SetActive(false);
    }

    //Blir kallad på från XmlManager:
    public void ViewDialogue(string dialogue)
    {
        dialogueBox.SetActive(true);
        if (dialogue != "")
        {
            dialogueText.text = dialogue;
        }
        else
        {
            dialogueBox.SetActive(false);
        }
    }
    public void SetScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void MiniGame1()
    {
        miniGame1UI.SetActive(true);
    }
}

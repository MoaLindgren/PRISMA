using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    GameObject backPackBox, dialogueBox, itemPrefab, backPackButton;
    [SerializeField]
    Transform itemParent;
    Text dialogueText;
    ItemsManager itemManager;
    bool newItem;

    void Start()
    {
        itemManager = GetComponent<ItemsManager>();
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
        if (newItem)
        {
            backPackButton.GetComponent<Image>().color = Color.blue;
        }
    }

    public void OpenBackpack()
    {
        backPackBox.SetActive(true);

        for (int i = 0; i <= itemManager.items.Count; i++)
        {
            itemManager.GetItem(i);
        }
    }

    public void SelectItem(GameObject button)
    {
            newItem = false;
            backPackButton.GetComponent<Image>().color = Color.white;
    }

    //Blir kallad på från ItemsManager OM det är ett nytt item i backpack.
    public void InstantianteItem(string name)
    {
        GameObject item = Instantiate(itemPrefab, itemParent);
        item.GetComponentInChildren<Text>().text = name;
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
}

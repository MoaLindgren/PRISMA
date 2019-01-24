using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    MenuManager menuManager;
    GameObject gameManager;
    ItemsManager itemManager;
    SoundManager soundManager;
    XmlManager xmlManager;

    [SerializeField]
    AudioClip buttonClick;
    Button button;
    bool newItem;
    int itemIndex;



    void Start()
    {
        itemIndex = int.Parse(gameObject.name);

        gameManager = GameObject.Find("GameManager");
        soundManager = gameManager.GetComponent<SoundManager>();
        menuManager = gameManager.GetComponent<MenuManager>();
        itemManager = gameManager.GetComponent<ItemsManager>();
        xmlManager = gameManager.GetComponent<XmlManager>();

        button = gameObject.GetComponent<Button>();
        newItem = true;
        button.onClick.AddListener(OnClick);
    }
    void OnClick()
    {
        if (this.newItem)
        {
            newItem = false;
            menuManager.newItem = false;
        }
        soundManager.UISound(buttonClick);
        itemManager.GetItem(itemIndex, true);

        GameObject[] itemButtons = GameObject.FindGameObjectsWithTag("ItemButton");
        foreach (GameObject button in itemButtons)
        {
            button.transform.parent.GetChild(0).gameObject.SetActive(false);
        }
        this.gameObject.transform.parent.GetChild(0).gameObject.SetActive(true);

        xmlManager.Dialogue(true, true);
    }
}
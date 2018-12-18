using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    MenuManager menuManager;
    GameObject gameManager;
    ItemsManager itemManager;
    Button button;
    bool newItem;
    int itemIndex;

    XmlManager xmlManager;

    void Start()
    {
        itemIndex = int.Parse(gameObject.name);

        gameManager = GameObject.Find("GameManager");
        menuManager = gameManager.GetComponent<MenuManager>();
        itemManager = gameManager.GetComponent<ItemsManager>();
        xmlManager = gameManager.GetComponent<XmlManager>();

        button = gameObject.GetComponent<Button>();
        newItem = true;
        button.onClick.AddListener(OnClick);
    }
    void Update()
    {
        if (this.newItem)
        {
            this.gameObject.GetComponent<Image>().color = Color.blue;
        }
    }
    void OnClick()
    {
        if (this.newItem)
        {
            newItem = false;
            menuManager.newItem = false;
        }

        itemManager.GetItem(itemIndex, true);

        GameObject[] itemButtons = GameObject.FindGameObjectsWithTag("ItemButton");
        foreach (GameObject buttons in itemButtons)
        {
            gameObject.GetComponent<Image>().color = Color.white;
        }
        gameObject.GetComponent<Image>().color = Color.green;

        xmlManager.Dialogue(true, true);
    }
}
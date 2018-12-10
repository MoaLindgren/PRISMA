using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    MenuManager menuManager;
    GameObject gameManager;
    Button button;
    bool rightItem, newItem;

    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        button = gameObject.GetComponent<Button>();
        GetComponent<Image>().color = Color.blue;
        rightItem = true;
        button.onClick.AddListener(OnClick);
    }
    void OnClick()
    {
        if (this.rightItem)
        {
            GetComponent<Image>().color = Color.white;
        }
        menuManager = gameManager.GetComponent<MenuManager>();
        menuManager.SelectItem(gameObject);



    }
}

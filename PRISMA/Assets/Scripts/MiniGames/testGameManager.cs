using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testGameManager : MonoBehaviour
{
    int gameIndex;
    public bool startGame;

    GameObject gameManager;
    XmlManager xmlManager;
    ItemsManager itemManager;
    MenuManager menuManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        xmlManager = gameManager.GetComponent<XmlManager>();
        itemManager = gameManager.GetComponent<ItemsManager>();
        menuManager = gameManager.GetComponent<MenuManager>();
    }

    void OnTriggerEnter()
    {
        gameIndex = int.Parse(gameObject.tag);
        xmlManager.SetUpXML(gameIndex);
        itemManager.AddItem(1, "Anteckningsblock");
        menuManager.currentStation = this.gameObject;
    }
    public void StartGame()
    {
        startGame = true;
        print("wohoo");
    }
}


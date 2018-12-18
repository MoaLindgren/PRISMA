using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testGameManager : MonoBehaviour
{
    int gameIndex;
    public bool startGame;

    GameObject gameManager, player;
    XmlManager xmlManager;
    ItemsManager itemManager;
    MenuManager menuManager;
    PlayerBehaviour playerBehaviour;
    MonoBehaviour currentMiniGame;

    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        player = GameObject.FindGameObjectWithTag("player");
        xmlManager = gameManager.GetComponent<XmlManager>();
        itemManager = gameManager.GetComponent<ItemsManager>();
        menuManager = gameManager.GetComponent<MenuManager>();
        playerBehaviour = player.GetComponent<PlayerBehaviour>();
    }

    void OnTriggerEnter()
    {
        playerBehaviour.moveable = false;
        gameIndex = int.Parse(gameObject.tag);
        xmlManager.SetUpXML(gameIndex);
        itemManager.AddItem(1, "Anteckningsblock");
        menuManager.currentStation = this.gameObject;
        currentMiniGame = GetComponent<MonoBehaviour>();
    }
    public void StartGame()
    {
        startGame = true;
        menuManager.MiniGame1(); //<- ska inte göras förrän spelet faktiskt börjar. Dvs. När startgame blir true.
        currentMiniGame.enabled = true;
    }
    public void EndGame()
    {
        currentMiniGame.enabled = false;
        playerBehaviour.moveable = true;
        xmlManager.Dialogue(false);
    }
}


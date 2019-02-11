using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int gameIndex, gameRound;
    public bool startGame;

    Vector3 playerLockRotation;
    GameObject player;
    XmlManager xmlManager;
    ItemsManager itemManager;
    MenuManager menuManager;
    PlayerBehaviour playerBehaviour;
    CameraManager cameraManager;
    //MonoBehaviour currentMiniGame;
    string[] items = { "Komradio", "Anteckningsblock", "Ogräsborttagare", "Räknare", "Fiskespö" };

    void Start()
    {
        Cursor.visible = false;
        gameRound = 0;

        player = GameObject.FindGameObjectWithTag("player");

        cameraManager = GameObject.Find("Main Camera").GetComponent<CameraManager>();
        xmlManager = GetComponent<XmlManager>();
        itemManager = GetComponent<ItemsManager>();
        menuManager = GetComponent<MenuManager>();
        playerBehaviour = player.GetComponent<PlayerBehaviour>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Cursor.visible = true;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            Cursor.visible = false;
        }
    }

    public void Station()
    {
        Cursor.visible = true;
        gameRound++;
        playerBehaviour.Moveable = false; 
        gameIndex = int.Parse(gameObject.tag);

        itemManager.AddItem(gameIndex + 1, items[gameIndex]);
    }
    public void StartGame()
    {
        if (gameIndex != 0)
        {
            startGame = true;
            //currentMiniGame.enabled = true;
        }
        else if (gameIndex == 0)
        {
            playerBehaviour.Moveable = true;
        }

    }
    public void EndGame(bool win)
    {
        //currentMiniGame.enabled = false;
        playerBehaviour.Moveable = true;
    }
}

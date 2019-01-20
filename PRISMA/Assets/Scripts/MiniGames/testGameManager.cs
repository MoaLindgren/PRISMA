using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testGameManager : MonoBehaviour
{
    int gameIndex;
    public int gameRound;
    public bool startGame;

    GameObject gameManager, player, camera;
    XmlManager xmlManager;
    ItemsManager itemManager;
    MenuManager menuManager;
    PlayerBehaviour playerBehaviour;
    CameraManager cameraManager;
    MonoBehaviour currentMiniGame;
    string[] items = { "Komradio", "Anteckningsblock", "Ogräsborttagare", "Räknare", "Fiskespö" };
    public bool testBool;

    void Start()
    {
        testBool = false;
        gameRound = 0;
        camera = GameObject.Find("Main Camera");
        cameraManager = camera.GetComponent<CameraManager>();
        gameManager = GameObject.Find("GameManager");
        player = GameObject.FindGameObjectWithTag("player");
        xmlManager = gameManager.GetComponent<XmlManager>();
        itemManager = gameManager.GetComponent<ItemsManager>();
        menuManager = gameManager.GetComponent<MenuManager>();
        playerBehaviour = player.GetComponent<PlayerBehaviour>();
    }
    void Update()
    {
        if(testBool)
        {
            cameraManager.description = "Coordinates_Rotation";
            cameraManager.defaultCamera = false;
            cameraManager.changePos = new Vector3(25, 20, -10);
            cameraManager.changeRot = new Vector3(10, 0, 0);
        }
        //else
        //{
        //    cameraManager.defaultCamera = true;
        //}
    }

    void OnTriggerEnter()
    {
        gameRound++;
        playerBehaviour.moveable = false;
        gameIndex = int.Parse(gameObject.tag);
        xmlManager.SetUpXML(gameIndex, gameRound);
        itemManager.AddItem(gameIndex + 1, items[gameIndex]);
        menuManager.currentStation = this.gameObject;
        currentMiniGame = GetComponent<MonoBehaviour>();
    }
    public void StartGame()
    {
        if(gameIndex != 0)
        {
            startGame = true;
            currentMiniGame.enabled = true;
        }
        else if(gameIndex == 0)
        {
            playerBehaviour.moveable = true;
            xmlManager.Dialogue(false, true);
        }

    }
    public void EndGame(bool win)
    {
        currentMiniGame.enabled = false;
        playerBehaviour.moveable = true;
        xmlManager.Dialogue(false, win);
    }
}


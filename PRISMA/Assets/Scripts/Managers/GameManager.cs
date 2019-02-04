using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
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

    Vector3 playerLockRotation;

    void Start()
    {
        Cursor.visible = false;
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
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Cursor.visible = true;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            Cursor.visible = false;
        }
    }

    void OnTriggerEnter()
    {
        Cursor.visible = true;
        gameRound++;
        playerBehaviour.moveable = false;
        gameIndex = int.Parse(gameObject.tag);
        //xmlManager.SetUpXML(gameIndex, gameRound);
        itemManager.AddItem(gameIndex + 1, items[gameIndex]);
        menuManager.currentStation = this.gameObject;
        currentMiniGame = GetComponent<MonoBehaviour>();
    }
    public void StartGame()
    {
        if (gameIndex != 0)
        {
            startGame = true;
            currentMiniGame.enabled = true;
        }
        else if (gameIndex == 0)
        {
            playerBehaviour.moveable = true;
            //xmlManager.Dialogue(false, true);
        }

    }
    public void EndGame(bool win)
    {
        currentMiniGame.enabled = false;
        playerBehaviour.moveable = true;
        //xmlManager.Dialogue(false, win);
    }
}

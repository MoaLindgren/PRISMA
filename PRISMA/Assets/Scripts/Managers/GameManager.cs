using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int achievementIndex, nbrAchievementsCompleted;
    public bool startGame;
    bool correctItem;

    Vector3 playerLockRotation;
    GameObject player;
    XmlManager xmlManager;
    ItemsManager itemManager;
    MenuManager menuManager;
    PlayerBehaviour playerBehaviour;
    CameraManager cameraManager;
    
    string[] items = { "Komradio", "Anteckningsblock", "Ogräsborttagare", "Räknare", "Fiskespö" };

    public bool CorrectItem
    {
        set { correctItem = value; }
    }
    public int AchievementIndex
    {
        set { achievementIndex = value; }
    }

    void Start()
    {
        Cursor.visible = false;
        nbrAchievementsCompleted = 0;
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
        //ta bort detta 
        if(Input.GetKeyDown(KeyCode.Y))
        {
            GameOver();
        }
    }
    //När man går in i en station:
    public void Station(int index)
    {
        Cursor.visible = true;
        playerBehaviour.Moveable = false; 
        itemManager.AddItem(index + 1, items[index]);
    }
    public void Achievement(int index, GameObject halo)
    {
        nbrAchievementsCompleted++;
        Cursor.visible = true;
        playerBehaviour.Moveable = false;
        menuManager.AchievementCompleted(index);
        halo.SetActive(false);
    }
    //När en dialog är klar:
    public void Play(bool achievement)
    {
        if(correctItem)
        {
            playerBehaviour.Moveable = true;
            Cursor.visible = false;
            xmlManager.Dialogue();
        }
        if(achievement)
        {
            playerBehaviour.Moveable = true;
            Cursor.visible = false;
        }
    }

    public void GameOver ()
    {
        //när spelet är slut kallas dena. 
        menuManager.GameOver(nbrAchievementsCompleted);
    }

}

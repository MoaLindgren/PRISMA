﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int achievementIndex, nbrAchievementsCompleted, currentItem;
    bool correctItem, gameOver, gameStarted, showCursor;
    [SerializeField]
    float totalGameTime, gameTimer;

    Vector3 playerLockRotation;
    GameObject player;
    XmlManager xmlManager;
    ItemsManager itemManager;
    MenuManager menuManager;
    PlayerBehaviour playerBehaviour;
    CameraManager cameraManager;

    string[] items = { "Komradio", "Anteckningsblock", "Ogräsborttagare", "Räknare", "Fiskespö" };
    List<int> completedAchievementIndex;

    public bool CorrectItem
    {
        set { correctItem = value; }
    }
    public int CurrentItem
    {
        get { return currentItem; }
    }
    public int AchievementIndex
    {
        set { achievementIndex = value; }
    }
    public List<int> CompletedAchievementIndex
    {
        get { return completedAchievementIndex; }
    }
    public bool GameStarted
    {
        set { gameStarted = value; }
    }


    void Start()
    {
        gameTimer = 0;
        gameStarted = false;
        gameOver = false;
        Cursor.visible = false;
        nbrAchievementsCompleted = 0;
        player = GameObject.FindGameObjectWithTag("player");
        cameraManager = GameObject.Find("Main Camera").GetComponent<CameraManager>();
        xmlManager = GetComponent<XmlManager>();
        itemManager = GetComponent<ItemsManager>();
        menuManager = GetComponent<MenuManager>();
        playerBehaviour = player.GetComponent<PlayerBehaviour>();
        completedAchievementIndex = new List<int>();
    }
    void Update()
    {
        if (gameStarted)
        {
            gameTimer += Time.deltaTime;
            if (gameTimer >= totalGameTime)
            {
                gameOver = true;
            }
        }
        if (Input.GetKey(KeyCode.LeftShift) || showCursor)
        {
            Cursor.visible = true;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            showCursor = false;
        }
        if (!showCursor)
        {
            Cursor.visible = false;
        }
        if (nbrAchievementsCompleted == 6 || gameOver)
        {
            gameStarted = false;
            StartCoroutine(GameOver());
        }
    }
    //När man går in i en station:
    public void Station(int index)
    {
        showCursor = true;
        playerBehaviour.Moveable = false;
        currentItem = index;
        //itemManager.AddItem(index + 1, items[index]);
    }
    public void Achievement(int index, GameObject halo)
    {
        nbrAchievementsCompleted++;
        completedAchievementIndex.Add(index);
        showCursor = true;
        playerBehaviour.Moveable = false;
        menuManager.AchievementCompleted(index);
        halo.SetActive(false);
    }
    //När en dialog är klar:
    public void Play(bool achievement)
    {
        if (achievement)
        {
            playerBehaviour.Moveable = true;
            showCursor = false;
        }
        else if (correctItem)
        {
            playerBehaviour.Moveable = true;
            showCursor = false;
            xmlManager.Dialogue();
        }
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(1);
        int timeToFinish = (int)gameTimer;
        menuManager.GameOver(nbrAchievementsCompleted, timeToFinish);
    }

}

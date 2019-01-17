﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggCare : MonoBehaviour
{

    [SerializeField]
    float timer;
    float spawnCounter, rnd, counter;

    [SerializeField]
    int maxDeathCount;
    public int deadEggs, eggLevel;

    [SerializeField]
    GameObject weed, egg2, egg3, deadEgg;
    GameObject player, gameManager;

    GameObject[] eggLocations;


    public List<GameObject> takenLocation;

    PlayerBehaviour playerBehaviour;
    testGameManager testManager;
    MenuManager menuManager;

    bool gameStart;

    void Start()
    {
        takenLocation = new List<GameObject>();
        AddEggs();
        counter = timer;
        deadEggs = 0;
        gameStart = true;

        foreach (GameObject egg in eggLocations)
        {
            egg.GetComponent<Eggs>().enabled = true;

        }

        player = GameObject.FindGameObjectWithTag("player");
        gameManager = GameObject.Find("GameManager");
        playerBehaviour = player.GetComponent<PlayerBehaviour>();
        menuManager = gameManager.GetComponent<MenuManager>();
        testManager = GetComponent<testGameManager>();

        menuManager.MiniGame1(true);
    }
    void Update()
    {
        if (gameStart)
        {
            if (counter > 0)
            {
                counter -= Time.deltaTime;
                menuManager.timerText.text = counter.ToString();
            }
                

            else if (deadEggs < maxDeathCount && counter <= 0)
            {
                Win();
            }
            else if (deadEggs >= maxDeathCount)
            {
                Loose();
            }
        }
    }

    void AddEggs()
    {
        eggLocations = GameObject.FindGameObjectsWithTag("Egg");
        foreach (GameObject egg in eggLocations)
        {
            egg.GetComponent<Eggs>().enabled = true;
        }
    }

    void Win()
    {
        gameStart = false;
        testManager.EndGame(true);
        eggLocations = GameObject.FindGameObjectsWithTag("Egg");
        print("idunno");
        foreach (GameObject egg in eggLocations)
        {
            egg.GetComponent<Eggs>().enabled = false;
            egg.GetComponent<SphereCollider>().enabled = false;
        }

    }
    void Loose()
    {
        gameStart = false;
        testManager.EndGame(false);
        eggLocations = GameObject.FindGameObjectsWithTag("Egg");
        foreach (GameObject egg in eggLocations)
        {
            egg.GetComponent<Eggs>().enabled = false;
            egg.GetComponent<SphereCollider>().enabled = false;
        }
    }

    public void SwitchPlaces()
    {
        AddEggs();
        foreach (GameObject egg in eggLocations)
        {
            egg.GetComponent<Eggs>().onEgg = false;
        }
    }

    public void Upgrade(int level, Vector3 pos, GameObject egg)
    {
        switch (level)
        {
            case 1:
                Instantiate(weed, pos, Quaternion.identity);
                Destroy(egg);
                AddEggs();
                break;

            case 2:
                Instantiate(egg2, pos, Quaternion.identity);
                Destroy(egg);
                AddEggs();
                break;

            case 3:
                Instantiate(egg3, pos, Quaternion.identity);
                Destroy(egg);
                AddEggs();
                break;

            case 4:
                Instantiate(deadEgg, pos, Quaternion.identity);
                Destroy(egg);
                AddEggs();
                DeadEggs();
                break;
        }
    }


    public void DeadEggs()
    {
        ScoreManager();
        if (deadEggs >= maxDeathCount)
        {
            Loose();
        }
    }

    public void ScoreManager()
    {
        deadEggs++;
        menuManager.SetScore(deadEggs);
    }


}

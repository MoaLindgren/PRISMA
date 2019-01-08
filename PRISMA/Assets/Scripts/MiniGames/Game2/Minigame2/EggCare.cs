using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggCare : MonoBehaviour
{

    [SerializeField]
    float timer, spawnFlowerTimer, lowSpawnRate, highSpawnRate;
    float spawnCounter, rnd, counter;

    [SerializeField]
    int numberOfWeed, maxDeathCount;
    public int deadEggs;

    [SerializeField]
    GameObject weed;
    GameObject player;

    GameObject[] eggLocations;


    public List<GameObject> takenLocation;

    PlayerBehaviour playerBehaviour;
    testGameManager testGame;
    bool gameStart;

    void Start()
    {
        takenLocation = new List<GameObject>();
        eggLocations = GameObject.FindGameObjectsWithTag("Egg");
        counter = timer;
        deadEggs = 0;
        gameStart = true;

        foreach (GameObject egg in eggLocations)
        {
            egg.GetComponent<Eggs>().enabled = true;
        }

        player = GameObject.FindGameObjectWithTag("player");
        playerBehaviour = player.GetComponent<PlayerBehaviour>();
        testGame = GetComponent<testGameManager>();
        Randomize();
    }
    void Update()
    {
        if (gameStart)
        {
            if (counter > 0)
                counter -= Time.deltaTime;

            else if (deadEggs < maxDeathCount && counter <= 0)
            {
                Win();
            }
            if (deadEggs >= maxDeathCount)
            {
                gameStart = false;
                testGame.EndGame(false);
                foreach (GameObject egg in eggLocations)
                {
                    egg.GetComponent<Eggs>().enabled = false;
                }

            }
        }


    }

    void Win()
    {
        gameStart = false;
        testGame.EndGame(true);
        foreach (GameObject egg in eggLocations)
        {
            egg.GetComponent<Eggs>().enabled = false;
        }
    }


    public void DeadFlower()
    {
        deadEggs++;
    }

    public void LevelFlower(int level)
    {
        if (level == 2)
        {
            //print("nu är jag lvl 2");
        }

        else if (level == 3)
        {
            //print("nu är jag lvl 3");
        }
    }
    void Randomize()
    {
        rnd = Random.Range(lowSpawnRate, highSpawnRate);
    }
}

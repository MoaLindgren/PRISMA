using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGame2 : MonoBehaviour
{

    [SerializeField]
    float timer, spawnFlowerTimer, lowSpawnRate, highSpawnRate;
    float spawnCounter, rnd, counter;

    [SerializeField]
    int numberOfWeed, maxDeathCount;
    public int deadFlowers;

    [SerializeField]
    GameObject weed;
    GameObject player;

    GameObject[] weedLocations;

    
    public List<GameObject> takenLocation;

    PlayerBehaviour playerBehaviour;
    testGameManager testGame;
    bool gameStart;

    void Start()
    {
        takenLocation = new List<GameObject>();
        weedLocations = GameObject.FindGameObjectsWithTag("WeedLocation");
        counter = timer;
        spawnCounter = spawnFlowerTimer;
        deadFlowers = 0;
        gameStart = true;

        player = GameObject.FindGameObjectWithTag("player");
        playerBehaviour = player.GetComponent<PlayerBehaviour>();
        testGame = GetComponent<testGameManager>();
        Randomize();
        SpawnWeed();
    }
    void Update()
    {
        if (gameStart)
        {
            if (counter > 0)
                counter -= Time.deltaTime;

            else if (deadFlowers < maxDeathCount && counter <= 0)
            {
                Win();
            }

            if (spawnCounter > 0)
                spawnCounter -= Time.deltaTime;

            else if (spawnCounter <= 0)
            {
                Randomize();
                SpawnWeed();
                spawnCounter = rnd;
            }
            if (deadFlowers >= maxDeathCount)
            {
                gameStart = false;
                testGame.EndGame(false);
            }
        }


    }

    void Win()
    {
        gameStart = false;
        testGame.EndGame(true);
    }

    public void DeadFlower()
    {
        deadFlowers++;
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

    void SpawnWeed()
    {
        int rndW = Random.Range(0, numberOfWeed);
        if (takenLocation.Count <= weedLocations.Length)
        {
            for (int i = 0; i < rndW; i++) 
            {
                int rnd = Random.Range(0, weedLocations.Length);

                if (!takenLocation.Contains(weedLocations[rnd]))
                {
                    GameObject newWeed = Instantiate(weed, new Vector3(weedLocations[rnd].transform.position.x, weedLocations[rnd].transform.position.y, weedLocations[rnd].transform.position.z), Quaternion.Euler(-11, 110, 0));
                    takenLocation.Add(weedLocations[rnd]);
                    newWeed.GetComponent<WeedManager>().myLocation = weedLocations[rnd];
                }

            }
        }

    }

    void Randomize()
    {
        rnd = Random.Range(lowSpawnRate, highSpawnRate);
    }
}

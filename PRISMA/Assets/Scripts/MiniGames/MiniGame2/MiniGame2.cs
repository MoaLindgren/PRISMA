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

    List<int> takenNumbers;

    PlayerBehaviour playerBehaviour;
    testGameManager testGame;
    bool gameStart;

    void Start()
    {
        takenNumbers = new List<int>();
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

    void SpawnWeed()
    {

        int rndW = Random.Range(0, numberOfWeed);
        for (int i = 0; i < rndW; i++)
        {

            int rnd = Random.Range(0, weedLocations.Length);

            //GameObject weedloc = weedLocations[rnd];
            if (!takenNumbers.Contains(rnd))
            {
                Instantiate(weed, new Vector3(weedLocations[rnd].transform.position.x, weedLocations[rnd].transform.position.y, weedLocations[rnd].transform.position.z), Quaternion.identity);
            }
            else
            {
                i--;
            }
            takenNumbers.Add(rnd);
        }
        takenNumbers.Clear();

    }

    void Randomize()
    {
        rnd = Random.Range(lowSpawnRate, highSpawnRate);
    }
}

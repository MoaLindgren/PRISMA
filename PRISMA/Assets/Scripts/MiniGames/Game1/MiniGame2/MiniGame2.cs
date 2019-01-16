using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGame2 : MonoBehaviour
{

    [SerializeField]
    float timer, spawnFlowerTimer, shortTime, highTime;
    float spawnCounter, counter, rndTime, rnd;

    [SerializeField]
    int numberOfWeed, maxDeathCount, lowSpawnRate, highSpawnRate ;
    public int deadFlowers;

    [SerializeField]
    GameObject weed, weed2, weed3;
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
                spawnCounter = rndTime;
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
        int rndW = Random.Range(0, numberOfWeed); //platsen plantorna spawnar på
        if (takenLocation.Count <= weedLocations.Length)
        {
            for (int i = 0; i < rndW; i++) 
            {

               int rnd = Random.Range(0, weedLocations.Length);  //Antalet plantor som spawnar

                if (!takenLocation.Contains(weedLocations[rnd]))
                {
                    GameObject newWeed = Instantiate(weed, new Vector3(weedLocations[rnd].transform.position.x, weedLocations[rnd].transform.position.y, weedLocations[rnd].transform.position.z), Quaternion.Euler(-11, 110, 0));
                    takenLocation.Add(weedLocations[rnd]);
                    
                    newWeed.GetComponent<WeedManager>().myLocation = weedLocations[rnd];
                }
            }
        }

    }

   public void UpgradeWeed(GameObject location, int level)
    {

        switch (level)
        {
            case 1:
                GameObject upgradeWeed = Instantiate(weed2, new Vector3(location.transform.position.x, location.transform.position.y, location.transform.position.z), Quaternion.Euler(-11, 110, 0));
                takenLocation.Add(location);
                upgradeWeed.GetComponent<WeedManager>().myLocation = location;
                break;

            case 2:
                GameObject upgradeWeed2 = Instantiate(weed3, new Vector3(location.transform.position.x, location.transform.position.y, location.transform.position.z), Quaternion.Euler(-11, 110, 0));
                takenLocation.Add(location);
                upgradeWeed2.GetComponent<WeedManager>().myLocation = location;
                break;
        }

    }

    void Randomize()
    {
        rnd = Random.Range(lowSpawnRate, highSpawnRate);
        rndTime = Random.Range(shortTime, highTime);
    }
}

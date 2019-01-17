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
    public int deadFlowers, score;

    [SerializeField]
    GameObject weed, weed2, weed3;
    GameObject player, gameManager;

    GameObject[] weedLocations;

    [SerializeField]
    Vector3 cameraPos;

    public List<GameObject> takenLocation;

    PlayerBehaviour playerBehaviour;
    testGameManager testGame;
    MenuManager menuManager;


    bool gameStart;

    void Start()
    {
        takenLocation = new List<GameObject>();
        weedLocations = GameObject.FindGameObjectsWithTag("WeedLocation");
        counter = timer;
        spawnCounter = spawnFlowerTimer;
        deadFlowers = 0;
        gameStart = true;

        score = 0;
        player = GameObject.FindGameObjectWithTag("player");
        gameManager = GameObject.Find("GameManager");
        playerBehaviour = player.GetComponent<PlayerBehaviour>();
        menuManager = gameManager.GetComponent<MenuManager>();
        testGame = GetComponent<testGameManager>();
        Randomize();
        SpawnWeed();

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
            if (deadFlowers >= maxDeathCount) //Om man förlorar
            {
                Loose();
            }
        }


    }

    void Win()
    {
        gameStart = false;
        testGame.EndGame(true);
        GameObject[] weeds = GameObject.FindGameObjectsWithTag("Weed");
        foreach (GameObject weed in weeds)
        {
            Destroy(weed);
        }
    }

    void Loose()
    {
        GameObject[] weeds = GameObject.FindGameObjectsWithTag("Weed");
        foreach (GameObject weed in weeds)
        {
            Destroy(weed);
        }
        gameStart = false;
        testGame.EndGame(false);
        
    }

    public void DeadFlower()
    {
        deadFlowers++;
        ScoreManager();
    }

    public void ScoreManager()
    {
        score++;
        menuManager.SetScore(score);
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

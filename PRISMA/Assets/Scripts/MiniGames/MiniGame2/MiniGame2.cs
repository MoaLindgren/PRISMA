using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGame2 : MonoBehaviour {

    [SerializeField]
    float timer;
    public float counter;
    public int deadFlowers;

    [SerializeField]
    float spawnFlowerTimer, lowSpawnRate, highSpawnRate;

    float spawnCounter;
    float rnd;

    [SerializeField]
    int numberOfWeed, maxDeathCount;

    [SerializeField]
    GameObject weed;

    GameObject[] weedLocations;

    List<int> takenNumbers;

    // Use this for initialization
    void Start()
    {
        takenNumbers = new List<int>();
        weedLocations = GameObject.FindGameObjectsWithTag("WeedLocation");
        counter = timer;
        spawnCounter = spawnFlowerTimer;
        deadFlowers = 0;
        Randomize();
        SpawnWeed();
        
    }
	
	// Update is called once per frame
	void Update ()
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
    }

    void Win ()
    {
        print(deadFlowers + " " + "We live to fight another day");
    }

    public void DeadFlower()
    {
        deadFlowers++;
        if (deadFlowers >= maxDeathCount)
            print(deadFlowers + " " + "WE FUCKING LOST");
    }

    void SpawnWeed ()
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

    void Randomize ()
    {
       rnd = Random.Range(lowSpawnRate, highSpawnRate);
    }
}

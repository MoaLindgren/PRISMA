using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGame1 : MonoBehaviour
{
    [SerializeField]
    float timer;
    float counter, flyHeight;
    [SerializeField]
    GameObject birdPrefab, gameManager;
    GameObject startPosition;
    GameObject[] birdDestinations;
    bool instantiateBird;
    ItemsManager itemManager;

    void Start()
    {
        counter = timer;
        flyHeight = 55;
        instantiateBird = false;
        birdDestinations = GameObject.FindGameObjectsWithTag("BirdDestination");

        itemManager = gameManager.GetComponent<ItemsManager>();
        itemManager.AddItem(1, "Notebook");
    }

    void Update()
    {
        counter -= Time.deltaTime;
        if (counter < 0)
        {
            instantiateBird = true;
            if(instantiateBird)
            {
                int rnd = Random.Range(1, birdDestinations.Length);
                startPosition = birdDestinations[rnd];
                Instantiate(birdPrefab, new Vector3(startPosition.transform.position.x, flyHeight, startPosition.transform.position.z), Quaternion.identity);
                instantiateBird = false;
                counter = timer;
            }
        }
    }
}

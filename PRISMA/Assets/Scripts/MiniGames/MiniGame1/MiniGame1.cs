using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGame1 : MonoBehaviour
{
    [SerializeField]
    float timer;
    float counter;
    [SerializeField]
    GameObject birdPrefab;
    GameObject startPosition;
    GameObject[] birdDestinations;
    bool instantiateBird;

    void Start()
    {
        counter = timer;
        instantiateBird = false;
        birdDestinations = GameObject.FindGameObjectsWithTag("BirdDestination");
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
                Instantiate(birdPrefab, new Vector3(startPosition.transform.position.x, 55, startPosition.transform.position.z), Quaternion.identity);
                instantiateBird = false;
                counter = timer;
            }
        }
    }
}

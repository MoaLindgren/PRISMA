using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishBehaviour : MonoBehaviour {

    [SerializeField]
    float maxSpeed, maxTime, swimHeight, time;
    float speed;
    GameObject[] destinations;
    GameObject fishDestination;
    Vector3 destination;
    bool swimReady;
    ItemsManager itemManager;
    //testMiniGame1 miniGame1;
    //GameObject gameManager, station1;
    //bool counted;

    void Awake()
    {
        //counted = false;
        swimReady = true;
        destinations = GameObject.FindGameObjectsWithTag("FishDestination");
        //gameManager = GameObject.Find("GameManager");
        //station1 = GameObject.Find("Station1");
        //light = transform.GetChild(3).gameObject;
        //miniGame1 = station1.GetComponent<testMiniGame1>();
        //itemManager = gameManager.GetComponent<ItemsManager>();
    }

    void Start()
    {

        SetDestination();
    }
    void Update()
    {
        
        
        if (swimReady)
        {
            time -= Time.deltaTime;
            if (time < 0)
            {
                float step = speed;
                transform.position = Vector3.MoveTowards(transform.position, destination, step);
                transform.LookAt(destination);
                if (transform.position == destination)
                {
                    SetDestination();
                    time = maxTime;
                }
            }
        }
    }

    //void OnMouseDown()
    //{
    //    //Om spelaren håller i rätt redskap:
    //    if (itemManager.itemIndex == 2)
    //    {
    //        if (!this.counted)
    //        {
    //            miniGame1.ScoreManager();
    //            this.counted = true;
    //            light.SetActive(false);
    //        }

    //    }


    //}

    void SetDestination()
    {
        int maxValue = destinations.Length;
        int rnd = Random.Range(0, maxValue);

        fishDestination = destinations[rnd];
        //flyHeight = miniGame1.flyHeight;
        destination = new Vector3(fishDestination.transform.position.x, swimHeight, fishDestination.transform.position.z);
        RandomizeValues();
    }
    void RandomizeValues()
    {
        float rndSpeed = Random.Range(0.3f, maxSpeed);
        speed = rndSpeed;
        swimReady = true;
        float rndTime = Random.Range(0.1f, maxTime);
        maxTime = rndTime;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishBehaviour : MonoBehaviour {

    [SerializeField]
    float maxSpeed, maxTime;
    float speed, time, swimHeight;
    GameObject[] destinations;
    GameObject tree, light;
    Vector3 destination;
    bool swimReady;
    ItemsManager itemManager;
    MiniGame4 miniGame4;
    GameObject gameManager, station4;
    bool counted;

    void Awake()
    {
        counted = false;
        swimReady = false;
        destinations = GameObject.FindGameObjectsWithTag("FishDestination");
        gameManager = GameObject.Find("GameManager");
        station4 = GameObject.Find("Station4");
        light = transform.GetChild(3).gameObject;
        miniGame4 = station4.GetComponent<MiniGame4>();
        itemManager = gameManager.GetComponent<ItemsManager>();
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
                    Destroy(gameObject);
                }
            }
        }
    }

    void OnMouseDown()
    {
        //Om spelaren håller i rätt redskap:
        if (itemManager.itemIndex == 2)
        {
            if (!this.counted)
            {
                miniGame4.ScoreManager();
                this.counted = true;
                light.SetActive(false);
            }

        }


    }

    void SetDestination()
    {
        int maxValue = destinations.Length;
        int rnd = Random.Range(0, maxValue);

        tree = destinations[rnd];
        swimHeight = miniGame4.flyHeight;
        destination = new Vector3(tree.transform.position.x, swimHeight, tree.transform.position.z);
        RandomizeValues();
    }
    void RandomizeValues()
    {
        float rndSpeed = Random.Range(1, maxSpeed);
        speed = rndSpeed;
        swimReady = true;
    }
}
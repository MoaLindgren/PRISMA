using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Saknas: 
// Fåglarna ska blinka

public class BirdBehaviour : MonoBehaviour
{
    [SerializeField]
    float maxSpeed, maxTime;
    float speed, time, flyHeight;
    GameObject[] destinations;
    GameObject tree, light;
    Vector3 destination;
    bool flyReady;
    ItemsManager itemManager;
    testMiniGame1 miniGame1;
    GameObject gameManager, station1;
    bool counted;

    void Awake()
    {
        counted = false;
        flyReady = false;
        destinations = GameObject.FindGameObjectsWithTag("BirdDestination");
        gameManager = GameObject.Find("GameManager");
        station1 = GameObject.Find("Station1");
        light = transform.GetChild(3).gameObject;
        miniGame1 = station1.GetComponent<testMiniGame1>();
        itemManager = gameManager.GetComponent<ItemsManager>();
    }

    void Start()
    {

        SetDestination();
    }
    void Update()
    {
        if (flyReady)
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
                miniGame1.ScoreManager();
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
        flyHeight = miniGame1.flyHeight;
        destination = new Vector3(tree.transform.position.x, flyHeight, tree.transform.position.z);
        RandomizeValues();
    }
    void RandomizeValues()
    {
        float rndSpeed = Random.Range(1, maxSpeed);
        speed = rndSpeed;
        flyReady = true;
    }
}

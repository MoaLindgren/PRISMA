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
    GameObject tree;
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
        flyHeight = 55;
        destinations = GameObject.FindGameObjectsWithTag("BirdDestination");
        gameManager = GameObject.Find("GameManager");
        station1 = GameObject.Find("Station1");
        miniGame1 = station1.GetComponent<testMiniGame1>();
        itemManager = gameManager.GetComponent<ItemsManager>();
    }

    void Start()
    {

        SetDestination();
    }
    void Update()
    {
        if(flyReady)
        {
            time -= Time.deltaTime;
            if(time < 0)
            {
                float step = speed;
                transform.position = Vector3.MoveTowards(transform.position, destination, step);
                if(transform.position == destination)
                {
                    Destroy(gameObject);
                }
            }
        }
    }

    void OnMouseDown()
    {
        //Om spelaren håller i rätt redskap:

        if(itemManager.itemIndex == 1)
        {
            if(!this.counted)
            {

                miniGame1.ScoreManager();
                this.counted = true;
                this.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            }

        }


    }

    void SetDestination()
    {
        int maxValue = destinations.Length;
        int rnd = Random.Range(0, maxValue);

        if(tree != gameObject)
        {
            tree = destinations[rnd];
            destination = new Vector3(tree.transform.position.x, flyHeight, tree.transform.position.z);
            RandomizeValues(maxTime, maxSpeed);
        }
        else
        {
            SetDestination();
        }
    }
    void RandomizeValues(float maxT, float maxS)
    {
        float rndTime = Random.Range(1, maxT);
        time = rndTime;

        float rndSpeed = Random.Range(0, maxS);
        speed = rndSpeed;
        flyReady = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdBehaviour : MonoBehaviour
{
    [SerializeField]
    float maxSpeed, maxTime;
    float speed, time;
    GameObject[] destinations;
    GameObject tree;
    Vector3 destination;
    bool flyReady;

    void Awake()
    {
        flyReady = false;
        destinations = GameObject.FindGameObjectsWithTag("BirdDestination");
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
                    //Borde nog inte vara "Destroy". De borde inte försvinna för att vi räknar dem.
                    Destroy(gameObject);
                }
            }
        }
    }

    void OnMouseDown()
    {
        //Om spelaren håller i rätt redskap:
        Destroy(gameObject);
    }

    void SetDestination()
    {
        int maxValue = destinations.Length;
        int rnd = Random.Range(0, maxValue);

        if(tree != gameObject)
        {
            tree = destinations[rnd];
            destination = new Vector3(tree.transform.position.x, 55, tree.transform.position.z);
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

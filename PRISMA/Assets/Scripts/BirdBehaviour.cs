using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdBehaviour : MonoBehaviour
{
    [SerializeField]
    float maxSpeed, maxTime;
    GameObject[] destinations;
    GameObject destination;
    bool flyReady;

    void Start()
    {
        destinations = GameObject.FindGameObjectsWithTag("BirdDestination");
    }

    void Awake()
    {
        SetDestination();
        Timer();
    }
    void Update()
    {
        if(flyReady)
        {
            gameObject.transform.position = destination.transform.position;
        }
    }

    void SetDestination()
    {
        int maxValue = destinations.Length;
        int rnd = Random.Range(0, maxValue);

        destination = destinations[rnd];
    }
    void Timer()
    {
        float rndTime = Random.Range(1, maxTime);

    }
}

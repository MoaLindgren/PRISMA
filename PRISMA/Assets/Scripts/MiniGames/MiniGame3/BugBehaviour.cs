using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugBehaviour : MonoBehaviour
{
    [SerializeField]
    float speed;
    float rndX, rndZ;
    [SerializeField]
    GameObject centerObject;
    Vector3 destination;
    [SerializeField]
    bool move;

    void Start()
    {
        RandomizeDestination();
        move = true;
    }
    void Update()
    {
        if(move)
        {
            float step = speed;
            transform.position = Vector3.MoveTowards(transform.position, destination, step);
            transform.LookAt(destination);

            if (Vector3.Distance(centerObject.transform.position, transform.position) >= 3)
            {
                destination = centerObject.transform.position;
            }
            else if (transform.position == destination)
            {
                RandomizeDestination();
            }
        }
    }
    void RandomizeDestination()
    {
        float rndX = Random.Range(gameObject.transform.position.x - 2, gameObject.transform.position.x + 2);
        float rndZ = Random.Range(gameObject.transform.position.z - 2, gameObject.transform.position.z + 2);
        
        destination = new Vector3(rndX, 10, rndZ);
    }
}

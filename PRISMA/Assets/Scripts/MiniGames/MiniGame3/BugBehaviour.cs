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
        move = false;
        RandomizeDestination();
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
                Turn();
            }
            else if (transform.position == destination)
            {
                RandomizeDestination();
            }
        }

    }
    void RandomizeDestination()
    {
        float rndX = Random.Range(gameObject.transform.position.z - 2, gameObject.transform.position.z + 2);
        float rndZ = Random.Range(gameObject.transform.position.y - 2, gameObject.transform.position.y + 2);
        
        destination = new Vector3(rndX, 0, rndZ);
        this.move = true;
    }
    void Turn()
    {
        if(destination.z > transform.position.z)
        {
            rndX = transform.position.z -2;
        }
        else if (destination.z < transform.position.z)
        {
            rndX = transform.position.z + 2;
        }

        if (destination.y > transform.position.y)
        {
            rndZ = transform.position.y - 2;
        }
        else if (destination.y < transform.position.y)
        {
            rndZ = transform.position.y + 2;
        }

        destination = new Vector3(rndX, 0, rndZ);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugBehaviour : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    GameObject centerObject;
    Vector3 destination;
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

            //Jag vill göra en check så att insekterna in springer för långt ifrån mittpunkten. Just nu springer dom random, men längre och längre bort.
            Ray ray = new Ray(transform.position, centerObject.transform.position);
            Debug.DrawRay(transform.position, centerObject.transform.position); //varför riktar den sig inte mot centerobject??
            
            if (transform.position == destination)
            {
                RandomizeDestination();
            }
        }

    }
    void RandomizeDestination()
    {
        float rndX = Random.Range(gameObject.transform.position.x - 2, gameObject.transform.position.x + 2);
        float rndZ = Random.Range(gameObject.transform.position.z - 2, gameObject.transform.position.z + 2);
        
        destination = new Vector3(rndX, 0, rndZ);
        move = true;
    }
    void OnCollision(Collision other)
    {
        print(other.gameObject.name);
    }

}

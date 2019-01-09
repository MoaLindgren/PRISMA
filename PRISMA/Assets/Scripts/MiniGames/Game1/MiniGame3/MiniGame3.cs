using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGame3 : MonoBehaviour
{
    [SerializeField]
    GameObject tulkortPrefab, waypointsParent, player;
    List<GameObject> waypoints;
    GameObject destination;
    [SerializeField]
    float clickTimer, max;
    float clickTimerCounter, bugTimerCounter, rndTimer;
    Vector3 clickPosition;
    bool gameStart;
    [SerializeField]
    bool spawnReady;
    float speed;
    PlayerBehaviour playerBehaviour;
    testGameManager gameManager;
    int destinationIndex;
    bool move;


    void Start()
    {
        gameManager = gameObject.GetComponent<testGameManager>();
        destinationIndex = 0;
        move = true;
        playerBehaviour = player.GetComponent<PlayerBehaviour>();
        speed = playerBehaviour.moveSpeed;
        waypoints = new List<GameObject>();
        for(int i = 0; i < waypointsParent.transform.childCount; i++)
        {
            waypoints.Add(waypointsParent.transform.GetChild(i).gameObject);
        }
        playerBehaviour.moveable = false;
        spawnReady = true;
        clickTimerCounter = clickTimer;
        RandomizeValues();
        gameStart = true;
    }

    void Update()
    {
        destination = waypoints[destinationIndex];
        if (gameStart)
        {
            if (!spawnReady)
            {
                clickTimerCounter -= Time.deltaTime;
                if (clickTimerCounter <= 0)
                {
                    spawnReady = true;
                }
            }
            if (Input.GetMouseButtonDown(0) && spawnReady)
            {
                clickTimerCounter = clickTimer;
                spawnReady = false;

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    clickPosition = hit.point;
                    Instantiate(tulkortPrefab, clickPosition, Quaternion.identity);
                }
            }
            bugTimerCounter -= Time.deltaTime;
            if(bugTimerCounter <= 0)
            {

            }
            if(move)
            {
                float step = 0.1f;
                player.transform.position = Vector3.MoveTowards(player.transform.position, destination.transform.position, step);
                player.transform.LookAt(destination.transform.position);


                if (Vector3.Distance(destination.transform.position, player.transform.position) <= 2)
                {
                    destinationIndex++;
                    if(destinationIndex == waypoints.Count)
                    {
                        move = false;
                        gameManager.EndGame(true);
                        gameStart = false;
                    }
                    return;
                }
            }
        }
    }



    void RandomizeValues()
    {
        rndTimer = Random.Range(1, max);
    }


}

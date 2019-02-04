using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGame3 : MonoBehaviour
{
    [SerializeField]
    GameObject tulkortPrefab, waypointsParent, player;
    List<GameObject> waypoints;
    GameObject destination;
    Vector3 clickPosition;

    [SerializeField]
    Vector3 cameraPos;

    PlayerBehaviour playerBehaviour;
    GameManager gameManager;

    [SerializeField]
    float clickTimer, max;
    float clickTimerCounter, bugTimerCounter, rndTimer, speed;
    [SerializeField]
    int score, numberOfPlants;
    int destinationIndex, plantCounter;
    bool gameStart, move, plantReady;

    void Start()
    {
        gameManager = gameObject.GetComponent<GameManager>();
        playerBehaviour = player.GetComponent<PlayerBehaviour>();

        InitializeGame();
        RandomizeValues();

        move = true;
        plantReady = true;
        gameStart = true;
    }
    void InitializeGame()
    {
        speed = playerBehaviour.moveSpeed;
        clickTimerCounter = clickTimer;

        plantCounter = 0;
        destinationIndex = 0;
        waypoints = new List<GameObject>();
        for (int i = 0; i < waypointsParent.transform.childCount; i++)
        {
            waypoints.Add(waypointsParent.transform.GetChild(i).gameObject);
        }
    }
    void Update()
    {
        if (gameStart)
        {

            if (!plantReady)
            {
                clickTimerCounter -= Time.deltaTime;
                if (clickTimerCounter <= 0)
                {
                    plantReady = true;
                }
            }
            if (Input.GetMouseButtonDown(0) && plantReady)
            {
                SpawnPlants();
            }
            bugTimerCounter -= Time.deltaTime;

            PlayerAutomaticMovement();
        }
    }

    void SpawnPlants()
    {
        clickTimerCounter = clickTimer;
        plantReady = false;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            GameObject clickObject = hit.transform.gameObject;
            clickPosition = hit.point;
            if (plantCounter < numberOfPlants)
            {
                if (clickObject.tag == "Bugs")
                {
                    score++;
                    Instantiate(tulkortPrefab, clickObject.transform.position, Quaternion.identity);
                }
                else if (clickObject.name == "Terrain")
                {
                    Instantiate(tulkortPrefab, clickPosition, Quaternion.identity);
                }
                plantCounter++;
            }
        }
    }
    void PlayerAutomaticMovement()
    {
        destination = waypoints[destinationIndex];
        float step = 0.1f;
        player.transform.position = Vector3.MoveTowards(player.transform.position, destination.transform.position, step);
        player.transform.LookAt(destination.transform.position);

        if (Vector3.Distance(destination.transform.position, player.transform.position) <= 2)
        {
            destinationIndex++;
            if (destinationIndex == waypoints.Count)
            {
                gameManager.EndGame(true);
                gameStart = false;
            }
            return;
        }
    }
    void RandomizeValues()
    {
        rndTimer = Random.Range(1, max);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGame1 : MonoBehaviour
{
    [SerializeField]
    float timer;
    float counter, flyHeight;
    public float gameTimer;
    [SerializeField]
    GameObject birdPrefab, gameManager;
    GameObject startPosition;
    GameObject[] birdDestinations;
    bool instantiateBird;
    ItemsManager itemManager;
    public int score;

    MenuManager menuManager;
    MiniGamesManager miniGamesManager;

    void Start()
    {
        score = 0;
        counter = timer;
        flyHeight = 55;
        instantiateBird = false;
        birdDestinations = GameObject.FindGameObjectsWithTag("BirdDestination");

        itemManager = gameManager.GetComponent<ItemsManager>();
        menuManager = gameManager.GetComponent<MenuManager>();
        miniGamesManager = GetComponent<MiniGamesManager>();
        itemManager.AddItem(1, "Anteckningsblock");

        menuManager.MiniGame1();
    }

    void Update()
    {
        counter -= Time.deltaTime;
        gameTimer -= Time.deltaTime;
        menuManager.timerText.text = gameTimer.ToString();

        if (counter < 0)
        {
            instantiateBird = true;
            if(instantiateBird)
            {
                int rnd = Random.Range(1, birdDestinations.Length);
                startPosition = birdDestinations[rnd];
                Instantiate(birdPrefab, new Vector3(startPosition.transform.position.x, flyHeight, startPosition.transform.position.z), Quaternion.identity);
                instantiateBird = false;
                counter = timer;
            }
        }
        if(gameTimer < 0)
        {
            miniGamesManager.GameOver();
        }
    }
    public void GameManager()
    {
        score++;
        menuManager.SetScore(score);
    }
}

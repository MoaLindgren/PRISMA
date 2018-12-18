using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testMiniGame1 : MonoBehaviour
{
    [SerializeField]
    float birdSpawnTimer, gameTimer;
    float birdSpawnCounter, flyHeight;
    int score;

    [SerializeField]
    bool instantiateBird, startGame;

    [SerializeField]
    GameObject birdPrefab;
    GameObject startPosition, gameManager, player;
    GameObject[] birdDestinations;

    PlayerBehaviour playerBehaviour;
    MenuManager menuManager;
    testGameManager testGame;
    XmlManager xmlManager;


    void Start()
    {
        score = 0;
        birdSpawnCounter = birdSpawnTimer;
        flyHeight = 55;
        startGame = true;

        birdDestinations = GameObject.FindGameObjectsWithTag("BirdDestination");
        gameManager = GameObject.Find("GameManager");
        player = GameObject.FindGameObjectWithTag("player");

        menuManager = gameManager.GetComponent<MenuManager>();
        xmlManager = gameManager.GetComponent<XmlManager>();
        playerBehaviour = player.GetComponent<PlayerBehaviour>();
        testGame = GetComponent<testGameManager>();
    }
    void Update()
    {
        if (startGame)
        {
            birdSpawnCounter -= Time.deltaTime;
            gameTimer -= Time.deltaTime;
            menuManager.timerText.text = gameTimer.ToString();

            if (birdSpawnCounter < 0)
            {
                instantiateBird = true;
                if (instantiateBird)
                {
                    int rnd = Random.Range(1, birdDestinations.Length);
                    startPosition = birdDestinations[rnd];
                    Instantiate(birdPrefab, new Vector3(startPosition.transform.position.x, flyHeight, startPosition.transform.position.z), Quaternion.identity);
                    instantiateBird = false;
                    birdSpawnCounter = birdSpawnTimer;
                }
            }
            if (gameTimer < 0)
            {
                startGame = false;
                GameOver();
            }
        }
    }
    public void GameManager()
    {
        score++;
        menuManager.SetScore(score);
    }
    void GameOver()
    {
        testGame.EndGame();
    }
}

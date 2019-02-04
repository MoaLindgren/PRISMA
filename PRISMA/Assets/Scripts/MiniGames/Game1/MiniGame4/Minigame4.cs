using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame4 : MonoBehaviour {
    [SerializeField]
    float fishSpawnTimer, gameTimer;
    public float swimHeight;
    float fishSpawCounter;
    int score;

    [SerializeField]
    bool instantiateFish, startGame;

    [SerializeField]
    GameObject fishPrefab;
    GameObject startPosition, gameManager, player;
    GameObject[] fishDestinations;

    [SerializeField]
    Vector3 cameraPos;

    PlayerBehaviour playerBehaviour;
    MenuManager menuManager;
    GameManager gameManagerScript;
    XmlManager xmlManager;


    void Start()
    {
        score = 0;
        fishSpawCounter = fishSpawnTimer;
        startGame = true;


        fishDestinations = GameObject.FindGameObjectsWithTag("FishDestination");
        gameManager = GameObject.Find("GameManager");
        player = GameObject.FindGameObjectWithTag("player");

        menuManager = gameManager.GetComponent<MenuManager>();
        xmlManager = gameManager.GetComponent<XmlManager>();
        playerBehaviour = player.GetComponent<PlayerBehaviour>();
        gameManagerScript = GetComponent<GameManager>();

        menuManager.MiniGame1(true);
    }
    void Update()
    {
        if (startGame)
        {
            fishSpawCounter -= Time.deltaTime;
            gameTimer -= Time.deltaTime;
            menuManager.timerText.text = gameTimer.ToString();

            if (fishSpawCounter < 0)
            {
                instantiateFish = true;
                if (instantiateFish)
                {
                    int rnd = Random.Range(1, fishDestinations.Length);
                    startPosition = fishDestinations[rnd];
                    Instantiate(fishPrefab, new Vector3(startPosition.transform.position.x, swimHeight, startPosition.transform.position.z), Quaternion.identity);
                    instantiateFish = false;
                    fishSpawCounter = fishSpawnTimer;
                }
            }
            if (gameTimer < 0)
            {
                startGame = false;
                GameOver();
            }
        }
    }
    public void ScoreManager()
    {
        score++;
        menuManager.SetScore(score);
    }
    void GameOver()
    {
        menuManager.MiniGame1(false);
        gameManagerScript.EndGame(true);
    }
}
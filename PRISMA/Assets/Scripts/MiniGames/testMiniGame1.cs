using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testMiniGame1 : MonoBehaviour
{
    [SerializeField]
    float birdSpawnTimer;
    float counter, flyHeight;
    public float gameTimer;
    public int score;

    [SerializeField]
    bool instantiateBird, startGame;

    [SerializeField]
    GameObject birdPrefab;
    GameObject startPosition, gameManager, player;
    GameObject[] birdDestinations;

    ItemsManager itemManager;
    PlayerBehaviour playerBehaviour;
    MenuManager menuManager;
    MiniGamesManager miniGamesManager;
    testGameManager testGame;
    XmlManager xmlManager;


    void Start()
    {
        score = 0;
        counter = birdSpawnTimer;
        flyHeight = 55;

        birdDestinations = GameObject.FindGameObjectsWithTag("BirdDestination");
        gameManager = GameObject.Find("GameManager");
        player = GameObject.FindGameObjectWithTag("player");
        itemManager = gameManager.GetComponent<ItemsManager>();
        menuManager = gameManager.GetComponent<MenuManager>();
        xmlManager = gameManager.GetComponent<XmlManager>();
        playerBehaviour = player.GetComponent<PlayerBehaviour>();
        testGame = GetComponent<testGameManager>();
    }

    void OnTriggerEnter()
    {
        itemManager.AddItem(1, "Anteckningsblock");
        menuManager.MiniGame1(); //<- ska inte göras förrän spelet faktiskt börjar. Dvs. När startgame blir true.
        menuManager.currentStation = this.gameObject;
    }
    void Update()
    {
        startGame = testGame.startGame;
        if (startGame)
        {
            counter -= Time.deltaTime;
            gameTimer -= Time.deltaTime;
            menuManager.timerText.text = gameTimer.ToString();

            if (counter < 0)
            {
                instantiateBird = true;
                if (instantiateBird)
                {
                    int rnd = Random.Range(1, birdDestinations.Length);
                    startPosition = birdDestinations[rnd];
                    Instantiate(birdPrefab, new Vector3(startPosition.transform.position.x, flyHeight, startPosition.transform.position.z), Quaternion.identity);
                    instantiateBird = false;
                    counter = birdSpawnTimer;
                }
            }
            if (gameTimer < 0)
            {
                print("yee");
                testGame.startGame = false;
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
        playerBehaviour.moveable = true;
        xmlManager.Dialogue(false);
    }


}

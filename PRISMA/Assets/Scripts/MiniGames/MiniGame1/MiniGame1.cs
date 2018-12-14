using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGame1 : MonoBehaviour
{
    [SerializeField]
    float timer;
    float counter, flyHeight;
    public float gameTimer;
    public int score;
    int gameIndex;

    bool instantiateBird, startGame;

    [SerializeField]
    GameObject birdPrefab;
    GameObject startPosition, gameManager, player;
    GameObject[] birdDestinations;

    ItemsManager itemManager;
    PlayerBehaviour playerBehaviour;
    MenuManager menuManager;
    MiniGamesManager miniGamesManager;
    XmlManager xmlManager;

    void Start()
    {
        score = 0;
        gameIndex = 1;
        counter = timer;
        flyHeight = 55;
        instantiateBird = false;

        birdDestinations = GameObject.FindGameObjectsWithTag("BirdDestination");
        player = GameObject.FindGameObjectWithTag("player");
        gameManager = GameObject.Find("GameManager");

        playerBehaviour = player.GetComponent<PlayerBehaviour>();
        xmlManager  = gameManager.GetComponent<XmlManager>();
        itemManager = gameManager.GetComponent<ItemsManager>();
        menuManager = gameManager.GetComponent<MenuManager>();
    }

    void OnTriggerEnter()
    {
        playerBehaviour.moveable = false;
        startGame = true; //Ska inte hända nu egentligen. Det ska bli true när man har klickat på sista dialogrutan, efter att man har valt anteckningsblocket.
        xmlManager.SetUpXML(gameIndex);
        itemManager.AddItem(1, "Anteckningsblock");
        menuManager.MiniGame1(); //<- ska inte göras förrän spelet faktiskt börjar. Dvs. När startgame blir true.
    }
    void Update()
    {
        if(startGame)
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
                    counter = timer;
                }
            }
            if (gameTimer < 0)
            {
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
        xmlManager.Dialogue();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int achievementIndex, stationIndex, nbrAchievementsCompleted, currentItem;
    bool correctItem, gameOver, gameStarted, showCursor, beatleAchievement;
    [SerializeField]
    float totalGameTime, gameTimer;
    string gameVersion;

    Vector3 playerLockRotation;
    GameObject player;
    XmlManager xmlManager;
    ItemsManager itemManager;
    MenuManager menuManager;
    PlayerBehaviour playerBehaviour;
    CameraManager cameraManager;
    SoundManager soundManager;

    List<int> completedAchievementIndex;
    [SerializeField]
    GameObject bloomAchievement;

    public bool CorrectItem
    {
        set { correctItem = value; }
        get { return correctItem; }
    }
    public int CurrentItem
    {
        get { return currentItem; }
    }
    public int AchievementIndex
    {
        set { achievementIndex = value; }
    }
    public List<int> CompletedAchievementIndex
    {
        get { return completedAchievementIndex; }
    }
    public bool GameStarted
    {
        set { gameStarted = value; }
    }
    public int StationIndex
    {
        get { return stationIndex; }
    }
    public bool BeatleAchievement
    {
        set { beatleAchievement = value; }
    }
    public string GameVersion
    {
        get { return gameVersion; }
    }


    void Start()
    {
        //Ändra scenernas namn istället???
        string scene = SceneManager.GetActiveScene().name;
        if(scene == "Game3")
        {
            gameVersion = "Game1";
        }
        if (scene == "Game4")
        {
            gameVersion = "Game2";
        }
        gameTimer = 0;
        gameStarted = false;
        gameOver = false;
        Cursor.visible = false;
        nbrAchievementsCompleted = 0;
        player = GameObject.FindGameObjectWithTag("player");
        cameraManager = GameObject.Find("Main Camera").GetComponent<CameraManager>();
        xmlManager = GetComponent<XmlManager>();
        itemManager = GetComponent<ItemsManager>();
        menuManager = GetComponent<MenuManager>();
        soundManager = GetComponent<SoundManager>();
        playerBehaviour = player.GetComponent<PlayerBehaviour>();
        completedAchievementIndex = new List<int>();
    }
    void Update()
    {
        if (gameStarted)
        {
            gameTimer += Time.deltaTime;
            if (gameTimer >= totalGameTime)
            {
                gameOver = true;
            }
            if (gameVersion == "Game1" && nbrAchievementsCompleted == 5 || gameVersion == "Game2" && nbrAchievementsCompleted == 6 || gameOver)
            {
                if (!menuManager.InfoBoxOpen)
                {
                    gameStarted = false;
                    StartCoroutine(GameOver());
                }

            }
        }
        if (!showCursor)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                Cursor.visible = true;
            }
            else
            {
                Cursor.visible = false;
            }
        }
        else if(showCursor)
        {
            Cursor.visible = true;
        }

    }
    //När man går in i en station:
    public void Station(int index)
    {
        showCursor = true;
        playerBehaviour.Moveable = false;
        stationIndex = index;
        currentItem = index;
    }
    public void Achievement(int index, GameObject achievement)
    {
        if (!completedAchievementIndex.Contains(index))
        {
            soundManager.TriggerSound(true);
            nbrAchievementsCompleted++;
            completedAchievementIndex.Add(index);
            showCursor = true;
            playerBehaviour.Moveable = false;
            menuManager.AchievementCompleted(index);
            if (index == 3 && achievement == null)
            {
                achievement = bloomAchievement;
            }
            GameObject halo = achievement.transform.GetChild(0).gameObject;
            halo.SetActive(false);
        }
    }
    public void Trigger()
    {
        playerBehaviour.Moveable = false;
    }
    //När en dialog är klar:
    public void Play(bool move)
    {
        if (move)
        {
            playerBehaviour.Moveable = true;
            showCursor = false;
        }
        else if (correctItem)
        {
            menuManager.NewItem = false;
            playerBehaviour.Moveable = true;
            showCursor = false;
            xmlManager.Dialogue();
            if(beatleAchievement)
            {
                GetComponent<SpawnPlants>().enabled = true;
            }

        }
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(1);
        int timeToFinish = (int)gameTimer;
        menuManager.GameOver(nbrAchievementsCompleted, timeToFinish);
    }

}

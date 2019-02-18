using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    GameObject backPackBox,
               dialogueBox,
               itemPrefab,
               backPackButton,
               player,
               highlightBackPack,
               achievements,
               endScreen,
               achievementInfoBox,
               messageLog,
               nextMessageButton,
               mainMenuButton;
    [SerializeField]
    Text messageLogContent;
    Text dialogueText, achievementsCompleted;
    GameObject[] itemsButtons;

    [SerializeField]
    List<Sprite> itemImages;
    [SerializeField]
    AudioClip buttonClick;
    List<GameObject> achievementList;

    bool newItem, infoBoxOpen;

    ItemsManager itemManager;
    PlayerBehaviour playerBehaviour;
    XmlManager xmlManager;
    SoundManager soundManager;
    GameManager gameManager;

    public bool NewItem
    {
        set { newItem = value; }
    }
    public bool InfoBoxOpen
    {
        get { return infoBoxOpen; }
    }

    void Start()
    {
        itemsButtons = GameObject.FindGameObjectsWithTag("ItemButton");
        gameManager = GetComponent<GameManager>();
        soundManager = GetComponent<SoundManager>();
        playerBehaviour = player.GetComponent<PlayerBehaviour>();
        itemManager = GetComponent<ItemsManager>();
        xmlManager = GetComponent<XmlManager>();
        achievementsCompleted = endScreen.GetComponentInChildren<Text>();
        achievementList = new List<GameObject>();

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (backPackBox.active)
            {
                CloseBackpack();
            }
            else
            {
                OpenBackpack();
            }
        }
        if(Input.GetKey(KeyCode.Escape))
        {
            mainMenuButton.SetActive(true);
        }
        else if(Input.GetKeyUp(KeyCode.Escape))
        {
            mainMenuButton.SetActive(false);
        }
        if (newItem)
        {
            highlightBackPack.SetActive(true);
        }
        else
        {
            highlightBackPack.SetActive(false);
        }
    }
    public void OpenCloseMessageLog(bool open)
    {
        messageLog.SetActive(open);
    }
    public void OpenBackpack()
    {
        soundManager.UISound(buttonClick);
        backPackBox.SetActive(true);
    }
    public void PickItem(int item)
    {
        if (GetComponent<GameManager>().CurrentItem == item)
        {
            GetComponent<GameManager>().CorrectItem = true;
        }
        else
        {
            GetComponent<GameManager>().CorrectItem = false;
        }

        for (int i = 0; i < backPackBox.transform.childCount - 1; i++)
        {
            backPackBox.transform.GetChild(i).transform.GetChild(0).gameObject.SetActive(false);
        }

        backPackBox.transform.GetChild(item).transform.GetChild(0).gameObject.SetActive(true);

    }
    public void CloseBackpack()
    {
        soundManager.UISound(buttonClick);
        backPackBox.SetActive(false);
        GetComponent<GameManager>().Play(false);
    }

    public void OpenAchievements()
    {
        soundManager.UISound(buttonClick);
        achievements.SetActive(true);

        for (int i = 0; i < GetComponent<GameManager>().CompletedAchievementIndex.Count; i++)
        {
            int index = GetComponent<GameManager>().CompletedAchievementIndex[i];
            achievements.transform.GetChild(index).GetChild(1).gameObject.SetActive(true);
        }

    }
    public void CloseAchievements()
    {
        soundManager.UISound(buttonClick);
        achievements.SetActive(false);
    }

    //Blir kallad på från XmlManager:
    public void ViewDialogue(string dialogue, bool trigger)
    {
        if (trigger)
        {
            nextMessageButton.SetActive(false);
        }
        else
        {
            nextMessageButton.SetActive(true);
        }
        dialogueText = dialogueBox.GetComponentInChildren<Text>();
        dialogueBox.SetActive(true);
        print(dialogue);
        dialogueText.text = dialogue;

        if (dialogue == "finished")
        {
            xmlManager.DialogueFinished = true;
            dialogueBox.SetActive(false);
            gameManager.Play(true);
        }
        else if (dialogue == "")
        {
            dialogueBox.SetActive(false);
        }
        else
        {
            messageLogContent.text = messageLogContent.text + " " + dialogue;
        }
    }

    public void Play()
    {
        Cursor.visible = false;
        soundManager.UISound(buttonClick);
        dialogueBox.SetActive(false);
    }
    public void Dialogue()
    {
        soundManager.UISound(buttonClick);
        xmlManager.Dialogue();
    }
    public void AchievementCompleted(int index)
    {
        infoBoxOpen = true;
        achievementInfoBox.SetActive(true);
        achievementInfoBox.transform.GetChild(index).gameObject.SetActive(true);

    }
    public void CloseInfoBox()
    {
        infoBoxOpen = false;
        soundManager.UISound(buttonClick);
        for (int i = 0; i < achievementInfoBox.transform.childCount - 1; i++) // -1 för att alltid behålla kryssrutan aktiv.
        {
            achievementInfoBox.transform.GetChild(i).gameObject.SetActive(false);
        }
        achievementInfoBox.SetActive(false);
        GetComponent<GameManager>().Play(true);
    }
    public void GameOver(int achievements, int timeToFinish)
    {
        achievementsCompleted.text = "Tack för deltagandet! Du klarade " + achievements + " uppgifter på " + timeToFinish + " sekunder! BRA JOBBAT!";
        endScreen.SetActive(true);
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MenyScene");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
               achievementInfoBox;
    Text dialogueText, achievementsCompleted;

    [SerializeField]
    List<Sprite> itemImages;
    [SerializeField]
    AudioClip buttonClick;
    List<GameObject> achievementList;

    public bool newItem;

    ItemsManager itemManager;
    PlayerBehaviour playerBehaviour;
    XmlManager xmlManager;
    SoundManager soundManager;

    void Start()
    {
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
        if (newItem)
        {
            highlightBackPack.SetActive(true);
        }
        else
        {
            highlightBackPack.SetActive(false);
        }
    }

    public void OpenBackpack()
    {
        soundManager.UISound(buttonClick);
        backPackBox.SetActive(true);

        for (int i = 0; i <= itemManager.items.Count; i++)
        {
            itemManager.GetItem(i, false);
        }
    }

    //Blir kallad på från ItemsManager OM det är ett nytt item i backpack.
    public void InstantianteItem(int index, string name)
    {
        Transform itemParent = backPackBox.transform.GetChild(index - 1);
        GameObject item = Instantiate(itemPrefab, itemParent);
        item.transform.parent = itemParent;
        item.GetComponentInChildren<Image>().sprite = itemImages[index - 1];
        item.name = index.ToString();
        newItem = true;
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
    public void ViewDialogue(string dialogue)
    {

        dialogueText = dialogueBox.GetComponentInChildren<Text>();
        dialogueBox.SetActive(true);

        dialogueText.text = dialogue;

        if (dialogue == "finished")
        {
            xmlManager.DialogueFinished = true;
            dialogueBox.SetActive(false);
        }
        else if (dialogue == "")
        {
            dialogueBox.SetActive(false);
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
        achievementInfoBox.SetActive(true);
        achievementInfoBox.transform.GetChild(index).gameObject.SetActive(true);

    }
    public void CloseInfoBox()
    {
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
}

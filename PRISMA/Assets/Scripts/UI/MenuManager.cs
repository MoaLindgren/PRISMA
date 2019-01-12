using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    GameObject backPackBox, dialogueBox, playDialogueBox, itemPrefab, backPackButton, score, timer, miniGame1UI, player, highlightBackPack;
    public GameObject currentStation;
    Text dialogueText, scoreText;
    public Text timerText; // Ändra så den visar heltal och inte floats.
    ItemsManager itemManager;
    PlayerBehaviour playerBehaviour;
    XmlManager xmlManager;
    MonoBehaviour script;
    public bool newItem;
    testGameManager testGame;
    [SerializeField]
    List<Sprite> itemImages;

    void Start()
    {
        playerBehaviour = player.GetComponent<PlayerBehaviour>();
        itemManager = GetComponent<ItemsManager>();
        xmlManager = GetComponent<XmlManager>();
        timerText = timer.GetComponent<Text>();
        scoreText = score.GetComponent<Text>();
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
        backPackBox.SetActive(false);
    }

    //Blir kallad på från XmlManager:
    public void ViewDialogue(string dialogue, bool startGame)
    {

        if (!startGame)
        {
            dialogueText = dialogueBox.GetComponentInChildren<Text>();
            dialogueBox.SetActive(true);

            dialogueText.text = dialogue;

            if (dialogue == "finished")
            {
                dialogueBox.SetActive(false);
                playerBehaviour.moveable = true;
            }
            else if (dialogue == "")
            {
                dialogueBox.SetActive(false);
            }
        }
        else
        {
            dialogueText = playDialogueBox.GetComponentInChildren<Text>();
            playDialogueBox.SetActive(true);
            dialogueText.text = dialogue;
        }
        
    }
    public void SetScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void MiniGame1(bool toggle)
    {
        miniGame1UI.SetActive(toggle);
    }

    public void Play()
    {
        playDialogueBox.SetActive(false);
        testGame = currentStation.GetComponent<testGameManager>();
        testGame.StartGame();
    }
    public void Dialogue()
    {
        xmlManager.Dialogue(false, true);
    }

}

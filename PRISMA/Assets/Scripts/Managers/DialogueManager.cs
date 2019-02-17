using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    string myName;
    string fullName, itemName;
    [SerializeField]
    int index;
    [SerializeField]
    bool trigger, instant;
    bool entered;
    GameObject manager;
    GameManager gameManager;
    XmlManager xmlManager;
    SoundManager soundManager;
    MenuManager menuManager;
    string gameVersion;

    void Start()
    {
        //SÄTT DENNA FRÅN HUVUDMENYN:
        gameVersion = "Game1";
        entered = true;
        manager = GameObject.Find("GameManager");
        xmlManager = manager.GetComponent<XmlManager>();
        gameManager = manager.GetComponent<GameManager>();
        soundManager = manager.GetComponent<SoundManager>();
        menuManager = manager.GetComponent<MenuManager>();
        fullName = myName + index.ToString();
    }

    void OnTriggerEnter()
    {
        if (entered)
        {
            switch (myName)
            {
                case "Station":
                    if (index == 0)
                    {
                        gameManager.GameStarted = true;
                    }
                    menuManager.NewItem = true;
                    gameManager.Station(index);
                    xmlManager.SendToSetUp(trigger, fullName, index, gameVersion);
                    GetComponent<Collider>().enabled = false;
                    return;
                case "Achievement":
                    if (instant)
                    {
                        soundManager.TriggerSound(true);
                        GameObject halo = transform.GetChild(0).gameObject;
                        gameManager.Achievement(index, halo);
                        GetComponent<Collider>().enabled = false;
                    }
                    return;
                case "Trigger":
                    xmlManager.SendToSetUp(trigger, fullName, index, gameVersion);
                    GetComponent<Collider>().enabled = false;

                    //Om man möter varg i game1:
                    if (index == 2 && gameVersion == "Game1")
                    {
                        soundManager.TriggerSound(false);
                    }
                    return;
            }

            entered = false;
        }
    }
}

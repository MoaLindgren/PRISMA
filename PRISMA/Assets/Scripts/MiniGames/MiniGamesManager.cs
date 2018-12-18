using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGamesManager : MonoBehaviour
{
    [SerializeField]
    GameObject player, gameManager;
    int stationIndex;

    MiniGame1 miniGame1;
    MiniGame2 miniGame2;
    XmlManager xmlManager;
    ItemsManager itemManager;
    PlayerBehaviour playerBehaviour;

    void Start()
    {
        playerBehaviour = player.GetComponent<PlayerBehaviour>();

        itemManager = gameManager.GetComponent<ItemsManager>();
        xmlManager = gameManager.GetComponent<XmlManager>();
        miniGame1 = gameObject.GetComponent<MiniGame1>();
        miniGame2 = gameObject.GetComponent<MiniGame2>();
    }
    void MiniGame()
    {
        switch (stationIndex)
        {

            case 0:
                xmlManager.SetUpXML(stationIndex);
                break;
            //Minigame 1 (Klicka på fåglar):
            case 1:
                miniGame1.enabled = true;
                xmlManager.SetUpXML(stationIndex);
                break;
            //Minigame 2 (Ta bort ogräs):
            case 2:
                miniGame2.enabled = true;
                xmlManager.SetUpXML(stationIndex);
                break;
        }


    }

    //public void GameOver()
    //{
    //    switch (stationIndex)
    //    {
    //        case 1:
    //            miniGame1.enabled = false;
    //            playerBehaviour.moveable = true;
    //            xmlManager.Dialogue(false);
    //            break;
    //    }

    //}
}

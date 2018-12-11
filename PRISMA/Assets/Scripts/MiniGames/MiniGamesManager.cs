﻿using System.Collections;
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

    void Start()
    {
        itemManager = gameManager.GetComponent<ItemsManager>();
        xmlManager = gameManager.GetComponent<XmlManager>();
        miniGame1 = gameObject.GetComponent<MiniGame1>();
        miniGame2 = gameObject.GetComponent<MiniGame2>();
    }
    void OnTriggerEnter()
    {
        player.GetComponent<PlayerMovement>().moveable = false; //När vi klarat minigame, sätt till true;

        string station = this.gameObject.tag;
        stationIndex = int.Parse(station);


        MiniGame();
    }
    void MiniGame()
    {
        switch (stationIndex)
        {
            //Minigame 1 (Klicka på fåglar):
            case 1:
                miniGame1.enabled = true;
                xmlManager.SetUpXML(stationIndex);
                //Minigame 1 startar
                break;
            case 2:
                miniGame2.enabled = true;
                break;
        }



        //RUNDA 1, klicka på fåglar: 

        //  starta instruktioner

        //  trigga ett nytt item i ryggsäcken
        //  Funktion för att kunna välja just det itemet.

        //  Fåglarna flyttar sig/blinkar/försvinner etc. i random ordning
        //  De behöver en destination

        //  Ha en grej equippat, går ej att klicka på fåglar annars

        //  Kunna klicka på objekt -> förstörs

        //  En unik och random timer på varje objekt

        //  Klick-counter

        //  Timer på hela minigamet

        //  finished

        //  trigga en slut-instruktion
    }
}

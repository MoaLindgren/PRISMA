using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    int stationIndex;

    void OnTriggerEnter()
    {
        player.GetComponent<PlayerMovement>().moveable = false; //När vi klarat minigame, sätt till true;

        string station = this.gameObject.tag;
        stationIndex = int.Parse(station);

        MiniGame();
    }

    void MiniGame()
    {
        switch(stationIndex)
        {
            //Minigame 1 (Klicka på fåglar):
            case 1:
                //Minigame 1 startar
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    void OnTriggerEnter()
    {
        player.GetComponent<PlayerMovement>().moveable = false; //När vi klarat minigame, sätt till true;

        //trigga rätt minigame, för rätt runda vi är på just nu.

        string station = this.gameObject.tag;

        MiniGame(station);
    }

    void MiniGame(string station)
    {

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

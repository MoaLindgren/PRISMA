using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdHouse : MonoBehaviour
{
    [SerializeField]
    GameObject birdHouse, achievement;
    GameManager gameManager;
    Transform birdHouseLocation;
    int station;
    bool hasBirdHouse, correctItem;

    void Start()
    {
        correctItem = false;
        hasBirdHouse = false;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void OnMouseDown()
    {
        station = gameManager.StationIndex;
        correctItem = gameManager.CorrectItem;
        if(station == 1 && correctItem)
        {
            if (hasBirdHouse == false)
            {
                Instantiate(birdHouse, gameObject.transform);
                hasBirdHouse = true;
                gameManager.Achievement(station, achievement);
            }
        }
    }
}

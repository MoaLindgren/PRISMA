using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdHouse : MonoBehaviour {


    [SerializeField]
    GameObject birdHouse;

    Transform birdHouseLocation;

    bool hasBirdHouse;

    void Start()
    {
        hasBirdHouse = false;
        birdHouseLocation.position = gameObject.transform.position;
    }

    void OnMouseDown()
    {
        //om du har rätt item klickan

        //Lås upp rätt achievemnt + starta texten

        if(hasBirdHouse == false)
        {
            Instantiate(birdHouse, gameObject.transform);
            hasBirdHouse = true;
        }
        
    }
}

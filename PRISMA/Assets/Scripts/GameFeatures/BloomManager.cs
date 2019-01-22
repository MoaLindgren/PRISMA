using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloomManager : MonoBehaviour
{
    Bloom bloom;


    GameObject[] bloomLocations;

    GameObject blom, player, gameManager;


    // Start is called before the first frame update
    void Start()
    {
        bloomLocations = GameObject.FindGameObjectsWithTag("BloomLocation");
        player = GameObject.FindGameObjectWithTag("player");
        gameManager = GameObject.Find("GameManager");


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Activate()
    {
        //aktivera / inaktivera alla blommor 

        foreach (GameObject blom in bloomLocations)
        {
            bloom.GetComponent<Bloom>(); //behöver fixa så den disablas här
        }
    }
}

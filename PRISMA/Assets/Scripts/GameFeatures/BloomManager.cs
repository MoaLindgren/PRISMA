using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloomManager : MonoBehaviour {

    Bloom bloom;
    PlayerBehaviour playerBehaviour;
    GameObject player, gameManager, bloomLocation;
    GameObject[] bloomLocations;

    void Start ()
    {
        bloomLocations = GameObject.FindGameObjectsWithTag("BloomLocation");
        player = GameObject.FindGameObjectWithTag("player");
        playerBehaviour = player.GetComponent<PlayerBehaviour>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		//om spelaren går in i område x sätt på alla blommor i det området
	}
}

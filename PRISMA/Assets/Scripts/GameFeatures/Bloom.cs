using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloom : MonoBehaviour
{
    BloomManager bloomManager;

    [SerializeField]
    float minTime, maxTime;


    [SerializeField]
    float growTimerStart;
    float growTimer, rndTime;

    bool canGrow;

    public GameObject myLocation;

    GameObject flower, weed;


    void Start()
    {
        RandomizeValue();
        rndTime = growTimer;
    }

   
    void Update()
    {
        growTimer -= Time.deltaTime;
        if (growTimer < 0 && canGrow == true)
        {
            GrowWeed();
        }

        else if(growTimer < 0 && canGrow == false)
        {
            GrowFlower();
        }

    }

    void RandomizeValue()//Slumpa ett värde för hur ofta plantorna ska växa
    {
       rndTime = Random.Range(minTime, maxTime);
        
    }

    void GrowWeed ()
    {
        //instantiera ett weed
        canGrow = false;
        //ta bort blomman om den finns där
    }

    void GrowFlower ()
    {
        //instantiera en blomma
    }
}

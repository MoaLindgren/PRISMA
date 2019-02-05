using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloom : MonoBehaviour
{


    [SerializeField]
    float minTime, maxTime, growTimer, growTimerStart, rndTime;

    [SerializeField]
    int weedLevel, rndBloomPercent;

    [SerializeField]
    GameObject flower, weed;
    GameObject currentBloom, currentWeed;

    BloomManager bloomManager;

    [SerializeField]
    bool canGrow, hasFlower, spawnFlower, hasWeed;

    Transform myLocation;




    
    void Start()
    {
        hasFlower = false;
        CanGrow();
        myLocation = gameObject.transform;


    }

    
    void Update()
    {
        if (canGrow == true)
        {
            growTimer -= Time.deltaTime;

            if (growTimer < 0)
            {
                RndBloom();

                if (!spawnFlower && !hasWeed)
                {
                    GrowWeed();
                    RandomizeValue();
                    growTimer = growTimerStart;
                    
                }

                else if (!hasFlower && spawnFlower)
                {
                    GrowFlower();
                    RandomizeValue();
                    growTimer = growTimerStart;
                }
            }
        }

        else if (canGrow == false && hasFlower == true)
        {
            
            growTimer -= Time.deltaTime;
            if (growTimer < 0)
            {
                RandomizeValue();
                growTimer = growTimerStart;
                weedLevel++;
                if (weedLevel == 2)
                    eatPlant();
            }
                
        }
        

    }

    void GrowWeed()//här skapas det ogräs
    {
        currentWeed = Instantiate(weed, myLocation);
        hasWeed = true;

        canGrow = false;
    }

    void GrowFlower()//här skapas det blommor
    {

        currentBloom = Instantiate(flower, myLocation);

        hasFlower = true;
    }

    void RandomizeValue()//Slumpa ett värde för hur länge till en ny planta växer
    {
        rndTime = Random.Range(minTime, maxTime);
        growTimerStart = rndTime;
    }

    void RndBloom()
    {
        int rndBloom = Random.Range(0, 10);
        if (rndBloom <= rndBloomPercent)
        {
            spawnFlower = false;
        }
        else if (rndBloom >= (rndBloomPercent + 1))
        {
            spawnFlower = true;
        }
    }

    private void OnMouseDown()
    {
        print("träffar collidern");
        print(currentWeed);
        //om spelaren har ogräsitem och det är ogräs: ta bort ogräs
        if (hasFlower && canGrow)
        {
            RemoveWeed();
            print("övre");
            CanGrow();
        }
        if (hasFlower && !canGrow)
        {
            if(currentWeed != null)
            {
                RemoveWeed();
                print("udnre");
                CanGrow();
            }
        }
    }

    void eatPlant()
    {
        Destroy(currentBloom);
        hasFlower = false;
    }

    public void RemoveWeed()
    {
        //fixa så att det kollar om det är tomt eller inte, och vad det är för object
        Destroy(currentWeed);
        hasWeed = false;
        //Destroy(currentBloom);

    }
    public void CanGrow()
    {
        canGrow = true;
        RandomizeValue();
        growTimerStart = growTimer;
        weedLevel = 0;
    }
}

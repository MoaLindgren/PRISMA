using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloom : MonoBehaviour
{
    [SerializeField]
    float minTime, maxTime, growTimer, growTimerStart, rndTime;

    [SerializeField]
    int weedLevel, rndBloomPercent;
    int countWeed, achievementIndex;

    [SerializeField]
    GameObject flower, weed;
    GameObject currentBloom, currentWeed;

    BloomManager bloomManager;

    [SerializeField]
    bool  hasFlower, spawnFlower, hasWeed;

    public bool spring, canGrow;

    Transform myLocation;

    void Start()
    {
        countWeed = 0;
        canGrow = true;
        myLocation = gameObject.transform;
        RandomizeTime();
        spring = true;
    }

    void Update()
    {
        if (spring == false)
        {
            RemoveWeed();
            canGrow = false;
        }
        else
        {
            if (canGrow == true)
            {
                growTimer -= Time.deltaTime;

                if (growTimer <= 0)
                {
                    if (hasFlower == false)
                    {
                        GrowFlower();
                    }
                    else if (currentWeed == null)
                    {
                        GrowWeed();
                    }
                }
            }
            else if (canGrow == false && hasFlower == true)
            {
                growTimer -= Time.deltaTime;
                if (growTimer <= 0)
                {
                    if (weedLevel == 5)
                    {
                        EatPlant();
                    }
                    else
                    {
                        weedLevel++;
                        RandomizeTime();
                        growTimer = growTimerStart;
                    }
                }
            }

        }

    }

    void RandomizeTime()
    {
        rndTime = Random.Range(minTime, maxTime);
        growTimerStart = rndTime;
        growTimer = growTimerStart;
    }

    void GrowWeed()
    {
        currentWeed = Instantiate(weed, myLocation);
        canGrow = false;
        RandomizeTime();
        
    }

    void GrowFlower() 
    {
        currentBloom = Instantiate(flower, myLocation);
        hasFlower = true;
        RandomizeTime();
        
    }

    public void EatPlant()//ät upp blomman som vi har på platsen
    {
        Destroy(currentBloom);
        RandomizeTime();
        hasFlower = false;
    }

    void OnMouseDown()//Om vi har ogräs på platsen tar vi bort det
    {
        if(currentWeed != null)
        {
            countWeed++;
            if(countWeed == 1)
            {

            }
            RemoveWeed();
        }
    }

    public void RemoveWeed()
    {
        Destroy(currentWeed);
        canGrow = true;
        weedLevel = 0;
        
    }

    public void SwitchSeason()
    {
        
    }










    //void Start()
    //{
    //    hasFlower = false;
    //    CanGrow();
    //    myLocation = gameObject.transform;


    //}


    //void Update()
    //{
    //    if (canGrow == true)
    //    {
    //        growTimer -= Time.deltaTime;

    //        if (growTimer < 0)
    //        {
    //            RndBloom();

    //            if (!spawnFlower && !hasWeed)
    //            {
    //                GrowWeed();
    //                RandomizeValue();
    //                growTimer = growTimerStart;

    //            }

    //            else if (!hasFlower && spawnFlower)
    //            {
    //                GrowFlower();
    //                RandomizeValue();
    //                growTimer = growTimerStart;
    //            }
    //        }
    //    }

    //    else if (canGrow == false && hasFlower == true)
    //    {

    //        growTimer -= Time.deltaTime;
    //        if (growTimer < 0)
    //        {
    //            RandomizeValue();
    //            growTimer = growTimerStart;
    //            weedLevel++;
    //            if (weedLevel == 2)
    //                eatPlant();
    //        }

    //    }


    //}

    //void GrowWeed()//här skapas det ogräs
    //{
    //    canGrow = false;
    //    currentWeed = Instantiate(weed, myLocation);
    //    hasWeed = true;


    //}

    //void GrowFlower()//här skapas det blommor
    //{

    //    currentBloom = Instantiate(flower, myLocation);

    //    hasFlower = true;
    //}

    //void RandomizeValue()//Slumpa ett värde för hur länge till en ny planta växer
    //{
    //    rndTime = Random.Range(minTime, maxTime);
    //    growTimerStart = rndTime;
    //}

    //void RndBloom()
    //{
    //    int rndBloom = Random.Range(0, 10);
    //    if (rndBloom <= rndBloomPercent)
    //    {
    //        spawnFlower = false;
    //    }
    //    else if (rndBloom >= (rndBloomPercent + 1))
    //    {
    //        spawnFlower = true;
    //    }
    //}

    //private void OnMouseDown()
    //{

    //    if (currentWeed != null)
    //    {
    //        RemoveWeed();
    //        CanGrow();
    //    }

    //}

    //void eatPlant()
    //{
    //    Destroy(currentBloom);
    //    hasFlower = false;
    //}

    //public void RemoveWeed()
    //{
    //    //fixa så att det kollar om det är tomt eller inte, och vad det är för object
    //    Destroy(currentWeed);
    //    hasWeed = false;
    //    //Destroy(currentBloom);

    //}
    //public void CanGrow()
    //{
    //    canGrow = true;
    //    RandomizeValue();
    //    growTimerStart = growTimer;
    //    weedLevel = 0;
    //}
}

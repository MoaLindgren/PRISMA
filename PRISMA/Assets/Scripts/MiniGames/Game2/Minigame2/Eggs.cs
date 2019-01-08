using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eggs : MonoBehaviour {

    [SerializeField]
    float minTime, maxTime;

    [SerializeField]
    int eggLevel;
    [SerializeField]
    float growTimer, growTimerStart;

    //public GameObject myLocation;

    EggCare eggCare;

    void Start()//Slumpa ett värde i början följt av att sätta alla andra värden
    {
        eggCare = GameObject.Find("Station 2").GetComponent<EggCare>();
    }
    void Update()//Ticka ner tiden det tar för plantor att växa
    {
        growTimer -= Time.deltaTime;
        if (growTimer < 0)
            GrowWeed();
    }

    public void StartGame()
    {
        RandomizeValue();
        growTimer = growTimerStart;
        eggLevel = 0;
    }

    void GrowWeed()
    {
        growTimer = growTimerStart;
        eggLevel++;
        IncreaseSize();
        EatPlant();
        RandomizeValue();
    }

    void RandomizeValue()//Slumpa ett värde för hur ofta plantorna ska växa
    {
        float rndTime = Random.Range(minTime, maxTime);
        growTimerStart = rndTime;
    }

    private void OnMouseDown()//När spelaren klickar på ogräset så förstörs det
    {

        eggLevel = 0;

    }

    void EatPlant()
    {
        if (eggLevel == 8)
        {

            eggCare.DeadFlower();
            print("nu dog ett ägg");
        }
    }

    void IncreaseSize()//Här ska vi ha visuel feedback som visar på att ägget blir kallare
    {
        if (eggLevel == 2)

        {
            eggCare.LevelFlower(2);
        }

        if (eggLevel == 3)
        {
            eggCare.LevelFlower(3);
        }
    }
}
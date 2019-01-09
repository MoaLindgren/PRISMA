using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eggs : MonoBehaviour
{

    [SerializeField]
    float minTime, maxTime;

    [SerializeField]
    int eggLevel;
    [SerializeField]
    float growTimer;
    float growTimerStart;

    float rndTime;

    public bool onEgg;

    //public GameObject myLocation;

    EggCare eggCare;

    void Start()//Slumpa ett värde i början följt av att sätta alla andra värden
    {
        RandomizeValue();
        growTimer = growTimerStart;
        onEgg = false;
        eggCare = GameObject.Find("Station 2").GetComponent<EggCare>();
        GetComponent<SphereCollider>().enabled = true;
    }
    void Update()//Ticka ner tiden det tar för plantor att växa
    {
        if (!onEgg)
        {
            growTimer -= Time.deltaTime;
            if (growTimer < 0)
                GrowWeed();
        }

    }

    void GrowWeed()
    {
        growTimer = growTimerStart;
        eggLevel++;
        IncreaseSize();
        RandomizeValue();
    }

    void RandomizeValue()//Slumpa ett värde för hur ofta plantorna ska växa
    {
        rndTime = Random.Range(minTime, maxTime);
        growTimerStart = rndTime;
    }

    private void OnMouseDown()//När spelaren klickar på ogräset så förstörs det
    {

        eggLevel = 1;
        eggCare.SwitchPlaces();
        onEgg = true;
        RandomizeValue();
        IncreaseSize();
        growTimerStart = rndTime;
    }

    void IncreaseSize()//Här ska vi ha visuel feedback som visar på att ägget blir kallare
    {
        eggCare.Upgrade(eggLevel, gameObject.transform.position, gameObject);
    }
}
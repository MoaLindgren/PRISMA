using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeedManager : MonoBehaviour {

    [SerializeField]
    float minTime, maxTime;

    [SerializeField]
    int weedLevel;
    float growTimer;
    float growTimerStart;

    MiniGame2 miniGame2;

    void Start ()//Slumpa ett värde i början följt av att sätta alla andra värden
    {
        miniGame2 = GameObject.Find("Station 2").GetComponent<MiniGame2>();
	}
	void Update ()//Ticka ner tiden det tar för plantor att växa
    {
        growTimer -= Time.deltaTime;
        if (growTimer < 0)
            GrowWeed();
    }

    public void StartGame ()
    {
        RandomizeValue();
        growTimer = growTimerStart;
        weedLevel = 0;
    }

    void GrowWeed ()
    {
        growTimer = growTimerStart;
        weedLevel++;
        //IncreaseSize();
        EatPlant();
        RandomizeValue();
    }

    void RandomizeValue()//Slumpa ett värde för hur ofta plantorna ska växa
    {
        float rndTime = Random.Range(minTime,maxTime);
        growTimerStart = rndTime;
    }

    private void OnMouseDown()//När spelaren klickar på ogräset så förstörs det
    {
        //print("bort med ogräs");
        Destroy(this.gameObject);
    }

    void EatPlant ()
    {
        if (weedLevel == 5f)
        {
            
            miniGame2.DeadFlower();
            print(miniGame2.deadFlowers);
            Destroy(this.gameObject);
            //Ät upp plantan som den är på också
        } 
    }

    void IncreaseSize()//Här ska vi ha visuel feedback som visar på att plantan växer
    {
        
    }
}

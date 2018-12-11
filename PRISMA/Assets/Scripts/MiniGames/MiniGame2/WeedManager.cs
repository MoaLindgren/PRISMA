using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeedManager : MonoBehaviour {

    // Use this for initialization
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
        //print(growTimerStart);
        IncreaseSize();
        //print(miniGame2.counter);
        EatPlant();
        //Kolla om spelaren förlorat
        RandomizeValue();
    }

    void RandomizeValue()//Slumpa ett värde för hur ofta plantorna ska växa
    {
        float rndTime = Random.Range(2,5);
        growTimerStart = rndTime;
    }

    private void OnMouseDown()//När spelaren klickar på ogräset så förstörs det
    {
        print("bort med ogräs");
        Destroy(this.gameObject);
    }

    void EatPlant ()
    {
        if (weedLevel == 5f)
        {
            print(weedLevel + " " + "you lost this plant");
            miniGame2.DeadFlower();
            Destroy(this.gameObject);
            //Ät upp plantan som den är på också
        } 
    }

    void IncreaseSize()//Här ska vi ha visuel feedback som visar på att plantan växer
    {
        
    }
}

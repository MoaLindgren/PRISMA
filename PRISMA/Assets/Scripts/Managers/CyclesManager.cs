using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CyclesManager : MonoBehaviour
{
    [SerializeField]
    Texture snowTexture, defaultTexture;
    [SerializeField]
    GameObject snow;
    Renderer rend;
    [SerializeField]
    Slider yearSlider;
    [SerializeField]
    GameObject[] trees;
    GameObject[] flowers;
    GameObject[] removeableObjects;
    [SerializeField]
    List<Material> skyboxes;
    Material currentSkybox;
    [SerializeField]
    int numberOfDays, yearTime;
    int counter, daysCounter, seasonCounter, daysPerSeason, yearCounter, daysSpring, daysSummer, daysAutumn, daysWinter;
    [SerializeField]
    float dayCycleTimer;
    float timer, dayCycleCounter, shortSeason, longSeason, springDays, summerDays, autumnDays, winterDays, morningEveningTime, dayNightTime;
    bool dayNight, ready;

    List<string> dayCycle = new List<string>() { "Morning", "Day", "Evening", "Night" };
    List<int> firstDays;
    string currentDay;

    SoundManager soundManager;
    Bloom bloom;

    void Start()
    {
        firstDays = new List<int>() { daysSpring, daysSummer, daysAutumn, daysWinter };
        for (int i = 0; i < firstDays.Count; i++)
        {
            firstDays[i] = 0;
        }
        soundManager = GameObject.Find("GameManager").GetComponent<SoundManager>();
        trees = GameObject.FindGameObjectsWithTag("Tree");
        flowers = GameObject.FindGameObjectsWithTag("BloomLocation");
        removeableObjects = GameObject.FindGameObjectsWithTag("SeasonRemove");

        ready = false;
        counter = 0;

        ChangeSeason("spring");
        DaysCalculation();
        SeasonCalculation();


        
    }
    void DaysCalculation()
    {
        float daysPerMinute = numberOfDays / yearTime;
        dayCycleTimer = 60 / daysPerMinute;
        morningEveningTime = dayCycleTimer / 10;
        dayNightTime = (dayCycleTimer - (morningEveningTime * 2)) / 2;

        dayNight = true;
        dayCycleCounter = timer;
        ready = true;

        yearSlider.maxValue = numberOfDays;
    }
    void SeasonCalculation()
    {
        shortSeason = numberOfDays / 5;
        longSeason = (numberOfDays - (shortSeason * 2)) / 2;

        springDays = shortSeason;
        summerDays = springDays + longSeason;
        autumnDays = summerDays + shortSeason;
        winterDays = autumnDays + longSeason;
    }

    void Update()
    {
        if (ready)
        {
            DayCycle();
        }
    }

    void DayCycle()
    {
        if (dayNight)
        {
            timer = dayNightTime;
        }
        else
        {
            timer = morningEveningTime;
        }

        dayCycleCounter -= Time.deltaTime;
        if (dayCycleCounter <= 0)
        {
            if (counter < skyboxes.Count - 1)
            {
                counter++;
            }
            else
            {
                daysCounter++;
                yearSlider.value = daysCounter;
                counter = 0;
                if (daysCounter <= springDays)
                {

                    if(daysSpring == 0)
                    {
                        ChangeSeason("spring");
                        daysSpring++;
                    }
                }
                else if (daysCounter <= summerDays)
                {
                    if(daysSummer == 0)
                    {
                        ChangeSeason("summer");
                        daysSummer++;
                    }
                }
                else if (daysCounter <= autumnDays)
                {
                    if(daysAutumn == 0)
                    {
                        ChangeSeason("autumn");
                        daysAutumn++;
                    }
                }
                else if (daysCounter <= winterDays)
                {
                    if(daysWinter == 0)
                    {
                        ChangeSeason("winter");
                        daysWinter++;
                    }
                }
                if (daysCounter >= winterDays + longSeason)
                {
                    daysCounter = 0;
                    daysSpring = 0;
                    daysSummer = 0;
                    daysAutumn = 0;
                    daysWinter = 0;
                    //for(int i = 0; i < firstDays.Count; i++)
                    //{
                    //    firstDays[i] = 0;
                    //}
                    //yearSlider.value = daysCounter;
                }
            }
            currentDay = dayCycle[counter];
            soundManager.PlaySound(currentDay);
            dayNight = !dayNight;
            dayCycleCounter = timer;

        }
        GetComponent<Skybox>().material = skyboxes[counter];
    }

    void ChangeSeason(string currentSeason)
    {
        switch (currentSeason)
        {
            case "spring":
                foreach (GameObject tree in trees)
                {
                    rend = tree.GetComponent<Renderer>();
                    rend.materials[1].mainTexture = defaultTexture;
                    rend.materials[1].color = new Color32(209, 255, 0, 255);
                    snow.SetActive(false);

                }
                foreach (GameObject flower in flowers)
                {
                    flower.GetComponent<Bloom>().spring = true;
                    flower.GetComponent<Bloom>().canGrow = true;
                }
                foreach (GameObject removeableObject in removeableObjects)
                {
                    removeableObject.SetActive(true);
                }
                return;

            case "summer":
                foreach (GameObject tree in trees)
                {
                    rend = tree.GetComponent<Renderer>();
                    rend.materials[1].mainTexture = defaultTexture;
                    rend.materials[1].color = new Color32(56, 150, 26, 255);
                }
                return;

            case "autumn":
                foreach (GameObject tree in trees)
                {
                    rend = tree.GetComponent<Renderer>();
                    rend.materials[1].mainTexture = defaultTexture;
                    rend.materials[1].color = new Color32(240, 124, 0, 255);
                }
                return;

            case "winter":
                foreach (GameObject tree in trees)
                {
                    rend = tree.GetComponent<Renderer>();
                    rend.materials[1].mainTexture = snowTexture;
                    rend.materials[1].color = new Color32(255, 255, 255, 255);
                    snow.SetActive(true);
                }
                foreach (GameObject blomma in flowers)
                {
                    blomma.GetComponent<Bloom>().EatPlant();
                    blomma.GetComponent<Bloom>().spring = false;
                }
                foreach (GameObject removeableObject in removeableObjects)
                {
                    removeableObject.SetActive(false);
                }
                return;
        }

    }

}

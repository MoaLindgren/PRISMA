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
    GameObject gameManager;
    Renderer rend;
    [SerializeField]
    Slider yearSlider;
    [SerializeField]
    GameObject[] trees;
    [SerializeField]
    List<Material> skyboxes;
    Material currentSkybox;
    [SerializeField]
    int numberOfDays, gameTime;
    int counter, daysCounter, seasonCounter, daysPerSeason;
    [SerializeField]
    float dayCycleTimer;
    float timer, dayCycleCounter, shortSeason, longSeason, springDays, summerDays, autumnDays, winterDays;
    float morningEveningTime, dayNightTime;
    bool dayNight, ready;

    List<string> dayCycle = new List<string>() { "Morning", "Day", "Evening", "Night" };
    string currentDay;

    SoundManager soundManager;

    /*
    Jag behöver fixa så att morgon och kväll har kortare tid än dag och natt.
    Just nu så startar den dessutom på dag, varför??

    Andra saker som behövs:
        Ändra markens färg med årstiderna.
        Lägga in ljud (beroende på årstiderna).
        Rensa importerade assets.
        Justera om i XML
        Sätta restrictions på vart spelaren får gå, och fixa så spelaren INTE ramlar vid kollision
        Att spelet ska ta slut när alla dagar har gått
        En achievement-logg
        En manager för allt som ske, och vad de beror på. Exempel på några sådana:
            - Ogräs ska spawna hela tiden, utom på vintern. Då stannar all växtlighet.
            - Fåglar ska flyga runt under hela året, men allra mest på våren och sommaren
            - Fjärilar finns bara på soliga vår/sommar-dagar
            - Riddarskinnbaggen hittar man bara om man planterat tulkört
            - Blåsipporna finns bara på våren
    */
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        soundManager = gameManager.GetComponent<SoundManager>();
        ready = false;
        trees = GameObject.FindGameObjectsWithTag("Tree");
        counter = 0;
        DaysCalculation();
        SeasonCalculation();
    }
    void DaysCalculation()
    {
        float daysPerMinute = numberOfDays / gameTime;
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
            YearCycle();
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
                yearSlider.value++;
                counter = 0;
            }
            currentDay = dayCycle[counter];
            soundManager.PlaySound(currentDay);
            dayNight = !dayNight;
            dayCycleCounter = timer;

        }
        GetComponent<Skybox>().material = skyboxes[counter];
    }

    void YearCycle()
    {
        if (daysCounter <= springDays)
        {
            foreach (GameObject tree in trees)
            {
                rend = tree.GetComponent<Renderer>();
                rend.materials[1].mainTexture = defaultTexture;
                rend.materials[1].color = new Color32(209, 255, 0, 255);
                snow.SetActive(false);
            }
        }
        else if (daysCounter <= summerDays)
        {
            foreach (GameObject tree in trees)
            {
                rend = tree.GetComponent<Renderer>();
                rend.materials[1].mainTexture = defaultTexture;
                rend.materials[1].color = new Color32(56, 150, 26, 255);
            }
        }
        else if (daysCounter <= autumnDays)
        {
            foreach (GameObject tree in trees)
            {
                rend = tree.GetComponent<Renderer>();
                rend.materials[1].mainTexture = defaultTexture;
                rend.materials[1].color = new Color32(240, 124, 0, 255);

            }
        }
        else if (daysCounter <= winterDays)
        {
            foreach (GameObject tree in trees)
            {
                rend = tree.GetComponent<Renderer>();
                rend.materials[1].mainTexture = snowTexture;
                rend.materials[1].color = new Color32(255, 255, 255, 255);
                snow.SetActive(true);
            }
        }
    }

}

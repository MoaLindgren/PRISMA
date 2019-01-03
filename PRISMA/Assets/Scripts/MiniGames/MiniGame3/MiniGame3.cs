using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGame3 : MonoBehaviour
{
    [SerializeField]
    GameObject tulkortPrefab, plane;
    [SerializeField]
    float clickTimer, max;
    float clickTimerCounter, beatleTimerCounter, rndTimer;
    Vector3 clickPosition;
    bool gameStart;
    [SerializeField]
    bool spawnReady;

    void Start()
    {
        spawnReady = true;
        clickTimerCounter = clickTimer;
        RandomizeValues();
        gameStart = true;
    }

    void Update()
    {
        if(gameStart)
        {
            if (!spawnReady)
            {
                clickTimerCounter -= Time.deltaTime;
                if (clickTimerCounter <= 0)
                {
                    spawnReady = true;
                }
            }
            if (Input.GetMouseButtonDown(0) && spawnReady)
            {
                clickTimerCounter = clickTimer;
                spawnReady = false;

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    clickPosition = hit.point;
                    Instantiate(tulkortPrefab, clickPosition, Quaternion.identity);
                }
            }
            beatleTimerCounter -= Time.deltaTime;

        }

    }

    void RandomizeValues()
    {
        rndTimer = Random.Range(1, max);
    }


}

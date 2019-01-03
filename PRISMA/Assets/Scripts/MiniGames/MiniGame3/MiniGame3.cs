using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGame3 : MonoBehaviour
{
    [SerializeField]
    GameObject tulkortPrefab, plane;
    [SerializeField]
    float clickTimer;
    float counter;
    Vector3 clickPosition;
    bool gameStart;
    [SerializeField]
    bool spawnReady;

    void Start()
    {
        spawnReady = true;
        counter = clickTimer;
        gameStart = true;
    }

    void Update()
    {
        if(!spawnReady)
        {
            counter -= Time.deltaTime;
            if (counter <= 0)
            {
                spawnReady = true;
            }
        }

        if(gameStart)
        {
            if (Input.GetMouseButtonDown(0) && spawnReady)
            {
                counter = clickTimer;
                spawnReady = false;

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    clickPosition = hit.point;
                    Instantiate(tulkortPrefab, clickPosition, Quaternion.identity);
                }
            }
        }

    }

    void SpawnBeatles()
    {

    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlants : MonoBehaviour
{
    [SerializeField]
    GameObject tulkortPrefab, achievement;
    Vector3 clickPosition;
    bool planted;
    GameManager gameManager;

    void Start()
    {
        planted = false;
        gameManager = GetComponent<GameManager>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SpawnPlant();

        }
    }

    void SpawnPlant()
    {
        if (!planted && gameManager.CorrectItem)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject clickObject = hit.transform.gameObject;
                clickPosition = hit.point;

                if (clickObject.name == "Terrain")
                {
                    Instantiate(tulkortPrefab, clickPosition, Quaternion.identity);
                    planted = true;
                    gameManager.Achievement(2, achievement);
                    GetComponent<SpawnPlants>().enabled = false;
                }

            }
        }
    }
}

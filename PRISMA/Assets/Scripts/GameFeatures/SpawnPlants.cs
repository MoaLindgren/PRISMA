using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlants : MonoBehaviour
{
    [SerializeField]
    GameObject tulkortPrefab;
    Vector3 clickPosition;
    bool planted;

    void Start()
    {
        planted = false;
        
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
        if (!planted)//&& om man har equiped item)
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
                }

            }
        }
    }
}

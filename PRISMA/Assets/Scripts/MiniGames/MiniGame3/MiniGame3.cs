using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGame3 : MonoBehaviour
{
    [SerializeField]
    GameObject tulkortPrefab, plane;
    Vector3 clickPosition;
    bool gameStart;

    void Start()
    {
        gameStart = true;
    }

    void Update()
    {
        if(gameStart)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit/*, Mathf.Infinity*/))
                {
                    clickPosition = hit.point;
                    Instantiate(tulkortPrefab, clickPosition, Quaternion.identity);
                }
            }
        }

    }


}

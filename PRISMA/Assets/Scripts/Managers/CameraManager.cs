using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    [SerializeField]
    float yPos, zPos;

    void Update()
    {
        Vector3 pos = player.transform.position;
        pos.y += yPos;
        pos.z += zPos;
        transform.position = pos;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    float yPos, zPos, xPos;
    [SerializeField]
    float defaultY, defaultZ;
    public bool defaultCamera;
    public Vector3 pos;
    
    void Start()
    {
        defaultCamera = true;
    }

    void Update()
    {
        if(defaultCamera)
        {
            DefaultPos();
        }
        else
        {
            NewPos();
        }
    }
    void DefaultPos()
    {
        pos = player.transform.position;
        pos.y += defaultY;
        pos.z += defaultZ;
        transform.position = pos;
    }
    void NewPos()
    {
        pos = player.transform.position;
        pos.y += yPos;
        pos.z += zPos;
        pos.x += xPos;
        transform.position = pos;
    }
    public void SetValues(float y, float z, float x)
    {
        yPos = y;
        zPos = z;
        xPos = x;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField]
    GameObject player, cameraParent;

    Vector3 pos;
    [SerializeField]
    Vector3 defaultPos, defaultRot;

    public bool defaultCamera;
    public Vector3 changePos, changeRot;
    public string description;
    
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
        transform.parent = cameraParent.transform;
        pos = player.transform.position + defaultPos;
        transform.eulerAngles = defaultRot;
        transform.position = pos;
    }
    void NewPos()
    {
        switch(description)
        {
            case "Coordinates":
                pos = player.transform.position + changePos;
                transform.eulerAngles = defaultRot;
                transform.position = pos;
                return;
            case "Coordinates_Rotation":
                pos = player.transform.position + changePos;
                //transform.eulerAngles = /*player.transform.eulerAngles + */changeRot;
                transform.position = pos;
                return;
            case "Follow":
                transform.parent = player.transform;
                pos = player.transform.position + changePos;
                //transform.LookAt(player.transform);
                transform.position = pos;
                return;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    GameObject popUpImage;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (popUpImage.active)
            {
                CloseBackpack();
            }
            else
            {
                OpenBackpack();
            }
        }
    }
    public void OpenBackpack()
    {
        popUpImage.SetActive(true);
    }
    public void CloseBackpack()
    {
        popUpImage.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    string myName;
    string fullName, itemName;
    [SerializeField]
    int index;
    [SerializeField]
    bool trigger;
    bool entered;
    GameManager gameManager;
    XmlManager xmlManager;

    void Start()
    {
        entered = true;
        xmlManager = GameObject.Find("GameManager").GetComponent<XmlManager>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        fullName = myName + index.ToString();
    }

    void OnTriggerEnter()
    {
        if (entered)
        {
            switch (myName)
            {
                case "Station":
                    gameManager.Station(index);
                    xmlManager.SetUpXML(trigger, fullName, index);
                    GetComponent<Collider>().enabled = false;
                    return;
                case "Achievement":
                    GameObject halo = transform.GetChild(0).gameObject;
                    gameManager.Achievement(index, halo);
                    GetComponent<Collider>().enabled = false;
                    return;
                case "Trigger":
                    xmlManager.SetUpXML(trigger, fullName, index);
                    GetComponent<Collider>().enabled = false;
                    return;
            }

            entered = false;
        }
    }
}

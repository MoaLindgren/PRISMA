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
    XmlManager xmlManager;

    void Start()
    {
        entered = true;
        xmlManager = GameObject.Find("GameManager").GetComponent<XmlManager>();
        fullName = myName + index.ToString();
    }
       
    void OnTriggerEnter()
    {
        if(entered)
        {
            xmlManager.SetUpXML(trigger, fullName, index);
            entered = false;
        }
    }
}

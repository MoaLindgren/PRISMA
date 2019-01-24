using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Temoporärt script. När vi väl ska göra script för olika "stationer" där saker ska hända så kan denna funktion (ontriggerenter) copy-pastas in i ett sådant script istället. 
public class TempSoundTrigger : MonoBehaviour
{
    GameObject gameManager;
    [SerializeField]
    AudioClip wolfSound;

    void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "player")
        {
            gameManager.GetComponent<SoundManager>().TriggerSound(wolfSound);
        }
    }
}

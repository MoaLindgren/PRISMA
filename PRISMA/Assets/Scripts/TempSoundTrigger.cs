using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

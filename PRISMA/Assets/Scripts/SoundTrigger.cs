using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class SoundTrigger : MonoBehaviour
{
    GameObject gameManager;
    [SerializeField]
    AudioClip audioClip;

    void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "player")
        {
            gameManager.GetComponent<SoundManager>().TriggerSound();
        }
    }
}

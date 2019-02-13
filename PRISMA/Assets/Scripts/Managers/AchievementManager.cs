using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    SoundManager soundManager;
    PlayerBehaviour playerBehaviour;

    void Start()
    {
        soundManager = GameObject.Find("GameManager").GetComponent<SoundManager>();
        playerBehaviour = GameObject.FindGameObjectWithTag("player").GetComponent<PlayerBehaviour>();
    }
    //void OnTriggerEnter()
    //{
    //    soundManager.TriggerSound();
    //    playerBehaviour.Moveable = false;
    //    gameObject.transform.GetChild(0).gameObject.SetActive(false);
    //}
}

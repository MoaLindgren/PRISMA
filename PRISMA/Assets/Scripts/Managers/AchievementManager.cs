using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    SoundManager soundManager;

    void Start()
    {
        soundManager = GetComponent<SoundManager>();
    }
    void AchievementAccomplished(int index)
    {
        soundManager.TriggerSound();
        //Aktivera rätt achievement.
    }

}

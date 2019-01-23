using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    AudioSource dayNightSound;
    [SerializeField]
    AudioClip daySound, nightSound;

    public void PlaySound(bool day)
    {
        if(day)
        {
            dayNightSound.clip = daySound;
        }
        else
        {
            dayNightSound.clip = nightSound;
        }
        dayNightSound.Play();
    }
}

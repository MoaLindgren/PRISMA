using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    AudioSource dayNightAudioSource, achievementAudioSource, uiAudioSource;
    [SerializeField]
    AudioClip daySound, nightSound, achievementSound;

    void Start()
    {
        dayNightAudioSource.Play();
    }
    public void PlaySound(string day)
    {
        if(day == "Day")
        {
            dayNightAudioSource.clip = daySound;
            dayNightAudioSource.Play();
        }
        else if(day == "Night")
        {
            dayNightAudioSource.clip = nightSound;
            dayNightAudioSource.Play();
        }
    }
    public void TriggerSound()
    {
        achievementAudioSource.clip = achievementSound;
        achievementAudioSource.Play();
    }
    public void UISound(AudioClip uiSound)
    {
        uiAudioSource.clip = uiSound;
        uiAudioSource.Play();
    }
}

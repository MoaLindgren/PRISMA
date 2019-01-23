using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    AudioSource dayNightAudioSource, triggeredAudioSource;
    [SerializeField]
    AudioClip daySound, nightSound;

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
    public void TriggerSound(AudioClip triggerSound)
    {
        triggeredAudioSource.PlayOneShot(triggerSound);
    }
}

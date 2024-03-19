using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource audioSource;
    public float startAt = 10f; 
    public float duration = 5f; 

    void Start()
    {
        PlayMusicPart(startAt, duration);
    }

    void PlayMusicPart(float start, float duration)
    {
        if(audioSource != null)
        {
            audioSource.time = start; 
            audioSource.Play(); 
            Invoke("StopMusic", duration); 
        }
    }

    void StopMusic()
    {
        if(audioSource.isPlaying)
        {
            audioSource.Stop(); 
        }
    }
}

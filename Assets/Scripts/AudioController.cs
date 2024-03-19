using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource sfxSource;

    public AudioClip musicClip;
    public AudioClip sfxClip_timer;
    public AudioClip sfxClip_win;
    public float startAt = 10f; 
    public float duration = 5f; 

    void Start()
    {

        PlayMusicPart(startAt, duration);
    }

    void PlayMusicPart(float start, float duration)
    {
        if(musicSource != null)
        {   
            musicSource.clip = musicClip;
            musicSource.time = start; 
            musicSource.Play(); 
            Invoke("StopMusic", duration); 
        }
    }

    void StopMusic()
    {
        if(musicSource.isPlaying)
        {
            musicSource.Stop(); 
        }
    }
    public void PlaySFX_Timer()
    {
        sfxSource.clip = sfxClip_timer;
        sfxSource.Play();
    }

    public void PlaySFX_Win()
    {
        sfxSource.clip = sfxClip_win;
        sfxSource.Play();
    }
}

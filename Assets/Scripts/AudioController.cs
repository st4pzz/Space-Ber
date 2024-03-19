using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{

    public AudioSource music;
    public AudioSource sfx;
    public AudioClip musicClip;
    public AudioClip sfxClip_timer;
    public AudioClip sfxClip_win;

    public float startAt = 10f; 
    public float duration = 50f; 
    void Start()
    {
        PlayMusicPart(startAt, duration);
    }
    void PlayMusicPart(float start, float duration)
    {
        if(music != null)
        {
            music.clip = musicClip;
            music.time = start; 
            music.Play(); 
            Invoke("StopMusic", duration); 
        }
    }
    void StopMusic()
    {
        if(music.isPlaying)
        {
            music.Stop(); 
        }
    }

    public void PlaySFX_Timer()
    {
        sfx.clip = sfxClip_timer;
        sfx.Play();
    }

    public void PlaySFX_Win()
    {
        sfx.clip = sfxClip_win;
        sfx.Play();
    }
}

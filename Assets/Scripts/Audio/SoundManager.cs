using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource soundEffectSource;
    [SerializeField] private AudioSource musicSource;

    [SerializeField] private float effectVolume;
    [SerializeField] private float musicVolume;

    public void Start ()
    {
        soundEffectSource.volume = effectVolume;
        musicSource.volume = musicVolume;
    }


    public void PlayEffect(AudioClip clip)
    {
        soundEffectSource.clip = clip;
        soundEffectSource.Play();
    }

    public void PlayMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.Play();
    }

}

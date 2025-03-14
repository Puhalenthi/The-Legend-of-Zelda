using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource soundEffectSource;

    [SerializeField] private float effectVolume;

    //Audio Clips
    [field: SerializeField] public AudioClip Rupee { get; private set; }
    [field: SerializeField] public AudioClip LinkAttack { get; private set; }
    [field: SerializeField] public AudioClip LinkDamage { get; private set; }
    [field: SerializeField] public AudioClip EnemyDamage { get; private set; }
    [field: SerializeField] public AudioClip LinkDie { get; private set; }
    [field: SerializeField] public AudioClip EnemyDie { get; private set; }
    //Deprecated
    [field: SerializeField] public AudioClip Secret { get; private set; }
    [field: SerializeField] public AudioClip LinkLowHealth { get; private set; }

    private AudioClip _chosenAudio;

    public void Start ()
    {
        soundEffectSource.volume = effectVolume;
    }


    public void PlayEffect(AudioClip clip)
    {
        soundEffectSource.clip = clip;
        soundEffectSource.Play();
    }

}

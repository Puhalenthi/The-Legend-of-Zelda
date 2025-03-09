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
    [field: SerializeField] public AudioClip Secret { get; private set; }
    [field: SerializeField] public AudioClip LinkLowHealth { get; private set; }





    public void Awake ()
    {
        MessageManager.Instance.damageMessenger.Subscribe(PlayEffect);
        MessageManager.Instance.hitMessenger.Subscribe(PlayEffect);
        MessageManager.Instance.killMessenger.Subscribe(PlayEffect);
        MessageManager.Instance.rupeeMessenger.Subscribe(PlayEffect);
    }
    public void Start ()
    {
        soundEffectSource.volume = effectVolume;
    }


    public void PlayEffect(Message m)
    {
        AudioClip clip = m.sound;
        soundEffectSource.clip = clip;
        soundEffectSource.Play();
    }

}

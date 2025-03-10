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




    public void Awake ()
    {
        MessageManager.Instance.damageMessenger.Subscribe(PlayEffect);
        MessageManager.Instance.hitMessenger.Subscribe(PlayEffect);
        MessageManager.Instance.killMessenger.Subscribe(PlayEffect);
        MessageManager.Instance.rupeeMessenger.Subscribe(PlayEffect);
        MessageManager.Instance.deathMessenger.Subscribe(PlayEffect);
    }
    public void Start ()
    {
        soundEffectSource.volume = effectVolume;
    }


    public void PlayEffect(Message m)
    {
        if (m.audioType == "Rupee")
        {
            _chosenAudio = Rupee;
        }
        if (m.audioType == "Attack")
        {
            _chosenAudio = LinkAttack;
        }
        if (m.audioType == "Damage")
        {
            _chosenAudio = LinkDamage;
        }
        if (m.audioType == "Hit")
        {
            _chosenAudio = EnemyDamage;
        }
        if (m.audioType == "Death")
        {
            _chosenAudio = LinkDie;
        }
        if (m.audioType == "Kill")
        {
            _chosenAudio = EnemyDie;
        }
        soundEffectSource.clip = _chosenAudio;
        soundEffectSource.Play();
    }

}

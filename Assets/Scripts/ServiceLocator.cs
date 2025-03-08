using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceLocator : MonoBehaviour
{

    //Set up the singleton
    public static ServiceLocator Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        } 
        else if (Instance != this)
        {
            Destroy(this);
        }
    }

    //Services
    [field: SerializeField] public SoundManager AudioService { get; [SerializeField] set; }
}

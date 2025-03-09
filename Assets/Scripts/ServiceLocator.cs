using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceLocator : Singleton<ServiceLocator>
{
    //Services
    [field: SerializeField] public SoundManager AudioService { get; [SerializeField] set; }
}

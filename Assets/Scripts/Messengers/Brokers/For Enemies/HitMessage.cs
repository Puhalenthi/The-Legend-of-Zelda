using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitMessage : Message
{
    public GameObject CreatureHit;
    
    public HitMessage (GameObject CreatureHit)
    {
        this.CreatureHit = CreatureHit;
        audioType = "Hit";
    }
}

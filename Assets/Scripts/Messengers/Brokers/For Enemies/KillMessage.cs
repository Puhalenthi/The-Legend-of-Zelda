using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillMessage : Message
{
    public GameObject CreatureKilled;
    
    public KillMessage(GameObject CreatureKilled)
    {
        this.CreatureKilled = CreatureKilled;
        audioType = "Kill";
    }
}

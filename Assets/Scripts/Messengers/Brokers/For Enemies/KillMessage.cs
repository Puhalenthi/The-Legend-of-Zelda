using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillMessage : Message
{
    public Actor.actorType CreatureKilled;
    
    public HitMessage (Actor.actorType CreatureKilled)
    {
        this.CreatureKilled = CreatureKilled;
    }
}

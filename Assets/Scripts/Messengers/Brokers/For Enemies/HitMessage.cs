using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitMessage : Message
{
    public Actor.actorType CreatureHit;
    
    public HitMessage (Actor.actorType CreatureHit)
    {
        this.CreatureHit = CreatureHit;
    }
}

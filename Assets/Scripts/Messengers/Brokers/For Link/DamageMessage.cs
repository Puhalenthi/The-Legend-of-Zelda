using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageMessage : Message
{
    // Start is called before the first frame update
    public float DmgAmount;
    
    public DamageMessage(float DmgAmount)
    {
        this.DmgAmount = DmgAmount;
    }
}

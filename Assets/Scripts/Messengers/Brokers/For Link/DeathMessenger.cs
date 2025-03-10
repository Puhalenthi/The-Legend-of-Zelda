using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMessenger : Messenger<DeathMessage>
{
    private passMessage receivers;
    
    public override void SendMessage(DeathMessage m)
    {
        receivers(m);
    }

    public override void Subscribe(passMessage method)
    {
        receivers += method;
    }

    public override void Unsubscribe(passMessage method)
    {
        receivers -= method;
    }
}

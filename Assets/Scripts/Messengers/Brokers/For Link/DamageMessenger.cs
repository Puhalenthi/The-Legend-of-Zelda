using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageMessenger : Messenger<DamageMessage>
{
    private passMessage receivers;
    
    public override void SendMessage(DamageMessage msg)
    {
        receivers(msg);
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

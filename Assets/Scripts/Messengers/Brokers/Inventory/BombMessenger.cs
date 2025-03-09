using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombMessenger : Messenger<BombMessage>
{
     private passMessage receivers;
    
    public override void SendMessage(BombMessage m)
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

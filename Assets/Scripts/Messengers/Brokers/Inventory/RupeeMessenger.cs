using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RupeeMessenger : Messenger<RupeeMessage>
{
    private passMessage receivers;
    
    public override void SendMessage(RupeeMessage m)
    {
        Debug.Log("Hello Rupee");
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

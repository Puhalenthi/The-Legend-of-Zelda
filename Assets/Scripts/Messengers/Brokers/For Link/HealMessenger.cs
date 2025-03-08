using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealMessenger : Messenger<HealMessage>
{
    private passMessage receivers;
    
    public override void SendMessage(HealMessage msg)
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

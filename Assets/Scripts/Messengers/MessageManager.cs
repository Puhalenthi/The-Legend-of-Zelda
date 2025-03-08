using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageManager : Singleton<MessageManager>
{
    public HealMessenger healMessenger = new HealMessenger();
    public DamageMessenger damageMessenger = new DamageMessenger();
    public HitMessenger hitMessenger = new HitMessenger();
    public KillMessenger killMessenger = new KillMessenger();
}

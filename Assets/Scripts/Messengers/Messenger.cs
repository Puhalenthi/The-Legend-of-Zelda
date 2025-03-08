using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Messenger<T> where T : Message
{
    public delegate void passMessage(T message);

    public abstract void Subscribe(passMessage method);

    public abstract void Unsubscribe(passMessage method);

    public abstract void SendMessage(T message);
}

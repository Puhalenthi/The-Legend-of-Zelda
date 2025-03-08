using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PlayerState
{
    public void HandleLeft();
    public void HandleRight();
    public void HandleUp();
    public void HandleDown();

    public void HandleSpace();

    public void HandleIdle();

    public void AdvanceState();

    public PlayerDirection GetDirection();
}
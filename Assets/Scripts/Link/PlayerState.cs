using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PlayerState
{
    public void handleLeft();
    public void handleRight();
    public void handleUp();
    public void handleDown();

    public void handleSpace();

    public void handleIdle();

    public void advanceState();
}
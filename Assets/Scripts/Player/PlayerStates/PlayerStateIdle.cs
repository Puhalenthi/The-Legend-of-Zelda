using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateIdle : PlayerState
{
    protected PlayerController player;


    public void advanceState()
    {
        // stays the same
    }

    public void handleDown()
    {
        // cannot move
    }

    public void handleUp()
    {
        // cannot move
    }

    public void handleLeft()
    {
        // cannot move
    }

    public void handleRight()
    {
        // cannot move
    }

    public void handleSpace()
    {
        player.setState(new PlayerStateAttack());
    }

}

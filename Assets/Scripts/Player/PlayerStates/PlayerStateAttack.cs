using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateAttack : PlayerState
{
    protected PlayerController player;
    private int framesRemaining;

    public void advanceState()
    {
        framesRemaining--;
        if (framesRemaining <= 0)
        {
            player.setState(new PlayerStateIdle());
        }
    }

    public void handleDown()
    {
        //cannot move while attacking
    }

    public void handleUp()
    {
        //cannot move while attacking
    }

    public void handleLeft()
    {
        //cannot move while attacking
    }

    public void handleRight()
    {
        //cannot move while attacking
    }

    public void handleSpace()
    {
        // cannot attack while already attacking
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateAttack : PlayerState
{
    protected PlayerController player;
    private int framesRemaining = 60;

    private PlayerDirection direction;

    public PlayerStateAttack(PlayerController controller, PlayerDirection direction)
    {
        this.player = controller;
        this.direction = direction;


        if (direction == PlayerDirection.UP)
        {
            player.animator.SetTrigger("OnAttackUp");
        }
        else if (direction == PlayerDirection.RIGHT)
        {
            player.animator.SetTrigger("OnAttackRight");
        }
        else if (direction == PlayerDirection.DOWN)
        {
            player.animator.SetTrigger("OnAttackDown");
        }
        else if (direction == PlayerDirection.LEFT)
        {
            player.animator.SetTrigger("OnAttackLeft");
        }
    }

    public void advanceState()
    {
        framesRemaining--;
        if (framesRemaining <= 0)
        {
            resetTriggers();
            player.setState(new PlayerStateIdle(player, this.direction));
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

    public void handleIdle()
    {
        // cannot idle while already attacking
    }

    private void resetTriggers()
    {
        player.animator.ResetTrigger("OnAttackUp");
        player.animator.ResetTrigger("OnAttackRight");
        player.animator.ResetTrigger("OnAttackDown");
        player.animator.ResetTrigger("OnAttackLeft");
    }
}

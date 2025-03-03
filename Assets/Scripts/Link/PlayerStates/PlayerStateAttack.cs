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

    public void AdvanceState()
    {
        framesRemaining--;
        if (framesRemaining <= 0)
        {
            player.ResetAnimatorTriggers();
            player.SetState(new PlayerStateIdle(player, this.direction));
        }
    }

    public void HandleDown()
    {
        //cannot move while attacking
    }

    public void HandleUp()
    {
        //cannot move while attacking
    }

    public void HandleLeft()
    {
        //cannot move while attacking
    }

    public void HandleRight()
    {
        //cannot move while attacking
    }

    public void HandleSpace()
    {
        // cannot attack while already attacking
    }

    public void HandleIdle()
    {
        // cannot idle while already attacking
    }
}

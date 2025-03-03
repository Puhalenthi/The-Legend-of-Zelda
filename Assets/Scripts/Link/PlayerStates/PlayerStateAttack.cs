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


        // TODO: check if enemy is in box collider, handle it.
        // Box Colliders are disabled during space cooldown
        if (direction == PlayerDirection.UP)
        {
            player.animator.SetTrigger("OnAttackUp");
            player.topBoxCollider.enabled = true;

            // TODO: handle
        }
        else if (direction == PlayerDirection.RIGHT)
        {
            player.animator.SetTrigger("OnAttackRight");
            player.rightBoxCollider.enabled = true;

            // TODO: handle
        }
        else if (direction == PlayerDirection.DOWN)
        {
            player.animator.SetTrigger("OnAttackDown");
            player.bottomBoxCollider.enabled = true;

            // TODO: handle
        }
        else if (direction == PlayerDirection.LEFT)
        {
            player.animator.SetTrigger("OnAttackLeft");
            player.leftBoxCollider.enabled = true;

            // TODO: handle
        }
    }

    public void advanceState()
    {
        framesRemaining--;
        if (framesRemaining <= 0)
        {
            player.ResetAnimatorTriggers();
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
}

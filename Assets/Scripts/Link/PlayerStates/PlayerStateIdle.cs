using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateIdle : PlayerState
{
    protected PlayerController player;
    private PlayerDirection direction;

    public PlayerStateIdle(PlayerController controller, PlayerDirection direction)
    {
        this.player = controller;
        this.direction = direction;

        if (direction == PlayerDirection.UP)
        {
            player.animator.SetTrigger("OnIdleUp");
        }
        else if (direction == PlayerDirection.RIGHT)
        {
            player.animator.SetTrigger("OnIdleRight");
        }
        else if (direction == PlayerDirection.DOWN)
        {
            player.animator.SetTrigger("OnIdleDown");
        }
        else if (direction == PlayerDirection.LEFT)
        {
            player.animator.SetTrigger("OnIdleLeft");
        }
    }

    public void AdvanceState()
    {
        // character is idling (nothing happens)
    }

    public void HandleDown()
    {
        player.ResetAnimatorTriggers();
        player.SetState(new PlayerStateWalk(player, PlayerDirection.DOWN));
    }

    public void HandleUp()
    {
        player.ResetAnimatorTriggers();
        player.SetState(new PlayerStateWalk(player, PlayerDirection.UP));
    }

    public void HandleLeft()
    {
        player.ResetAnimatorTriggers();
        player.SetState(new PlayerStateWalk(player, PlayerDirection.LEFT));
    }

    public void HandleRight()
    {
        player.ResetAnimatorTriggers();
        player.SetState(new PlayerStateWalk(player, PlayerDirection.RIGHT));
    }

    public void HandleSpace()
    {
        player.ResetAnimatorTriggers();
        player.SetState(new PlayerStateAttack(player, this.direction));
    }

    public void HandleIdle()
    {
        // already idle
    }

    public PlayerDirection GetDirection()
    {
        return this.direction;
    }
}

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

    public void advanceState()
    {
        // character is idling (nothing happens)
    }

    public void handleDown()
    {
        resetTriggers();
        player.setState(new PlayerStateWalk(player, PlayerDirection.DOWN));
    }

    public void handleUp()
    {
        resetTriggers();
        player.setState(new PlayerStateWalk(player, PlayerDirection.UP));
    }

    public void handleLeft()
    {
        resetTriggers();
        player.setState(new PlayerStateWalk(player, PlayerDirection.LEFT));
    }

    public void handleRight()
    {
        resetTriggers();
        player.setState(new PlayerStateWalk(player, PlayerDirection.RIGHT));
    }

    public void handleSpace()
    {
        resetTriggers();
        player.setState(new PlayerStateAttack(player, this.direction));
    }

    public void handleIdle()
    {
        // already idle
    }

    private void resetTriggers()
    {
        player.animator.ResetTrigger("OnIdleUp");
        player.animator.ResetTrigger("OnIdleRight");
        player.animator.ResetTrigger("OnIdleDown");
        player.animator.ResetTrigger("OnIdleLeft");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateWalk : PlayerState
{
    protected PlayerController player;
    private float speed;

    private PlayerDirection direction;

    public PlayerStateWalk(PlayerController controller, PlayerDirection direction)
    {
        this.player = controller;
        this.direction = direction;
        this.speed = this.player.speed;
    }

    public void advanceState()
    {
        // stays the same
    }



    public void handleDown()
    {
        this.direction = PlayerDirection.DOWN;

        player.animator.SetTrigger("OnWalkDown");
        //Debug.Log("should have set trigger./..");
        player.transform.position = new Vector2 (player.transform.position.x, player.transform.position.y - speed);
    }

    public void handleUp()
    {
        this.direction = PlayerDirection.UP;

        player.animator.SetTrigger("OnWalkUp");
        player.transform.position = new Vector2(player.transform.position.x, player.transform.position.y + speed);
    }

    public void handleLeft()
    {
        this.direction = PlayerDirection.LEFT;

        player.animator.SetTrigger("OnWalkLeft");
        player.transform.position = new Vector2(player.transform.position.x - speed, player.transform.position.y);
    }

    public void handleRight()
    {
        this.direction = PlayerDirection.RIGHT;

        player.animator.SetTrigger("OnWalkRight");
        player.transform.position = new Vector2(player.transform.position.x + speed, player.transform.position.y);
    }



    public void handleSpace()
    {
       player.ResetAnimatorTriggers();
       player.setState(new PlayerStateAttack(player, this.direction));
    }

    public void handleIdle()
    {
        player.ResetAnimatorTriggers();
        player.setState(new PlayerStateIdle(player, this.direction));
    }

    public PlayerDirection GetDirection()
    {
        return this.direction;
    }
}

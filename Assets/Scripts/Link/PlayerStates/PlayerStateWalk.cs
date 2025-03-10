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

    public void AdvanceState()
    {
        // stays the same
    }



    public void HandleDown()
    {
        this.direction = PlayerDirection.DOWN;

        player.animator.SetTrigger("OnWalkDown");
        //Debug.Log("should have set trigger./..");
        player.transform.Translate(new Vector2(0, -1 * speed * Time.deltaTime));
    }

    public void HandleUp()
    {
        this.direction = PlayerDirection.UP;

        player.animator.SetTrigger("OnWalkUp");
        player.transform.Translate(new Vector2(0, speed * Time.deltaTime));
    }

    public void HandleLeft()
    {
        this.direction = PlayerDirection.LEFT;

        player.animator.SetTrigger("OnWalkLeft");
        player.transform.Translate(new Vector2(-1 * speed * Time.deltaTime,0));
    }

    public void HandleRight()
    {
        this.direction = PlayerDirection.RIGHT;

        player.animator.SetTrigger("OnWalkRight");
        player.transform.Translate(new Vector2(speed * Time.deltaTime, 0));
    }



    public void HandleSpace()
    {
       player.ResetAnimatorTriggers();
       player.SetState(new PlayerStateAttack(player, this.direction));
    }

    public void HandleIdle()
    {
        player.ResetAnimatorTriggers();
        player.SetState(new PlayerStateIdle(player, this.direction));
    }

    public PlayerDirection GetDirection()
    {
        return this.direction;
    }
}

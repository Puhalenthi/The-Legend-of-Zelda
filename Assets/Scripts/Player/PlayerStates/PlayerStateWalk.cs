using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateWalk : PlayerState
{
    protected PlayerController player;
    private float speed;

    public PlayerStateWalk(float speed) : base()
    {
        this.speed = speed;
    }

    public void advanceState()
    {
        // stays the same
    }



    public void handleDown()
    {
        player.transform.position = new Vector2 (player.transform.position.x, player.transform.position.y - speed);
    }

    public void handleUp()
    {
        player.transform.position = new Vector2(player.transform.position.x, player.transform.position.y + speed);
    }

    public void handleLeft()
    {
        player.transform.position = new Vector2(player.transform.position.x - speed, player.transform.position.y);
    }

    public void handleRight()
    {
        player.transform.position = new Vector2(player.transform.position.x + speed, player.transform.position.y);
    }



    public void handleSpace()
    {
        player.setState(new PlayerStateAttack());
    }

}

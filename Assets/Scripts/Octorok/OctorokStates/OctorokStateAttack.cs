using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class OctorokStateAttack : OctorokState
{
    protected OctorokController enemy;

    private OctorokDirection _direction;

    private int _totalFrames = 300;
    private int _framesRemaining;

    public OctorokStateAttack(OctorokDirection direction, OctorokController controller)
    {
        _direction = direction;
        enemy = controller;
        _framesRemaining = _totalFrames;

        enemy.animator.SetTrigger("OnShoot");
    }

    public void AdvanceState()
    {

        _framesRemaining--;
        if (_framesRemaining == (_totalFrames / 2)) // Shoot the pellet
        {
            GameObject pelletInstance = enemy.InstantiatePellet();
            Pellet pelletScript = pelletInstance.GetComponent<Pellet>();

            if (_direction == OctorokDirection.UP)
            {
                pelletScript.Instantiate(Vector2.up);
            }
            else if (_direction == OctorokDirection.RIGHT)
            {
                pelletScript.Instantiate(Vector2.right);
            }
            else if (_direction == OctorokDirection.DOWN)
            {
                pelletScript.Instantiate(Vector2.down);
            }
            else if (_direction == OctorokDirection.LEFT)
            {
                pelletScript.Instantiate(Vector2.left);
            }
        }
        else if (_framesRemaining <= 0)
        {
            enemy.animator.ResetTrigger("OnShoot");
            Idle(_direction, enemy);
        }
    }

    public void Move()
    {
        //cannot move while attacking
    }

    public void Idle(OctorokDirection direction, OctorokController enemy)
    {
        enemy.SetState(direction, new OctorokStateIdle(direction, enemy));
    }

    public void Walk(OctorokDirection direction, OctorokController enemy)
    {
        // Cannot walk while attacking
    }
    public void Attack(OctorokDirection direction, OctorokController enemy)
    {
        // Cannot attack while already attacking
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctorokStateIdle : OctorokState
{
    protected OctorokController enemy;
    private OctorokDirection _direction;

    private int framesRemaining;

    public OctorokStateIdle(OctorokDirection direction, OctorokController controller)
    {
        enemy = controller;
        _direction = direction;

        // random number of frames from 60, 181
        framesRemaining = Random.Range(150, 300);

        enemy.animator.SetTrigger("OnIdle");
    }

    public void AdvanceState()
    {
        framesRemaining--;

        if (framesRemaining <= 0)
        {
            enemy.animator.ResetTrigger("OnIdle");
            int action = Random.Range(1, 4);
            if (action <= 2) // Walk
            {
                OctorokDirection randomDirection = (OctorokDirection)Random.Range(0, System.Enum.GetValues(typeof(OctorokDirection)).Length);
                Walk(randomDirection, enemy);
            }
            else if (action == 3) // Attack
            {
                Attack(_direction, enemy);
            }

        }
    }

    public void Move()
    {
        // cannot move while idle
    }

    public void Walk(OctorokDirection direction, OctorokController enemy)
    {
        enemy.SetState(direction, new OctorokStateWalk(direction, enemy));
    }


    public void Attack(OctorokDirection direction, OctorokController enemy)
    {
        enemy.SetState(direction, new OctorokStateAttack(direction, enemy));
    }

    public void Idle(OctorokDirection direction, OctorokController enemy)
    {
        // Cannot idle while already idling
    }
}

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
                enemy.SetState(new OctorokStateWalk(randomDirection, enemy));
            }
            else if (action == 3) // Attack
            {
                enemy.SetState(new OctorokStateAttack(_direction, enemy));
            }

        }
    }

    public void Move()
    {
        // cannot move while idle
    }
}

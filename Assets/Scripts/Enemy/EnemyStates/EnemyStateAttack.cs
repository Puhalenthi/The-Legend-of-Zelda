using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateAttack : EnemyState
{
    protected EnemyController enemy;
    private int framesRemaining = 60;

    public EnemyStateAttack (EnemyController controller)
    {
        enemy = controller;
    }

    public void AdvanceState()
    {
        framesRemaining--;
        if (framesRemaining <= 0)
        {
            enemy.SetState(new EnemyStateMove());
        }
    }

    public void Move()
    {
        //cannot move while attacking
    }
}

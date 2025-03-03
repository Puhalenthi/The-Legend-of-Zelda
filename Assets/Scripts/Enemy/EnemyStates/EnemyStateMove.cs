using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMove : EnemyState
{
    protected EnemyController enemy;

    public EnemyStateMove(EnemyController controller)
    {
        enemy = controller;
    }

    public void AdvanceState()
    {
        //continues moving
    }

    public void Move()
    {
        throw new System.NotImplementedException();
    }
}

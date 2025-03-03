using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateIdle : EnemyState
{
    protected EnemyController enemy;

    public EnemyStateController(EnemyController controller)
    {
        enemy = controller;
    }
    public void AdvanceState()
    {
        //stays idling
    }

    public void Move()
    {
        //cannot move while idling
    }
}

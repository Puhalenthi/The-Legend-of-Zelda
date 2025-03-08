using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
<<<<<<< HEAD
//using static UnityEngine.RuleTile.TilingRuleOutput;
=======
>>>>>>> a1c509ff073ec2b6c748f12056583ac09dba8ae7

public class OctorokStateAttack : OctorokState
{
    protected OctorokController enemy;

    private OctorokDirection _direction;

    private int totalFrames = 300;
    private int framesRemaining;

    public OctorokStateAttack(OctorokDirection direction, OctorokController controller)
    {
        _direction = direction;
        enemy = controller;
        framesRemaining = totalFrames;

        enemy.animator.SetTrigger("OnShoot");
    }

    public void AdvanceState()
    {

        framesRemaining--;
        if (framesRemaining == (totalFrames / 2)) // Shoot the pellet
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
        else if (framesRemaining <= 0)
        {
            enemy.animator.ResetTrigger("OnShoot");
            enemy.SetState(new OctorokStateIdle(_direction, enemy));
        }
    }

    public void Move()
    {
        //cannot move while attacking
    }
}

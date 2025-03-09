using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctorokStateWalk : OctorokState
{
    protected OctorokController enemy;
    private OctorokDirection _direction;
    private Vector2 _vectorDirection;

    private int framesRemaining;

    public OctorokStateWalk(OctorokDirection direction, OctorokController controller)
    {
        _direction = direction;
        enemy = controller;

        framesRemaining = Random.Range(300, 600);

        if (direction == OctorokDirection.UP)
        {
            enemy.animator.SetTrigger("OnWalkUp");
            _vectorDirection = Vector2.up;
        }
        else if (direction == OctorokDirection.RIGHT)
        {
            enemy.animator.SetTrigger("OnWalkRight");
            _vectorDirection = Vector2.right;
        }
        else if (direction == OctorokDirection.DOWN)
        {
            enemy.animator.SetTrigger("OnWalkDown");
            _vectorDirection = Vector2.down;
        }
        else if (direction == OctorokDirection.LEFT)
        {
            enemy.animator.SetTrigger("OnWalkLeft");
            _vectorDirection = Vector2.left;
        }
    }

    public void AdvanceState()
    {
        framesRemaining--;

        if (framesRemaining <= 0)
        {
            if (_direction == OctorokDirection.UP) enemy.animator.ResetTrigger("OnWalkUp");
            else if (_direction == OctorokDirection.RIGHT) enemy.animator.ResetTrigger("OnWalkRight");
            else if (_direction == OctorokDirection.DOWN) enemy.animator.ResetTrigger("OnWalkDown");
            else if (_direction == OctorokDirection.LEFT) enemy.animator.ResetTrigger("OnWalkLeft");

            Idle(_direction, enemy);
        }
    }

    public void Move()
    {
        enemy.transform.Translate(_vectorDirection * enemy.speed * Time.deltaTime);
    }

    public void Idle(OctorokDirection direction, OctorokController enemy)
    {
        enemy.SetState(direction, new OctorokStateIdle(direction, enemy));
    }

    public void Walk(OctorokDirection direction, OctorokController enemy)
    {
        // Cannot walk while already walking
    }

    public void Attack(OctorokDirection direction, OctorokController enemy)
    {
        // Cannot attack while walking
    }

    public IEnumerator Timer(float duration)
    {
        yield return new WaitForSeconds(duration);
    }
}

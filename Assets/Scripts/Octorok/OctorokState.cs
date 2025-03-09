using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface OctorokState
{
    public void Move();
    public void AdvanceState();

    public void Walk(OctorokDirection direction, OctorokController enemy);
    public void Idle(OctorokDirection direction, OctorokController enemy);
    public void Attack(OctorokDirection direction, OctorokController enemy);

}

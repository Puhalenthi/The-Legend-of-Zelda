// Puhalenthi Ramesh Vidhya

/* This test suite tests the handling of changing the octorok directions and states. It will test the Idle, Walk, and Idle
 * states and if it correctly handles switching the states as stated by the Animator FSM. 
 * 
 * When in Idle, the octorok can switch to Attack or Walk. When in Walk, the octorok can only switch to Idle. When in Attack, 
 * the octorok can only switch to Idle. To test this, each test will begin with one of the 3 states and assert if it is able
 * to move in the acceptable directions. The tests are not brittle because it's creating a new object and updating the
 * OctorokController accordingly. This just emulates what EnemyController would do in a sort of way
 */

using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class OctorokStateTests : MonoBehaviour
{
    private OctorokController _enemy;

    [SetUp]
    public void Setup()
    {
        _enemy = new GameObject().AddComponent<OctorokController>();
        _enemy.animator = _enemy.animator.GetComponent<Animator>();

        _enemy.SetState(OctorokDirection.UP, new OctorokStateIdle(OctorokDirection.UP, _enemy));
    }

    [Test]
    public void UpIdleByDefault()
    {
        Assert.AreEqual(OctorokDirection.UP, _enemy.GetDirection());
        Assert.That(_enemy.GetState(), Is.TypeOf<OctorokStateIdle>());
    }

    [Test]
    public void IdleToAttackTest()
    {
        // From Idle, switching to Attack is allowed.
        _enemy.GetState().Attack(OctorokDirection.UP, _enemy);
        Assert.AreEqual(OctorokDirection.UP, _enemy.GetDirection());
        Assert.That(_enemy.GetState(), Is.TypeOf<OctorokStateAttack>());
    }

    [Test]
    public void IdleToWalkTest()
    {
        // From Idle, switching to Walk is allowed.
        _enemy.GetState().Walk(OctorokDirection.UP, _enemy);
        Assert.AreEqual(OctorokDirection.UP, _enemy.GetDirection());
        Assert.That(_enemy.GetState(), Is.TypeOf<OctorokStateWalk>());
    }

    [Test]
    public void SwitchingStatesAndDirectionTest()
    {
        // Switch to Walk while changing direction to RIGHT.
        _enemy.GetState().Walk(OctorokDirection.RIGHT, _enemy);
        Assert.AreEqual(OctorokDirection.RIGHT, _enemy.GetDirection());
        Assert.That(_enemy.GetState(), Is.TypeOf<OctorokStateWalk>());

        // Switch to Idle with same direction.
        _enemy.GetState().Idle(OctorokDirection.RIGHT, _enemy);
        Assert.AreEqual(OctorokDirection.RIGHT, _enemy.GetDirection());
        Assert.That(_enemy.GetState(), Is.TypeOf<OctorokStateIdle>());

        // Finally, switch to Attack while changing direction to LEFT.
        _enemy.GetState().Attack(OctorokDirection.LEFT, _enemy);
        Assert.AreEqual(OctorokDirection.LEFT, _enemy.GetDirection());
        Assert.That(_enemy.GetState(), Is.TypeOf<OctorokStateAttack>());
    }
}

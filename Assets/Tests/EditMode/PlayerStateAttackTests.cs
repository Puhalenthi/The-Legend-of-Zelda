//Zevi Cohen

/*
 * This test suite tests that box colliders are enabled when appropriate, that attack state is handled for the right amount of frames, and that the player cannot move while in attack state.
 * To provide a complete test suite, I used boundary tests to check when the attack state updated to idle state (when frames run out).
 * I also ensured that for each direction, only the corresponding collider was enabled.
 * I did only include one test for handling movement, keeping in mind that nothing is implemented for those functions.
 * This could become brittle over time, however since movement is not an inherent part of attacking, I do not believe the functionality would ever change for those functions.
 * Even if they did change and the player could somehow move while attacking, the function name should indicate that it is testing for all movement and everything would be updated accordingly.
*/

using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerStateAttackTests : MonoBehaviour
{
    private PlayerController player;

    [SetUp]
    public void Setup()
    {
        player = new GameObject().AddComponent<PlayerController>();
        player.animator = player.gameObject.AddComponent<Animator>();

        player.topBoxCollider = player.gameObject.AddComponent<BoxCollider2D>();
        player.bottomBoxCollider = player.gameObject.AddComponent<BoxCollider2D>();
        player.leftBoxCollider = player.gameObject.AddComponent<BoxCollider2D>();
        player.rightBoxCollider = player.gameObject.AddComponent<BoxCollider2D>();

        player.topBoxCollider.enabled = false;
        player.bottomBoxCollider.enabled = false;
        player.leftBoxCollider.enabled = false;
        player.rightBoxCollider.enabled = false;

        //set direction default to up for testing
        player.SetState(new PlayerStateAttack(player, PlayerDirection.UP));
    }

    [Test]
    public void AttackUp_TopColliderEnabled()
    {
        Assert.IsTrue(player.topBoxCollider.enabled);
        Assert.IsFalse(player.bottomBoxCollider.enabled);
        Assert.IsFalse(player.leftBoxCollider.enabled);
        Assert.IsFalse(player.rightBoxCollider.enabled);

    }

    [Test]
    public void AttackDown_BottomColliderEnabled()
    {
        player.SetState(new PlayerStateAttack(player, PlayerDirection.DOWN));
        Assert.IsTrue(player.bottomBoxCollider.enabled);
        Assert.IsFalse(player.topBoxCollider.enabled);
        Assert.IsFalse(player.leftBoxCollider.enabled);
        Assert.IsFalse(player.rightBoxCollider.enabled);
    }

    [Test]
    public void AttackLeft_LeftColliderEnabled()
    {
        player.SetState(new PlayerStateAttack(player, PlayerDirection.LEFT));
        Assert.IsTrue(player.leftBoxCollider.enabled);
        Assert.IsFalse(player.topBoxCollider.enabled);
        Assert.IsFalse(player.bottomBoxCollider.enabled);
        Assert.IsFalse(player.rightBoxCollider.enabled);
    }

    [Test]
    public void AttackRight_RightColliderEnabled()
    {
        player.SetState(new PlayerStateAttack(player, PlayerDirection.RIGHT));
        Assert.IsTrue(player.rightBoxCollider.enabled);
        Assert.IsFalse(player.topBoxCollider.enabled);
        Assert.IsFalse(player.bottomBoxCollider.enabled);
        Assert.IsFalse(player.leftBoxCollider.enabled);
    }

    [Test]
    public void AdvanceState_FramesRemainingDecreasesOnFramesRemainingGreaterThanZero()
    {
        player.GetState().AdvanceState();
        Assert.AreEqual(((PlayerStateAttack)player.GetState()).framesRemaining, 59);
        Assert.That(player.GetState(), Is.TypeOf<PlayerStateAttack>());
    }

    [Test]
    public void AdvanceState_StateSetToIdleOnFramesRemainingEqualToZero()
    {
        ((PlayerStateAttack)player.GetState()).framesRemaining = 0;
        player.GetState().AdvanceState();
        Assert.That(player.GetState(), Is.TypeOf<PlayerStateIdle>());
    }

    [Test]
    public void AdvanceState_StateSetToIdleOnFramesRemainingLessThanZero()
    {
        ((PlayerStateAttack)player.GetState()).framesRemaining = -1;
        player.GetState().AdvanceState();
        Assert.That(player.GetState(), Is.TypeOf<PlayerStateIdle>());
    }

    [Test]
    public void HandleMovement_CannotMove()
    {
        player.GetState().HandleUp();
        player.GetState().HandleDown();
        player.GetState().HandleLeft();
        player.GetState().HandleRight();

        Assert.That(player.GetState(), Is.TypeOf<PlayerStateAttack>());
        Assert.AreEqual(PlayerDirection.UP, player.GetState().GetDirection());
    }


}

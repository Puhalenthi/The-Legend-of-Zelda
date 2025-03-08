// Joshua Peisach

// This test suite tests the handling of changing player directions and states, primarily in context of a PlayerStateIdle.
// In order to test the suite, I added a test for default player state and direction, all four directions, consecutive
// inputs of the same key, and two directly opposite dirrections to ensure the player is facing the way it should.
// While at this point, I also ensured that the state was moved to PlayerStateWalk on input, otherwise remaining at
// PlayerStateIdle. The tests shouldn't be brittle, it's really just creating a new object and updating the PlayerController
// accordingly. While a test double could fit this better, as of writing the PlayerStates were not written for dependency injection,
// so unless we can't find a place to make a test suite using test doubles, this will be a simple recreation of the PlayerController,
// just with the necessary objects.
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerStateIdleTests
{
    private PlayerController player;

    [SetUp]
    public void Setup()
    {
        player = new GameObject().AddComponent<PlayerController>();
        player.animator = player.gameObject.AddComponent<Animator>();

        player.SetState(new PlayerStateIdle(player, PlayerDirection.UP));
    }

    [Test]
    public void PlayerDirection_UpIdleByDefault()
    {
        Assert.AreEqual(PlayerDirection.UP, player.GetState().GetDirection());
        Assert.That(player.GetState(), Is.TypeOf<PlayerStateIdle>());
    }

    [Test]
    public void PlayerDirection_LeftWalkOnInputLeft()
    {
        player.GetState().HandleLeft();

        Assert.AreEqual(PlayerDirection.LEFT, player.GetState().GetDirection());
        Assert.That(player.GetState(), Is.TypeOf<PlayerStateWalk>());
    }

    [Test]
    public void PlayerDirection_RightWalkOnInputRight()
    {
        player.GetState().HandleRight();

        Assert.AreEqual(PlayerDirection.RIGHT, player.GetState().GetDirection());
        Assert.That(player.GetState(), Is.TypeOf<PlayerStateWalk>());
    }

    [Test]
    public void PlayerDirection_UpWalkOnInputUp()
    {
        player.GetState().HandleUp();

        Assert.AreEqual(PlayerDirection.UP, player.GetState().GetDirection());
        Assert.That(player.GetState(), Is.TypeOf<PlayerStateWalk>());
    }

    [Test]
    public void PlayerDirection_DownWalkOnInputDown()
    {
        player.GetState().HandleDown();

        Assert.AreEqual(PlayerDirection.DOWN, player.GetState().GetDirection());
        Assert.That(player.GetState(), Is.TypeOf<PlayerStateWalk>());
    }

    [Test]
    public void PlayerDirection_DownWalkOnConsecutiveInputDown()
    {
        player.GetState().HandleDown();
        player.GetState().HandleDown();

        Assert.AreEqual(PlayerDirection.DOWN, player.GetState().GetDirection());
        Assert.That(player.GetState(), Is.TypeOf<PlayerStateWalk>());
    }

    [Test]
    public void PlayerDirection_UpWalkOnInputDownUp()
    {
        player.GetState().HandleDown();
        player.GetState().HandleUp();

        Assert.AreEqual(PlayerDirection.UP, player.GetState().GetDirection());
        Assert.That(player.GetState(), Is.TypeOf<PlayerStateWalk>());
    }
}

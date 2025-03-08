using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerState state;

    public Animator animator;

    public BoxCollider2D leftBoxCollider;
    public BoxCollider2D topBoxCollider;
    public BoxCollider2D rightBoxCollider;
    public BoxCollider2D bottomBoxCollider;

    public float speed = 0.01f;

    private bool canPressSpace = true;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        state = new PlayerStateIdle(this, PlayerDirection.UP);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("left") || Input.GetKey(KeyCode.A))
        {
            state.handleLeft();
            //Debug.Log("LEFT!!!");
        }
        else if (Input.GetKey("right") || Input.GetKey(KeyCode.D))
        {
            state.handleRight();
            //Debug.Log("RIGHT!!!");
        }
        else if (Input.GetKey("up") || Input.GetKey(KeyCode.W))
        {
            state.handleUp();
            //Debug.Log("UP!!!");
        }
        else if (Input.GetKey("down") || Input.GetKey(KeyCode.S))
        {
            state.handleDown();
            //Debug.Log("DOWN!!!");
        }
        else
        {
            state.handleIdle();

            Debug.Log("Idling");
        }

        if (Input.GetKeyDown(KeyCode.Space) && canPressSpace)
        {
            state.handleSpace();
            canPressSpace = false;
            StartCoroutine(SpaceCooldown());
        }


        state.advanceState();
    }

    public PlayerState GetState()
    {
        return this.state;
    }

    public void setState(PlayerState s)
    {
        this.state = s;
        //Debug.Log("new state: " + state.ToString());
    }

    public void ResetAnimatorTriggers()
    {
        foreach (var param in animator.parameters)
        {
            if (param.type == AnimatorControllerParameterType.Trigger)
            {
                animator.ResetTrigger(param.name);
            }
        }
    }

    public IEnumerator SpaceCooldown()
    {
        yield return new WaitForSeconds(0.5f);
        canPressSpace = true;

        // Disable colliders
        topBoxCollider.enabled = false;
        rightBoxCollider.enabled = false;
        bottomBoxCollider.enabled = false;
        leftBoxCollider.enabled = false;
    }
}

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

    public float speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        state = new PlayerStateIdle(this, PlayerDirection.UP);
    }

    // Update is called once per frame
    void Update()
    {
        bool pressed = false;

        if (Input.GetKey("left") || Input.GetKey(KeyCode.A))
        {
            pressed = true;
            state.handleLeft();
            //Debug.Log("LEFT!!!");
        }
        else if (Input.GetKey("right") || Input.GetKey(KeyCode.D))
        {
            pressed = true;
            state.handleRight();
            //Debug.Log("RIGHT!!!");
        }
        else if (Input.GetKey("up") || Input.GetKey(KeyCode.W))
        {
            pressed = true;
            state.handleUp();
            //Debug.Log("UP!!!");
        }
        else if (Input.GetKey("down") || Input.GetKey(KeyCode.S))
        {
            pressed = true;
            state.handleDown();
            //Debug.Log("DOWN!!!");
        }

        if (Input.GetKeyDown(KeyCode.Space) && canPressSpace)
        {
            pressed = true;
            state.handleSpace();
            StartCoroutine(SpaceCooldown());
        }

        if (!pressed)
        {
            state.handleIdle();

            Debug.Log("Idling");
        }


        state.advanceState();

        pressed = false;

    }

    public void setState(PlayerState s)
    {
        this.state = s;
        //Debug.Log("new state: " + state.ToString());
    }

    private bool canPressSpace = true;

    public IEnumerator SpaceCooldown()
    {
        canPressSpace = false;
        yield return new WaitForSeconds(0.5f);
        canPressSpace = true;
    }
}

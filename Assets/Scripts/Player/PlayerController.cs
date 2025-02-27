using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerState state = new PlayerStateIdle();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("left") || Input.GetKeyDown(KeyCode.A))
        {
            state.handleLeft();
        }
        if (Input.GetKeyDown("right") || Input.GetKeyDown(KeyCode.D))
        {
            state.handleRight();
        }
        if (Input.GetKeyDown("up") || Input.GetKeyDown(KeyCode.W))
        {
            state.handleUp();
        }
        if (Input.GetKeyDown("down") || Input.GetKeyDown(KeyCode.S))
        {
            state.handleDown();
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            state.handleSpace();
        }

        state.advanceState();
    }

    public void setState(PlayerState s)
    {
        state = s;
    }
}

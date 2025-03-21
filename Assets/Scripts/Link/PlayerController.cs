using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    private ServiceLocator _serviceLocator;

    void Awake()
    {
        MessageManager.Instance.deathMessenger.Subscribe(LinkDies);
    }

    // Start is called before the first frame update
    void Start()
    {
        _serviceLocator = GameObject.Find("GameManager").GetComponent<ServiceLocator>();
        animator = GetComponent<Animator>();
        state = new PlayerStateIdle(this, PlayerDirection.UP);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("left") || Input.GetKey(KeyCode.A))
        {
            state.HandleLeft();
            //Debug.Log("LEFT!!!");
        }
        else if (Input.GetKey("right") || Input.GetKey(KeyCode.D))
        {
            state.HandleRight();
            //Debug.Log("RIGHT!!!");
        }
        else if (Input.GetKey("up") || Input.GetKey(KeyCode.W))
        {
            state.HandleUp();
            //Debug.Log("UP!!!");
        }
        else if (Input.GetKey("down") || Input.GetKey(KeyCode.S))
        {
            state.HandleDown();
            //Debug.Log("DOWN!!!");
        }
        else
        {
            state.HandleIdle();
        }

        if (Input.GetKeyDown(KeyCode.Space) && canPressSpace)
        {
            state.HandleSpace();
            canPressSpace = false;
            StartCoroutine(SpaceCooldown());
        }


        state.AdvanceState();
    }
    
    public PlayerState GetState()
    {
        return this.state;
    }

    public void SetState(PlayerState s)    
    {
        this.state = s;
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

    public void LinkDies (DeathMessage m)
    {
        _serviceLocator.AudioService.PlayEffect(_serviceLocator.AudioService.LinkDie);
        StartCoroutine("death");
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
    
    private IEnumerator death ()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("LoseScene");
    }
}

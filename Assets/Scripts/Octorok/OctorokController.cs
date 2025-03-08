using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctorokController : MonoBehaviour
{
    private OctorokState state;
    public Animator animator;

    public GameObject pelletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        state = new OctorokStateIdle(OctorokDirection.UP, this);
    }

    // Update is called once per frame
    void Update()
    {
        state.Move();
        state.AdvanceState();
    }

    public GameObject InstantiatePellet()
    {
        return Instantiate(gameObject, transform.position, Quaternion.identity);
    }

    public void SetState(OctorokState s)
    {
        state = s;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.CompareTag("MainCamera"))
        //{
        //    OctorokDirection randomDirection = (OctorokDirection)Random.Range(0, System.Enum.GetValues(typeof(OctorokDirection)).Length);
        //    SetState(new OctorokStateWalk(randomDirection, this));
        //}
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private EnemyState state;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        state.Move();
        state.AdvanceState();
    }

    public void SetState(EnemyState s)
    {
        state = s;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("MainCamera"))
        {
            SetState(new EnemyStateMove());
        }
    }
}

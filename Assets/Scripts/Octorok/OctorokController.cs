using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class OctorokController : MonoBehaviour
{
    private OctorokState _state;
    private OctorokDirection _direction;

    public Animator animator;

    public GameObject pelletPrefab;

    public float speed = 2.0f;
    private int health = 2;

    private ServiceLocator _serviceLocator;


    // Start is called before the first frame update
    void Start()
    {
        _serviceLocator = GameObject.Find("GameManager").GetComponent<ServiceLocator>();
        _direction = OctorokDirection.UP;
        _state = new OctorokStateIdle(_direction, this);
    }

    // Update is called once per frame
    void Update()
    {
        _state.Move();
        _state.AdvanceState();
    }

    public GameObject InstantiatePellet()
    {
        return Instantiate(pelletPrefab, transform.position, Quaternion.identity);
    }

    public void SetState(OctorokDirection d, OctorokState s)
    {
        _direction = d;
        _state = s;
    }
    
    public OctorokState GetState()
    {
        return _state;
    }

    public OctorokDirection GetDirection()
    {
        return _direction;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log(gameObject);
            health --;
            if (health == 0)
            {
                _serviceLocator.AudioService.PlayEffect(_serviceLocator.AudioService.EnemyDie);
                StartCoroutine("waitForSoundToFinish");
            }
            else
            {
                _serviceLocator.AudioService.PlayEffect(_serviceLocator.AudioService.EnemyDamage);
            }
        }
        //if (collision.gameObject.CompareTag("MainCamera"))
        //{
        //    OctorokDirection randomDirection = (OctorokDirection)Random.Range(0, System.Enum.GetValues(typeof(OctorokDirection)).Length);
        //    SetState(new OctorokStateWalk(randomDirection, this));
        //}
    }
    private IEnumerator waitForSoundToFinish()
    {
        yield return new WaitForSeconds(1.0f);
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pellet : MonoBehaviour
{

    private Vector2 _direction;

    public float speed = 0.10f;


    public void Instantiate(Vector2 direction)
    {
        _direction = direction;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(_direction * speed * Time.deltaTime);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //TODO: add link taking damage and collision with bushes/rocks (deletes pellet)
        if (collision.gameObject.CompareTag("Boundary"))
        {
            Destroy(this);
        }
        
    }
}

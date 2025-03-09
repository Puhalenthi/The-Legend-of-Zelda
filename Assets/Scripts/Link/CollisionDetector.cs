using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionDetector : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Rupee"))
        {
            //Publish a rupee message and use audioManager (from service locator) to play the rupee sound
            MessageManager.Instance.rupeeMessenger.SendMessage(new RupeeMessage());
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("EndGate"))
        {
            SceneManager.LoadScene("WinScene");
        }
        if (collision.gameObject.CompareTag("Pellet"))
        {
            MessageManager.Instance.damageMessenger.SendMessage(new DamageMessage(0.5f));
        }
    }
}

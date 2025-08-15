using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchPad : MonoBehaviour
{
    public float force = 5f;
    private void OnTriggerEnter2D(Collider2D coli)
    {
        if (coli.gameObject.CompareTag("Player"))
        {
            Rigidbody2D rb = coli.gameObject.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(rb.velocity.x, force);
        }
    }

    

}

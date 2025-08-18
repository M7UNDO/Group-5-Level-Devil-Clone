using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField] private float launchForce = 20f;
    public Transform groundCheck;
    public Rigidbody2D rb;
    public LayerMask jumpPadLayer;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * launchForce, ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        if (Physics2D.OverlapCircle(groundCheck.position,0.2f,jumpPadLayer))
        {
            rb.velocity = new Vector2(rb.velocity.x, launchForce);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        
    }
}

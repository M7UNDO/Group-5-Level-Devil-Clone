using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Input Fields")]
    [Space(5)]
    private InputActionAsset inputAsset;
    private InputActionMap player;
    private InputAction move;

    private Rigidbody2D rb;

    [Header("Movement")]
    [Space(5)]

    [SerializeField]
    private float moveSpeed = 5f;
    public bool isFacingRight;
    private float horizonal;


    [Header("Jump")]
    [Space(5)]

    [SerializeField]
    private float jumpPower = 5f;
    private bool canJump;
    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private LayerMask groundLayer;
    [SerializeField]
    private float cayoteTimeCount;
    private float cayoteTime = 0.2f;

    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        inputAsset = GetComponent<PlayerInput>().actions;
        player = inputAsset.FindActionMap("Player");
    }

    private void OnEnable()
    {
        player.FindAction("Jump").performed += Jump;
        move = player.FindAction("Move");
        player.Enable();
    }

    void Update()
    {
        
        Flip();
        
    }

    private void FixedUpdate()
    {
        Vector2 input = move.ReadValue<Vector2>();
        horizonal = input.x;
        rb.velocity = new Vector2(input.x * moveSpeed, rb.velocity.y);


        if (IsGrounded() && canJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            canJump = false;
        }

        print(IsGrounded());

    }

    private void Flip()
    {
        if(isFacingRight && horizonal < 0f || !isFacingRight && horizonal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    

    private void Jump(InputAction.CallbackContext context)
    {
        if (IsGrounded())
        {
            canJump = true;
        }
        
    }


    //Just used a trigger for the ground check instead of a Raycast
   /* private void OnTriggerEnter2D(Collider2D coli)
    {
        if(coli.gameObject.CompareTag("Platform"))
        {
            canJump = true;
        }
    }
   */
}

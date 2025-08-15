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

    public float jumpPower = 5f;
    private bool canJump;

    private float cayoteTimeCount;
    [SerializeField]
    private float cayoteTime = 0.2f;
    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private LayerMask groundLayer;
 
    

    

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
        if (IsGrounded())
        {
            cayoteTimeCount = cayoteTime;
        }
        else
        {
            cayoteTimeCount -= Time.deltaTime;
        }

        if (!IsGrounded())
        {
            print("cayote time started");
        }
        

        Flip();
        
    }

    private void FixedUpdate()
    {
        Vector2 input = move.ReadValue<Vector2>();
        horizonal = input.x;
        rb.velocity = new Vector2(input.x * moveSpeed, rb.velocity.y);


        if (cayoteTimeCount > 0f && canJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            canJump = false;
        }

        if(rb.velocity.y  > 0.5f)
        {
            cayoteTimeCount = 0f;
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
        if (cayoteTimeCount > 0f)
        {
            canJump = true;
        }

    }

}

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


    [Header("Jump")]
    [Space(5)]

    [SerializeField]
    private float jumpForce = 5f;
    private bool isGrounded;
    private bool canJump;
    private bool jumpQueued;
    public LayerMask jumpMask;

    

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
        
        print(isGrounded);
      
    }

    private void FixedUpdate()
    {
        Vector2 input = move.ReadValue<Vector2>();
        rb.velocity = new Vector2(input.x * moveSpeed, rb.velocity.y);


        if (jumpQueued && canJump)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            canJump = false;
            jumpQueued = false;
        }

    }
    

    private void Jump(InputAction.CallbackContext context)
    {
        jumpQueued = true;
    }


    //Just used a trigger for the ground check instead of a Raycast
    private void OnTriggerEnter2D(Collider2D coli)
    {
        if(coli.gameObject.CompareTag("Platform"))
        {
            canJump = true;
        }
    }

}

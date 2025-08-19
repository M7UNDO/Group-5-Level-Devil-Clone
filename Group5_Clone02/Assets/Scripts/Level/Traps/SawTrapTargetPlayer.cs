using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawTrapTargetPlayer : MonoBehaviour
{
    [Header("Saw Settings")]
    public float dropDistance = 5f;   // How far it drops down
    public float moveSpeed = 10f;     // Speed of movement
    public float holdTime = 1f;       // How long it stays down

    private Vector2 startPos;
    private Vector2 dropPos;
    private bool activated = false;
    private bool goingDown = false;
    private bool goingUp = false;

    private void Start()
    {
        startPos = transform.position;
        dropPos = startPos + Vector2.down * dropDistance;
    }

    public void ActivateTrap(Transform collisionTransform)
    {
        if (!activated)
        {
            activated = true;
            goingDown = true;
        }
    }

    private void Update()
    {
        if (goingDown)
        {
            // Move toward drop position
            transform.position = Vector2.MoveTowards(transform.position, dropPos, moveSpeed * Time.deltaTime);

            if (Vector2.Distance(transform.position, dropPos) < 0.05f)
            {
                goingDown = false;
                Invoke(nameof(StartGoingUp), holdTime);
            }
        }
        else if (goingUp)
        {
            // Move back up
            transform.position = Vector2.MoveTowards(transform.position, startPos, moveSpeed * Time.deltaTime);

            if (Vector2.Distance(transform.position, startPos) < 0.05f)
            {
                transform.position = startPos;
                goingUp = false;
                activated = false; // reset so it can trigger again
            }
        }
    }

    private void StartGoingUp()
    {
        goingUp = true;
    }
}

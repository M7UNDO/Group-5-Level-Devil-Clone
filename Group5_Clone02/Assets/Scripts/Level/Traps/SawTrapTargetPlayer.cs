using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawTrapTargetPlayer : MonoBehaviour
{
    [Header("Saw Settings")]
    public float dropSpeed = 10f;          // Speed of saw dropping
    public float stopAbovePlayer = 0.5f;   // How close above player it should stop
    public float resetDelay = 2f;          // Time before returning to start

    private Vector2 startPos;
    private Transform targetPlayer;
    private bool activated = false;
    private bool returning = false;

    private void Start()
    {
        startPos = transform.position;
    }

    public void ActivateTrap(Transform player) 
    {
        if (!activated && !returning)
        {
            targetPlayer = player;
            activated = true;
        }
    }

    private void Update()
    {
        if (activated && targetPlayer != null)
        {
            // Drop down towards player
            Vector2 targetPos = new Vector2(targetPlayer.position.x, targetPlayer.position.y + stopAbovePlayer);
            transform.position = Vector2.MoveTowards(transform.position, targetPos, dropSpeed * Time.deltaTime);

            // When close enough, stop + schedule reset
            if (Vector2.Distance(transform.position, targetPos) < 0.1f)
            {
                activated = false;
                Invoke(nameof(ResetTrap), resetDelay);
            }
        }
        else if (returning)
        {
            // Move back to original position
            transform.position = Vector2.MoveTowards(transform.position, startPos, dropSpeed * Time.deltaTime);

            if (Vector2.Distance(transform.position, startPos) < 0.1f)
            {
                transform.position = startPos;
                returning = false;
            }
        }
    }

    private void ResetTrap()
    {
        returning = true;
        targetPlayer = null;
    }
}

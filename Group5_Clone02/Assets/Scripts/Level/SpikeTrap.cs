using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpikeTrap : MonoBehaviour, ITrapAction
{
    [Header("Spike Settings")]
    public float popUpSpeed = 5f;                 // Speed of spikes rising
    public Vector2 popUpOffset = new Vector2(0, 1f); // How far spikes rise

    [Header("Retract Settings")]
    public float holdTime = 1f;                   // Time to stay up
    public float retractSpeed = 5f;               // Speed of retracting

    private Vector2 startPos;
    private Vector2 targetPos;
    private bool activated = false;
    private bool retracting = false;

    private void Start()
    {
        startPos = transform.position;
        targetPos = startPos + popUpOffset;
    }

    public void ActivateTrap()
    {
        if (!activated) // Prevent re-trigger while already active
        {
            activated = true;
        }
    }

    private void Update()
    {
        if (activated && !retracting)
        {
            // Move towards pop-up position
            transform.position = Vector2.MoveTowards(transform.position, targetPos, popUpSpeed * Time.deltaTime);

            // If close enough to target, start countdown to retract
            if (Vector2.Distance(transform.position, targetPos) < 0.05f)
            {
                Invoke(nameof(StartRetract), holdTime);
            }
        }
        else if (retracting)
        {
            // Move back to original position
            transform.position = Vector2.MoveTowards(transform.position, startPos, retractSpeed * Time.deltaTime);

            // Reset once it's back down
            if (Vector2.Distance(transform.position, startPos) < 0.05f)
            {
                transform.position = startPos;
                activated = false;
                retracting = false;
            }
        }
    }

    private void StartRetract()
    {
        retracting = true;
    }
}
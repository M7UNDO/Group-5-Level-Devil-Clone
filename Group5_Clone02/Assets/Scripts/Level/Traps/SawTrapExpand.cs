using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawTrapExpand : MonoBehaviour, ITrapAction
{
    [Header("Expand Settings")]
    public float expandSpeed = 5f;             // How fast it grows
    public Vector2 expandedScale = new Vector2(2f, 2f); // Final size

    [Header("Retract Settings")]
    public float holdTime = 1f;                // How long it stays expanded
    public float retractSpeed = 5f;            // How fast it shrinks back

    private Vector2 originalScale;
    private bool activated = false;
    private bool retracting = false;

    private void Start()
    {
        originalScale = transform.localScale;
    }

    public void ActivateTrap()
    {
        if (!activated) // only trigger once
        {
            activated = true;
        }
    }

    private void Update()
    {
        if (activated && !retracting)
        {
            // Expand
            transform.localScale = Vector2.Lerp(transform.localScale, expandedScale, expandSpeed * Time.deltaTime);

            // When almost at target size, start the retraction countdown
            if (Vector2.Distance(transform.localScale, expandedScale) < 0.05f)
            {
                Invoke(nameof(StartRetract), holdTime);
            }
        }
        else if (retracting)
        {
            // Shrink back
            transform.localScale = Vector2.Lerp(transform.localScale, originalScale, retractSpeed * Time.deltaTime);

            // If close enough, stop retracting
            if (Vector2.Distance(transform.localScale, originalScale) < 0.05f)
            {
                transform.localScale = originalScale;
                activated = false;  // Reset so it can trigger again
                retracting = false;
            }
        }
    }

    private void StartRetract()
    {
        retracting = true;
    }
}
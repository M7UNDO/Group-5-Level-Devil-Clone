using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatTrapTrigger : MonoBehaviour
{
    public GameObject trap; // Assign your trap GameObject here
    public string playerTag = "Player";
    public bool triggerOnce = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(playerTag))
        {
            // Check if trap supports targeting a player
            SawTrapTargetPlayer sawTrap = trap.GetComponent<SawTrapTargetPlayer>();
            if (sawTrap != null)
            {
                sawTrap.ActivateTrap(collision.transform);
                if (triggerOnce) Destroy(gameObject); // optional: one-time use trigger
                return;
            }

            // Otherwise, fallback to generic trap
            ITrapAction trapAction = trap.GetComponent<ITrapAction>();
            if (trapAction != null)
            {
                trapAction.ActivateTrap();
                if (triggerOnce) Destroy(gameObject);
            }
        }
    }
}

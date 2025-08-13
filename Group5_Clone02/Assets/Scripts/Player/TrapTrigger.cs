using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTrigger : MonoBehaviour
{
    public GameObject trap; 
    public string playerTag = "Player";

    private bool hasTriggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!hasTriggered && collision.CompareTag(playerTag))
        {
            hasTriggered = true;

            // If trap has an Animator
            Animator anim = trap.GetComponent<Animator>();
            if (anim != null)
            {
                anim.SetTrigger("Activate");
            }

            // If trap has a movement script
            ITrapAction action = trap.GetComponent<ITrapAction>();
            if (action != null)
            {
                action.ActivateTrap();
            }
        }
    }
}
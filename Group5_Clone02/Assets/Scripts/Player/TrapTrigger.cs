using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTrigger : MonoBehaviour
{
    public GameObject trap; // Link the trap prefab here
    public float delay = 0f; // Time before trap activates

    private bool activated = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!activated && other.CompareTag("Player"))
        {
            activated = true;
            Invoke(nameof(ActivateTrap), delay);
        }
    }

    void ActivateTrap()
    {
        if (trap != null && trap.TryGetComponent<ITrap>(out var trapComponent))
        {
            trapComponent.Activate();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RockProjectile : MonoBehaviour
{
  
    private void OnCollisionEnter2D(Collision2D coli)
    {
        if (coli.gameObject.CompareTag("Player"))
        {
            HitObstacle hitObstacle = coli.gameObject.GetComponent<HitObstacle>();
            hitObstacle.StartCoroutine(hitObstacle.HandleDeath());

        }
    }
}

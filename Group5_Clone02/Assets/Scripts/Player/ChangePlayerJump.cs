using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayerJump : MonoBehaviour
{
    [SerializeField] private float originalJumpPower;
    [SerializeField] private float temporaryJumpPower;
    private void OnCollisionEnter2D(Collision2D coli)
    {
        if (coli.gameObject.CompareTag("Player"))
        {
            originalJumpPower = coli.gameObject.GetComponent<PlayerMovement>().jumpPower;
            coli.gameObject.GetComponent<PlayerMovement>().jumpPower = temporaryJumpPower;

        }
    }

    private void OnCollisionExit2D(Collision2D coli)
    {
        if (coli.gameObject.CompareTag("Player"))
        {
            coli.gameObject.GetComponent<PlayerMovement>().jumpPower = originalJumpPower;

        }
    }
}

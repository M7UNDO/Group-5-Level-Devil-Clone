using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlatformSwitch : MonoBehaviour
{
    [SerializeField] private GameObject platformTrigger;
    [SerializeField] private GameObject platform;

    private void OnCollisionEnter2D(Collision2D coli)
    {
        if (coli.gameObject.CompareTag("Player"))
        {
            platformTrigger.SetActive(true);
            platform.SetActive(true);
        }
    }

    private void OnCollisionExit2D(Collision2D coli)
    {
        if (coli.gameObject.CompareTag("Player"))
        {
            platformTrigger.SetActive(false);
            platform.SetActive(false);
        }
    }
}

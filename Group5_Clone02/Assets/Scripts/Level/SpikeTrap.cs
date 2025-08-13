using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpikeTrap : MonoBehaviour, ITrapAction
{
    public float popUpSpeed = 5f;
    public Vector2 popUpOffset = new Vector2(0, 1f);

    private Vector2 startPos;
    private Vector2 targetPos;
    private bool activated = false;

    private void Start()
    {
        startPos = transform.position;
        targetPos = startPos + popUpOffset;
    }

    public void ActivateTrap()
    {
        activated = true;
    }

    private void Update()
    {
        if (activated)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPos, popUpSpeed * Time.deltaTime);
        }
    }
}
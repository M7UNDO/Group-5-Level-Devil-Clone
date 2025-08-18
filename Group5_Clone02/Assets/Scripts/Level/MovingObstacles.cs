using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacles : MonoBehaviour
{
    private Vector2 targetPosition;
    [SerializeField] private Vector2 pointA;
    [SerializeField] private Vector2 pointB;
    [SerializeField] private float moveSpeed;
    private Vector2 motion;
    private Vector3 lastPosition;
    
    
    void Start()
    {
        targetPosition = pointB;
        lastPosition = transform.position;


    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        motion = transform.position - lastPosition;
        lastPosition = transform.position;

        //Target Switching

        if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
        {
            targetPosition = targetPosition == pointA ? pointB : pointA;
        }



    }
}

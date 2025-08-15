using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingObstacle : MonoBehaviour
{
    public float rotationSpeed = 50f; // Degrees per second

    void Update()
    {
        // Rotate around the Y-axis in local space
        transform.Rotate(0, 0, rotationSpeed, Space.Self);

        // Or, rotate around the X-axis in world space
        // transform.Rotate(rotationSpeed * Time.deltaTime, 0, 0, Space.World); 
    }
}

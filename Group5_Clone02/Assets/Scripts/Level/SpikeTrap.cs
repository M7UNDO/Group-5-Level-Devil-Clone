using System.Collections;
using System.Collections.Generic;
using UnityEngine;


 public class SpikeTrap : MonoBehaviour, ITrap
 {
       public float speed = 5f;
       public float riseHeight = 2f;
       private Vector3 startPos;
       private bool rising = false;
   
       void Start()
       {
           startPos = transform.position;
       }
   
       public void Activate()
       {
           rising = true;
       }
   
       void Update()
       {
           if (rising)
           {
               transform.position = Vector3.MoveTowards(transform.position, startPos + Vector3.up * riseHeight, speed * Time.deltaTime);
           }
    }
}
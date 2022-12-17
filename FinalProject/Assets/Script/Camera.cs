using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
public Transform target ;
// The speed with which the camera will be following .
public float smoothing = 5f;
// The initial offset from the target .
 void Start ()
 {
 // Calculate the initial offset .
 }


 void LateUpdate ()
 {
        // Create a postion the camera is aiming for
        // based on the offset from the target .

        // Smoothly interpolate between the camera ’s
        // current position and it ’s target position .
        if (target != null)
        {
            transform.position = new Vector3(target.position.x + 3, target.position.y + 4, transform.position.z);
        }
    }
}


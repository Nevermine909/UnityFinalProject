using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
public Transform target ;
// The speed with which the camera will be following .
public float smoothing = 5f;
// The initial offset from the target .
Vector3 offset ;
 void Start ()
 {
 // Calculate the initial offset .
 offset = new Vector3 (5 ,4 , -10) ;
 }


 void LateUpdate ()
 {
 // Create a postion the camera is aiming for
 // based on the offset from the target .
 Vector3 FolowCam = target.position + offset ;

 // Smoothly interpolate between the camera ’s
 // current position and it ’s target position .
 transform.position = Vector3.Lerp ( transform.position , FolowCam , smoothing * Time.deltaTime );

    }
}


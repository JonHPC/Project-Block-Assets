using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;//gets the position of the target of the camera

    public float smoothSpeed = 0.125f;//the amount the camera movement is smoothed
    public Vector3 offset;//the camera offset from the target
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        Vector3 desiredPosition = target.position + offset;//sets a new Vector3 with the desired offset
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);//lerps the camera between the current location and the desired location
        transform.position = smoothedPosition;

	}
}

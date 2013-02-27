using UnityEngine;
using System.Collections;

/**
 * A class that enables the camera to follow the 
 * player across the level. Note that this code was based
 * off the SmoothFollow2D in the Unity Standard Assets
 * @author Jeff Einhaus
 **/ 
public class CameraFollow : MonoBehaviour {
	
	// transform that the camera will follow
	public Transform target;
	// smoothing factor for camera movement
	public float smoothValue = 0.3f;
	// transform that follows the player (camera)
	private Transform thisTransform;
	// holds velocity of moving transform
	public Vector2 vel;
	

	// Use this for initialization
	void Start () {
		thisTransform = transform;
	}
	
	// Update is called once per frame
	void Update () {
		// Stores damped x position
		float xPos = Mathf.SmoothDamp( thisTransform.position.x, 
			target.position.x, ref vel.x, smoothValue);
		// Stores damped y position
		float yPos = Mathf.SmoothDamp( thisTransform.position.y, 
			target.position.y, ref vel.y, smoothValue);
		// updates position
		thisTransform.position = new Vector3(xPos,yPos,thisTransform.position.z);
	}
}

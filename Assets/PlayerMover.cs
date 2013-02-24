using UnityEngine;
using System.Collections;

public class PlayerMover : MonoBehaviour {
	
	public float maxVelocity = 10.0f;
	public float jumpVelocity = 10.0f;
	public float gravity = 10.0f;
	public bool moveLeft = Input.GetKey (KeyCode.LeftArrow);
	public bool moveRight = Input.GetKey (KeyCode.RightArrow);
	
	private Vector3 mover = Vector3.zero;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		CharacterController controller = GetComponent<CharacterController>();
		bool moveLeft = Input.GetKey (KeyCode.LeftArrow);
	    bool moveRight = Input.GetKey (KeyCode.RightArrow);
		
		if(controller.isGrounded) {
			mover = new Vector3(Input.GetAxis ("Horizontal"),Input.GetAxis("Vertical"),0);
			mover = transform.TransformDirection (mover);
			mover *= maxVelocity;
			if(Input.GetButton ("Jump"))
				mover.y = jumpVelocity;
			
		}
		
		if(moveLeft)
			mover.x = maxVelocity;
		else if(moveRight)
			mover.x = - maxVelocity;
		
		
		mover.y -= gravity * Time.deltaTime;
		controller.Move (mover*Time.deltaTime);
	
	}
}

using UnityEngine;
using System.Collections;


/**
 * Class that uses a CharacterController to 
 * create lateral movements and jumping for the
 * main character
 * Author - Jeff Einhaus
 **/ 
public class PlayerMover : MonoBehaviour {
	
	// Max lateral velocity for player
	public float maxVelocity = 10.0f;
	// jump velocity for player
	public float jumpVelocity = 10.0f;
	// gravity to dictate player falling back down after jump
	public float gravity = 10.0f;
	// determines whether or not game has been started
	public bool gameRunning = false;
	// movement vector for character that will be updated every frame
	private Vector3 mover = Vector3.zero;
	// stores beginning x coordinate
	public float xStart = -129.0f;
	// stores beginning y coordinate
	public float yStart = 11.0f;
	// stores y height where player falls off
	public float yDeath = -10.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// ensures that character can't move unless you've hit play
		if(gameRunning){
			
			CharacterController controller = GetComponent<CharacterController>();
			bool moveLeft = Input.GetKey (KeyCode.LeftArrow);
		    bool moveRight = Input.GetKey (KeyCode.RightArrow);
		
			// if the player is touching ground (buildings or platforms)
			if(controller.isGrounded) {
				// sets move direction depending on how player is facing
				mover = new Vector3(Input.GetAxis ("Horizontal"),Input.GetAxis("Vertical"),0);
				mover = transform.TransformDirection (mover);
				mover *= maxVelocity;
				//if Jump button is hit (space bar)
				if(Input.GetButton ("Jump"))
					// y component of movement vector becomes jumpVelocity
					mover.y = jumpVelocity;
			
			}
		
			// if player is trying to move, update x component of velocity
			if(moveLeft)
				mover.x = - maxVelocity;
			else if(moveRight)
				mover.x =  maxVelocity;
		
		    // ensure gravity is acting on player at all times
			mover.y -= gravity * Time.deltaTime;
			// moves player according to mover vector calculated above
			controller.Move (mover*Time.deltaTime);
		
			// if player falls below level he is snapped back to beginning
			if(transform.position.y < yDeath)
				transform.position = new Vector3(xStart,yStart,0);
		
			// Ensures that z position is always zero at the end of an update
			transform.position = new Vector3(transform.position.x,transform.position.y, 0);
		}
	
	}
	
	// Sets gameRunning to true so player can move
	void StartGame(){
		gameRunning = true;
	}
}

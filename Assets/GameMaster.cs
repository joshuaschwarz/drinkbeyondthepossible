/**
 * Methods that control the general background functionality of the game
 * Author: Joseph Satterfield
 **/

using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {
	
	//An array of all of the blocks that should wobble as the player gets drunk
	private GameObject[] wobbleBlocks;
	
	//An indication of which direction the blocks should wobble
	private bool angle = true;
	
	//The current angle of the blocks
	private float ang = 0;
	
	//The main camera of the scene
	private GameObject mainCamera;
	
	//How far the main camera has moved from its origin
	private float distance = 0;
	
	//The direction that the main camera will move in
	private bool direction = true;
	
	//How far the camera has roatated
	private float cameraCurrentAngle = 0f;
	
	//The direction the camera is moving;
	private bool cameraAng = false;
	
	//An indication of whether the start button has been pressed
	public bool gameRunning = true;
	
	//The current score of the player in BAC
	public float score = 0.16f;
	
	//The score at which the first stage of drunkeness should take effect
	public float stage1 = .08f;
	
	//How much the blocks should wobble at the first stage
	public float stage1Wobble = .5f;
	
	//How fast the blocks should wobble at stage 1
	public float stage1WobbleSpeed = 1.0f;
	
	//The score at which the second stage of drunkeness should take effect
	public float stage2 = .16f;
	
	//How much the blocks should wobble at the second stage
	public float stage2Wobble = .65f;
	
	//How fast the blocks should wobble at stage 2
	public float stage2WobbleSpeed = 1.5f;
	
	//How far the camera should move in stage 2 &3
	public float cameraShake2 = .25f;
	
	//How fast the camera should move in stage 2
	public float cameraSpeed2 = .7f;
	
	//The score at which the third stage of drunkeness should take effect
	public float stage3 = .24f;
	
	//How much the blocks should wobble at the 3 stage
	public float stage3Wobble = .8f;
	
	//How fast the blocks should wobble at stage 2
	public float stage3WobbleSpeed = 2.0f;
	
	//How fast the camera should move in stage 3
	public float cameraSpeed3 = .9f;
	
	//The score at which the fourth stage of drunkeness should take effect
	public float stage4 = .32f;
	
	//How much the blocks should wobble at the 4 stage
	public float stage4Wobble = .75f;
	
	//How fast the blocks should wobble at stage 2
	public float stage4WobbleSpeed = 2.5f;
	
	//How far the camera should move in stage 4
	public float cameraShake4 = .4f;
	
	//How fast the camera should move in stage 4
	public float cameraSpeed4 = 2.5f;
	
	//How far the camera should roll
	public float cameraRoll = .8f;
	
	//How fast the camera should roll
	public float cameraRollSpeed = .1f;
	
	// Use this for initialization
	void Start () {
		wobbleBlocks = GameObject.FindGameObjectsWithTag("wobble"); //Fills the array with all wobbling blocks
		mainCamera = GameObject.Find ("Main Camera"); //Identifies the camera
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(gameRunning) //Checks to see if the user has started the game
		{
			if(GetScore () >= stage1 && GetScore () < stage2) //Executes the actions assocciated with the first stage of drunkeness
			{
				TurnPaddles (stage1Wobble, stage1WobbleSpeed);
			}
			
			if(GetScore () >= stage2 && GetScore () < stage3) //Executes the actions assocciated with the second stage of drunkeness
			{
				TurnPaddles (stage2Wobble, stage2WobbleSpeed);
				ShakeCamera (cameraShake2, cameraSpeed2);
			}
		
			if(GetScore () >= stage3 && GetScore () <=stage4) //Executes the actions assocciated with the third stage of drunkeness
			{
				TurnPaddles (stage3Wobble, stage3WobbleSpeed);
				ShakeCamera (cameraShake2, cameraSpeed3);
			}
			
			if(GetScore () >= stage4)
			{
				TurnPaddles (stage4Wobble, stage4WobbleSpeed);
				ShakeCamera (cameraShake4, cameraSpeed4);
				RollCamera (cameraRoll, cameraRollSpeed);
			}
			if(GetScore () < stage4 && mainCamera.transform.eulerAngles.z != 0)
				mainCamera.transform.eulerAngles = new Vector3(0,0,0);
		}
	}
	
	///<summary>
	///Turns the blocks to a specified angle at a specified speed
	///</summary>
	///<param name = "maxAngle">
	///The maximum angle that the blocks can turn to
	///</param>
	///<param name="speed">
	///How fast the platforms move
	///</param>>
	void TurnPaddles (float maxAngle, float speed) {
		foreach(GameObject go in wobbleBlocks)  //Iterates through each of the rotating blocks
		{
			if(angle) //Rotates the blocks clockwise
			{
				go.transform.RotateAroundLocal (Vector3.forward, speed * Time.fixedDeltaTime);
			}
			else  //Rotates the blocks counter clockwise
			{
				go.transform.RotateAroundLocal (Vector3.forward, -speed * Time.fixedDeltaTime);
			}
		}
		if(angle)
			ang += speed * Time.fixedDeltaTime;
		else
			ang -= speed * Time.fixedDeltaTime;
		if(ang >= maxAngle)
			angle = false;
		else if(ang <= -maxAngle)
			angle = true;
	}
	
	///<summary>
	///Shakes the camera a certain distance and speed
	///</summary>
	///<param name="displacement">
	///The maximum distance the camera can move
	///</param>
	///<param name="speed">
	///How fast the camera will move
	///</param>
	void ShakeCamera (float displacement, float speed) {
		if(direction)
		{
			mainCamera.transform.Translate (Vector3.up * speed * Time.fixedDeltaTime, Space.World);
			distance += speed * Time.fixedDeltaTime;
		}
		else
		{
			mainCamera.transform.Translate (Vector3.up * -speed * Time.fixedDeltaTime, Space.World);
			distance -= speed * Time.fixedDeltaTime;
		}
		if(distance >= displacement)
			direction = false;
		else if(distance <= -displacement)
			direction = true;
	}
	
	///<summary>
	///Rolls the camera back and forth
	///</summary>
	///<param name="cameraAngle">
	///The furthest the camera can rotate
	///</param>
	///<param name="speed">
	///How fast the camera will roatate
	///</param>
	void RollCamera(float cameraAngle, float speed)
	{
		if(cameraAng)
		{
			mainCamera.transform.RotateAroundLocal (Vector3.forward, speed*Time.fixedDeltaTime);
			cameraCurrentAngle += speed*Time.fixedDeltaTime;
			Debug.Log ("CW");
		}
		
		if(!cameraAng)
		{
			mainCamera.transform.RotateAroundLocal (Vector3.forward, -speed*Time.fixedDeltaTime);
			cameraCurrentAngle -= speed*Time.fixedDeltaTime;
			Debug.Log ("CCW");
		}
		if(cameraCurrentAngle >= cameraAngle)
			cameraAng = false;
		if(cameraCurrentAngle <= -cameraAngle)
			cameraAng = true;
		
	}
	
	///<summary>
	///Increments the score by a given amount
	///</summary>
	///<param name="increment">
	///The amount to increase the score by
	///</param>
	void IncrementScore (float increment){
		score += increment;
	}
	
	///<summary>
	///Returns the current score
	///</summary>
	public float GetScore (){
		return score;
	}
	
	//Sets the UI layout
	void OnGUI(){
		if(gameRunning)
			// Draws a score display on the screen
			GUI.Box(new Rect(.80f*Screen.width,.03f*Screen.height,.15f*Screen.width,.07f*Screen.height), "Score: " + GetScore () + " BAC");
	}
	
	///<summary>
	///Starts the game sequence
	///</summary>
	void StartGame()
	{
		gameRunning = true;
	}
}

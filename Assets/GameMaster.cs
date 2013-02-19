/**
 * Methods that control the general background functionality of the game
 * Author: Joseph Satterfield
 **/

using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {
	
	private GameObject[] wobbleBlocks;
	public float score = 0.16f;
	private bool angle = true;
	private float ang = 0;
	private GameObject mainCamera;
	private float distance = 0;
	private bool direction = true;
	
	// Use this for initialization
	void Start () {
		Debug.Log ("Running");
		wobbleBlocks = GameObject.FindGameObjectsWithTag("wobble");
		mainCamera = GameObject.Find ("Main Camera");
		Debug.Log(wobbleBlocks.Length);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(GetScore () >= 0.08f && GetScore () < 0.16f)
		{
			TurnPaddles (1.5f, 1.0f);
		}
		
		if(GetScore () >= 0.16f && GetScore () < 0.24f)
		{
			TurnPaddles (3.0f, 1.2f);
			ShakeCamera (0.25f, 0.5f);
		}
		
		if(GetScore () >= 0.24f)
		{
			TurnPaddles (4.0f, 1.3f);
			ShakeCamera (0.25f, 0.9f);
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
		foreach(GameObject go in wobbleBlocks)
		{
			if(angle)
			{
				go.transform.RotateAroundLocal (Vector3.forward, speed * Time.fixedDeltaTime);
				ang += speed * Time.fixedDeltaTime;
			}
			else
			{
				go.transform.RotateAroundLocal (Vector3.forward, -speed * Time.fixedDeltaTime);
				ang -= speed * Time.fixedDeltaTime;
			}
			if(ang >= maxAngle)
				angle = false;
			else if(ang <= -maxAngle)
				angle = true;
		}
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
			mainCamera.transform.Translate (Vector3.up * speed * Time.fixedDeltaTime);
			distance += speed * Time.fixedDeltaTime;
			Debug.Log ("Distance " + distance);
		}
		else
		{
			mainCamera.transform.Translate (Vector3.up * -speed * Time.fixedDeltaTime);
			distance -= speed * Time.fixedDeltaTime;
		}
		if(distance >= displacement)
			direction = false;
		else if(distance <= -displacement)
			direction = true;
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
		GUI.Box(new Rect(.80f*Screen.width,.03f*Screen.height,.15f*Screen.width,.07f*Screen.height), "Score: " + GetScore () + " BAC");
	}
	
}

/**
 * Displays the main menu of the game
 * Author: Joseph Satterfield
 **/
using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	
	//The gamemaster object
	private GameObject master;
	
	//The charcter controlled by the player
	private GameObject player;
	
	//Has the player pressed the start button
	private bool gameRunning = false;
	
	//Has the player entered the jail?
	private bool isInJail = false;

	// Use this for initialization
	void Start () {
		master = GameObject.Find ("Game Master");
		player = GameObject.Find ("player");
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	//Sets the GUI Layout
	void OnGUI()
	{
		if(!gameRunning)  //Checks to see if the game is running
		{
		if(GUI.Button (new Rect(.5f*Screen.width - 30, .5f*Screen.height, 60f, 20f), "Play"))  //Creates a gui button and monitors if it is pressed
			{
				gameRunning = true;
				master.SendMessage("StartGame");
				player.SendMessage("StartGame");
			}
		}
		
		if(isInJail)
		{
			GUI.Box (new Rect(.7f*Screen.width - .1f*Screen.width, .5f*Screen.height - .05f*Screen.height, .2f*Screen.width, .1f*Screen.width),
				"Game Over");
		}
	}
	
	//Designates that the player is in jail
	void setInJail()
	{
		isInJail = true;
	}
}

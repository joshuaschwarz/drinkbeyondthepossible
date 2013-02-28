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
	
	//The game over screen
	public Texture2D gameOver;

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
				gameRunning = true; //Removes the button
				master.SendMessage("StartGame");  //Starts the gamemaster
				player.SendMessage("StartGame");  //Starts the player
			}
		}
		
		if(isInJail)
		{
			GUI.Box (new Rect(.5f*Screen.width - .1f*Screen.width, .7f*Screen.height - .05f*Screen.height, .2f*Screen.width, .1f*Screen.width),
				gameOver);  //The game over screen
		}
	}
	
	//Designates that the player is in jail
	void setInJail()
	{
		isInJail = true;
	}
}

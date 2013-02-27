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
	}
}

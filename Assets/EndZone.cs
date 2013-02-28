//Andrew Hale
//Project 2, 2-28-13
using UnityEngine;
using System.Collections;

public class EndZone : MonoBehaviour {
	public static int xJail = -185;//x coordinate of the jail
	public static int yJail = 63;//y coordinate of the jail
	public static int zJail = 0;//z coordinate of the jail
	//The x coordinate of the good ending
	public int xWin = 0;
	//The y coordinate of the good ending
	public int yWin = 0;
	//The z coordinate of the good ending
	public int zWin = 0;
	//Whether or not the player has collected enough beers to get the good ending
	public bool hasWon = false;
	private GameObject menuGUI;
	
	void Start()
	{
		renderer.enabled = false;//we don't want to actually see the endzone, just move the player
		menuGUI = GameObject.Find ("Menu");
	}
	
	
	
	void OnTriggerEnter (Collider other) {
	    if(other.tag == "Player"){//check if the player has reached the endzone	
			if(!hasWon)
			{
				other.transform.position = new Vector3(xJail,yJail,zJail);//send to jail
				menuGUI.SendMessage ("setInJail");
			}
			if(hasWon)	
			{
				other.transform.position = new Vector3(xWin,yWin,zWin);//send to good ending
				hasWon = false;
			}
			GameObject.Find ("Police").SendMessage ("StopOfficer");//tell the enemy to stop
		}
	}
	
	//Set whether or not the player has collected the required amount of beers
	void setWinState (bool state)
	{
		hasWon = state;
	}
}

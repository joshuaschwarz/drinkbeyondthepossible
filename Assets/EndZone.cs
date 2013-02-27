using UnityEngine;
using System.Collections;

public class EndZone : MonoBehaviour {
	public int xJail = -140;
	public int yJail = 14;
	public int zJail = 0;
	//The x coordinate of the good ending
	public int xWin = 0;
	//The y coordinate of the good ending
	public int yWin = 0;
	//The z coordinate of the good ending
	public int zWin = 0;
	//Whether or not the player has collected enough beers to get the good ending
	public bool hasWon = false;
	
	void Start()
	{
		renderer.enabled = false;
	}
	
	
	
	void OnTriggerEnter (Collider other) {
	    if(other.tag == "Player"){
			if(!hasWon)
				other.transform.position = new Vector3(xJail,yJail,zJail);
			if(hasWon)	
			{
				other.transform.position = new Vector3(xWin,yWin,zWin);
				hasWon = false;
			}
		}
	}
	
	//Set whether or not the player has collected the required amount of beers
	void setWinState (bool state)
	{
		hasWon = state;
	}
}

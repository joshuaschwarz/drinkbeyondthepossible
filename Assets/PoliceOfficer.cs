/**
 * Methods that control the AI Police Officer that chases the player
 * Author: Joshua Schwarz
 **/
using UnityEngine;
using System;
using System.Collections.Generic;

	public class PoliceOfficer :MonoBehaviour
	{
		GameObject Police;
		public List<Vector3> playerVectors = new List<Vector3>();
		private bool go = false; //police officer won't start moving until the player starts running away
		private bool enoughActions = false; //officer also will wait until he has a decent number of actions after he respawns
		private int delayNumberOfPlayerVectorsAfterRespawn = 100; 
		private bool stopOfficer = false; //prevent the officer from being nearby and chasing you after he catches you or you win/lose
		private GameObject menuGui;
	
		
		private float initialXPosition = PlayerMover.xStart; 
		private float initialYPosition = PlayerMover.yStart + 1000; //put the officer off screen until he starts following the player

		public PoliceOfficer ()
		{
		}
		
		// Use this for initialization
		void Start () {
		Police = GameObject.Find ("Police");
		menuGui = GameObject.Find ("Menu");
		}
		
		// Update is called once per frame
		void Update () {
			//vectors for stationary player should be ignored
			while(playerVectors.Count > 0 && Police.transform.position == playerVectors[0])
			{
				playerVectors.RemoveAt(0);
			}
		
			if(playerVectors.Count > delayNumberOfPlayerVectorsAfterRespawn)
			{
				enoughActions = true;	
			}
		
			if(go && enoughActions && stopOfficer == false && playerVectors.Count > 0)
			{
				Police.transform.position = playerVectors[0];
				playerVectors.RemoveAt(0);
			}
		}
		
		//if the player collides with the officer, send player to jail and stop officer
		void OnTriggerEnter (Collider other) {
	    if(other.tag == "Player"){
				menuGui.SendMessage ("setInJail");
				other.transform.position = new Vector3(EndZone.xJail,EndZone.yJail,EndZone.zJail);
				StopOfficer ();
			}
		}
	
		//reset the officer (place offscreen)
		//and prevent the officer from continuting to chase you via the stopOfficer flag
		void StopOfficer()
		{
			stopOfficer = true;	
			ResetOfficer();
		}
	
		//every time the player moves, his position is sent to the AI so that he can trace the player's path
		void TrackPlayer (Vector3 v){
			if(playerVectors.Count == 0)//if there are no vectors yet, no need to compare to the last vector
				playerVectors.Add (v);
			else if(playerVectors[playerVectors.Count - 1] != v)	//exclude duplicate vectors in a row
				playerVectors.Add(v);
		}	
	
		//this message is sent to the officer when the player dies.
		//it hides him off screen and deletes old player tracking data
		void ResetOfficer()
		{
			Police.transform.position = new Vector3(initialXPosition,initialYPosition,0);
			playerVectors.Clear ();
			enoughActions = false;
		}
	
		//this message is sent to the officer when the player has his first beer.
		void StartOfficer()
		{
			go = true;
		}
	}
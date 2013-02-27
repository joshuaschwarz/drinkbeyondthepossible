using UnityEngine;
using System;
using System.Collections.Generic;

	public class PoliceOfficer :MonoBehaviour
	{
		GameObject Police;
		public List<Vector3> playerVectors = new List<Vector3>();
		private bool go = false; //police officer won't start moving until the player starts running away
		
		private float initialXPosition = PlayerMover.xStart;
		private float initialYPosition = PlayerMover.yStart + 1000; //put the officer off screen until he starts following the player
	
		public PoliceOfficer ()
		{
		}
		
		// Use this for initialization
		void Start () {
		Police = GameObject.Find ("Police");
		}
		
		// Update is called once per frame
		void Update () {
			//vectors for stationary player should be ignored
			while(playerVectors.Count > 0 && Police.transform.position == playerVectors[0])
			{
				playerVectors.RemoveAt(0);
			}
		
			if(go && playerVectors.Count > 0)
			{
				Police.transform.position = playerVectors[0];
				playerVectors.RemoveAt(0);
			}
			else
			{
				if(playerVectors.Count > 100)
				{
					go = true;	
				}
			}
		}
		
		void TrackPlayer (Vector3 v){
			playerVectors.Add(v);
		}	
	
		void ResetOfficer()
		{
			Police.transform.position = new Vector3(initialXPosition,initialYPosition,0);
			go = false;
			playerVectors.Clear ();
		}
	}
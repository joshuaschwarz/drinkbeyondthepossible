using UnityEngine;
using System;
using System.Collections.Generic;

	public class PoliceOfficer :MonoBehaviour
	{
		GameObject Police;
		public List<Vector3> playerVectors = new List<Vector3>();
		private bool go = false; //police officer won't start moving until the player starts running away
		private bool enoughActions = false;
		
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
		
			if(playerVectors.Count > 100)
			{
				enoughActions = true;	
			}
		
			if(go && enoughActions && playerVectors.Count > 0)
			{
				Police.transform.position = playerVectors[0];
				playerVectors.RemoveAt(0);
			}
		}
		
		void TrackPlayer (Vector3 v){
			if(playerVectors.Count == 0)
				playerVectors.Add (v);
			if(playerVectors[playerVectors.Count - 1] != v)
				playerVectors.Add(v);
		}	
	
		void ResetOfficer()
		{
			Police.transform.position = new Vector3(initialXPosition,initialYPosition,0);
			playerVectors.Clear ();
			enoughActions = false;
		}
	
		void StartOfficer()
		{
			go = true;
		}
	}
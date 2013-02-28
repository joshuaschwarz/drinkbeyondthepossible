//Andrew Hale
//Project 2, 2-28-13
using UnityEngine;
using System.Collections;

public class Beer : MonoBehaviour {
	GameObject master;//The gamemaster we tell to adjust the score
	GameObject Police;//The enemy object
	public float score = 0.05f;//the value to increase the score

	// Use this for initialization
	void Start () {
		master = GameObject.Find ("Game Master");//these will always be the same
		Police = GameObject.Find ("Police");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter (Collider other) {
    if(other.tag == "Player"){
			master.SendMessage ("IncrementScore", score);//tell the gamemaster to adjust score
			Police.SendMessage("StartOfficer");//tell the enemy to start chasing the player
			Object.Destroy(this.gameObject);//remove the powerup
		}
}
}

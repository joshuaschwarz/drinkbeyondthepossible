//Andrew Hale
//Project 2, 2-28-13
using UnityEngine;
using System.Collections;

public class Coffee : MonoBehaviour {
	GameObject master;//The gamemaster we tell to adjust the score
	public float score = -0.05f;//negative value to decrement score

	// Use this for initialization
	void Start () {
		master = GameObject.Find ("Game Master");//We're always going to need the game master
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter (Collider other) {//Check for collision
    if(other.tag == "Player"){//if it is the player...
			master.SendMessage ("IncrementScore", score);//tell master to adjust score
			Object.Destroy(this.gameObject);//remove the powerdown
		}
}
}

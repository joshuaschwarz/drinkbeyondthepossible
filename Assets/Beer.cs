using UnityEngine;
using System.Collections;

public class Beer : MonoBehaviour {
	GameObject master;
	GameObject Police;
	public float score = 0.05f;

	// Use this for initialization
	void Start () {
		master = GameObject.Find ("Game Master");
		Police = GameObject.Find ("Police");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter (Collider other) {
    if(other.tag == "Player"){
			master.SendMessage ("IncrementScore", score);
			Police.SendMessage("StartOfficer");
			Object.Destroy(this.gameObject);
		}
}
}

using UnityEngine;
using System.Collections;

public class Coffee : MonoBehaviour {
GameObject master;
	public float score = -0.05f;

	// Use this for initialization
	void Start () {
		master = GameObject.Find ("Game Master");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter (Collider other) {
    if(other.tag == "Player"){
			master.SendMessage ("IncrementScore", score);
			Object.Destroy(this.gameObject);
		}
}
}

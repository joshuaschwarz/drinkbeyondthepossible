using UnityEngine;
using System.Collections;

public class Beer : MonoBehaviour {
  GameObject GameMaster;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter (other Collider) {
    if(other.tag == "Player"){
			GameMaster.GetComponent("GameMaster").IncrementScore();
			Object.Destroy(this.gameObject);
		}
}
}

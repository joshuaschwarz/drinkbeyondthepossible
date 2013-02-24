using UnityEngine;
using System.Collections;

public class Beer : MonoBehaviour {
  GameObject GameMaster;

	// Use this for initialization
	void Start () {
		var myTexture = Resources.Load("BeerBottle");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter (Collider other) {
    if(other.tag == "Player"){
			//GameMaster.GetComponent("GameMaster").IncrementScore();
			Object.Destroy(this.gameObject);
		}
}
}

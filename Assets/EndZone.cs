using UnityEngine;
using System.Collections;

public class EndZone : MonoBehaviour {
	public int x = -140;
	public int y = 14;
	public int z = 0;
	
	void Start()
	{
		renderer.enabled = false;
	}
	
	
	
	void OnTriggerEnter (Collider other) {
	    if(other.tag == "Player"){
			other.transform.position = new Vector3(x,y,z);
		}
	}
}

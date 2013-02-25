using UnityEngine;
using System.Collections;

public class EndZone : MonoBehaviour {
void OnTriggerEnter (Collider other) {
    if(other.tag == "Player"){
			other.transform.position = new Vector3(-140, 14, 0);
		}
	}
}

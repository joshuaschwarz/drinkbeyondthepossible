using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {
	
	private GameObject[] wobbleBlocks;
	private float score = 0.08f;
	private bool angle = true;
	private float ang = 0;
	
	// Use this for initialization
	void Start () {
		Debug.Log ("Running");
		wobbleBlocks = GameObject.FindGameObjectsWithTag("wobble");
		Debug.Log(wobbleBlocks.Length);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(score >= 0.08f)
		{
			Debug.Log (score);
			//Looks at each of the blocks that can wobble
			foreach(GameObject go in wobbleBlocks)	
			{
				if(angle)
				{
					go.transform.RotateAroundLocal(new Vector3(0,0,1), 3.0f * Time.fixedDeltaTime);	
					ang += 3.0f * Time.fixedDeltaTime;
				}
				else
				{
					go.transform.RotateAroundLocal(new Vector3(0,0,1), -3.0f * Time.fixedDeltaTime);	
					ang -= 3.0f * Time.fixedDeltaTime;
				}
			}
			if(ang >= 30.0f)
				angle = false;
			else if(ang <= -30.0f)
				angle = true;
		}
	}
}

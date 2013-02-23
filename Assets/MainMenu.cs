using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	
	private GameObject master;
	private bool gameRunning = false;

	// Use this for initialization
	void Start () {
		master = GameObject.Find ("Game Master");
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	//Sets the GUI Layout
	void OnGUI()
	{
		if(!gameRunning){
		if(GUI.Button (new Rect(.5f*Screen.width - 30, .5f*Screen.height, 60f, 20f), "Play"))
			{
				gameRunning = true;
				master.SendMessage("StartGame");
			}
		}
	}
}

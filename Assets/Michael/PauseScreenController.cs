using UnityEngine;
using System.Collections;

public class PauseScreenController : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void exitGame(){
		Application.Quit();
	}

	public void exitPause(){
		// this.gameObject.SetActive = false;
	}

	public void openSettings(){
		// UnityEngine.GUISettings ();
	}
}

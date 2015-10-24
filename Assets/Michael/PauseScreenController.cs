using UnityEngine;
using System.Collections;

public class PauseScreenController : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GoTo(int i){
		Application.LoadLevel (i);
	}

	public void exitGame(){
		Application.Quit();
	}

	public void exitPause(){
		//GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>().
	}
}

using UnityEngine;
using System.Collections;

public class NoteUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnClick(){
		Debug.Log ("Clicked outside of note - closing");
		GameObject.Find ("NoteImage").SetActive (false);
	}
}

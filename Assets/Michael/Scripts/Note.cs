//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using UnityEngine;
using System.Collections;

public class Note : MonoBehaviour
{
	public GameObject [] Notes;

	public Note ()
	{

	}

	void OnTriggerEnter(Collider obj)
	{
		Debug.Log ("Possible note pickup");
		if(obj.tag == "Player" && gameObject.activeInHierarchy)
		{
			Debug.Log ("Picked up note");
			if (gameObject.CompareTag("Note0")){
				ActivateNote(0);
			}else if (gameObject.CompareTag("Note1")){
				ActivateNote(1);
			}

			//gameObject.SetActive(false);
		}
	}

	public void ActivateNote(int i)
	{
		showNote (i);
		if (i == 0) {
			gameObject.GetComponent<Notifications> ().Notify ("Get a flash light.");
		} else if (i == 1) {
			gameObject.GetComponent<Notifications> ().Notify ("Get some gas");
		}
		StartCoroutine("Wait");
	}

	public void showNote(int i){
		GameObject.Find ("NotesCanvas").SetActive (true);
		GameObject.Find ("NoteImage").SetActive (true);
		//GameObject.Find ("NoteImage").transform.
		//if (i == 0) {
			//Debug.Log (GameObject.Find ("NoteImage").GetComponents());
		}


	IEnumerator Wait()
	{
		yield return new WaitForSeconds(3f);
		gameObject.GetComponent<Notifications>().ResetNotify();
	}
	
	}


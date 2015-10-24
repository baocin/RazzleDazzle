using UnityEngine;
using System.Collections;

public class GoToScene : MonoBehaviour {
	public void GoTo(int i){
		Application.LoadLevel (i);
	}
}

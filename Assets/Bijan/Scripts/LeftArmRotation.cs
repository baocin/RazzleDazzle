using UnityEngine;
using System.Collections;

public class LeftArmRotation : MonoBehaviour {

	const float armRotation = 5f;

	void Update () {
		gameObject.GetComponent<Rigidbody>().rotation = new Quaternion(armRotation,0,0,0);
	}
}

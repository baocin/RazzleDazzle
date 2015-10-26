using UnityEngine;
using System.Collections;

public class LoopGif : MonoBehaviour {
	public Texture [] images;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		while (true) {
			for (int i=0; i < images.Length; i++) {
				Texture s = images [i];
				gameObject.GetComponent<CanvasRenderer> ().SetTexture (s);

			}
		}
	}
}

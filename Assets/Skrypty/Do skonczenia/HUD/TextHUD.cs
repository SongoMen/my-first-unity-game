using UnityEngine;
using System.Collections;

public class TextHUD : MonoBehaviour {

	public Texture finishTexture;
	private bool bFinish;

	void Start () {
		bFinish = false;
	}

	void OnTriggerEnter(Collider col){
		if (col.tag == "Player") {
			bFinish = true;   
		}
	}

	void OnGui() {
		GUI.Box(new Rect(4,0,100,90), finishTexture);
	}
}